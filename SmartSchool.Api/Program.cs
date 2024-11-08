using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmartSchool.Schema;
using SmartSchool.Schema.DataLoaders;
using SmartSchool.Schema.Models.Settings;
using SmartSchool.Schema.Mutations;
using SmartSchool.Schema.Queries;
using SmartSchool.Schema.Types;
using SmartSchool.Service;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AuthSettings>(builder.Configuration.GetSection(nameof(AuthSettings)));
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection(nameof(SmtpSettings)));
builder.Services.Configure<SmsSettings>(builder.Configuration.GetSection(nameof(SmsSettings)));

// Add services to the container.
builder.Services.AddAutoMapper(typeof(SmartSchoolDbContext));
builder.Services.AddScoped<IAuthService, AuthService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddAuthorization();

var connectionString = builder.Configuration.GetConnectionString("MariaDbConnection");

builder.Services.AddPooledDbContextFactory<SmartSchoolDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(11, 4, 0)))
);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<SmartSchoolDbContext>(DbContextKind.Pooled)
    .AddQueryType<Query>()
    .AddTypeExtension<StudentsQuery>()
    .AddTypeExtension<TeachersQuery>()
    .AddTypeExtension<SchoolsQuery>()
    .AddType<StudentModel>()
    .AddMutationType<Mutation>()
    .AddTypeExtension<StudentMutation>()
    .AddInMemorySubscriptions()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

builder.Services.AddScoped<PersonBatchDataLoader>();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseCors("AllowLocalhost");

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHttpsRedirection();
}

app.UseRouting();
app.MapControllers();
app.MapGraphQL();

await app.RunAsync();

