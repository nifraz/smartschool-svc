using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmartSchool.Api;
using SmartSchool.Graphql;
using SmartSchool.Graphql.DataLoaders;
using SmartSchool.Graphql.Models;
using SmartSchool.Graphql.Mutations;
using SmartSchool.Graphql.Queries;
using SmartSchool.Graphql.Subscriptions;
using SmartSchool.Schema;
using SmartSchool.Service.Models.Settings;
using SmartSchool.Service.Services;
using SmartSchool.Utility.Helpers;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AuthSettings>(builder.Configuration.GetSection(nameof(AuthSettings)));
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection(nameof(SmtpSettings)));
builder.Services.Configure<SmsSettings>(builder.Configuration.GetSection(nameof(SmsSettings)));

var smtpSettings = builder.Configuration.GetSection(nameof(SmtpSettings)).Get<SmtpSettings>();
var smsSettings = builder.Configuration.GetSection(nameof(SmsSettings)).Get<SmsSettings>();

TemplateGenerator.FromEmail = smtpSettings?.FromEmail;
TemplateGenerator.FromPhoneNumber = smsSettings?.FromPhoneNumber;

// Add services to the container.
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<GraphqlAutoMapperProfile>();
    cfg.AddProfile<ServiceAutoMapperProfile>();
    // Add additional profiles as needed
});

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddTransient<INotificationService, NotificationService>();
builder.Services.AddHttpClient();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddAuthorization();

var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
var connectionString = builder.Configuration.GetConnectionString("MariaDbConnection");

builder.Services.AddPooledDbContextFactory<AppDbContext>(options =>
    options
        .UseLoggerFactory(loggerFactory)
        .UseMySql(connectionString, new MySqlServerVersion(new Version(11, 4, 0)))
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
    .RegisterDbContext<AppDbContext>(DbContextKind.Pooled)
    .AddQueryType<Query>()
    .AddTypeExtension<UsersQuery>()
    .AddTypeExtension<StudentsQuery>()
    .AddTypeExtension<TeachersQuery>()
    .AddTypeExtension<SchoolsQuery>()
    .AddType<StudentModel>()
    .AddMutationType<Mutation>()
    .AddTypeExtension<StudentMutation>()
    .AddTypeExtension<SchoolMutation>()
    .AddInMemorySubscriptions()
    .AddSubscriptionType<SchoolSubscription>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

builder.Services.AddScoped<PersonBatchDataLoader>();
builder.Services.AddHttpContextAccessor();
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
app.UseWebSockets();
app.MapControllers();
app.MapGraphQL();

await app.RunAsync();

