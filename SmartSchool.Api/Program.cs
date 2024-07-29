using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Schema;
using SmartSchool.Schema.DataLoaders;
using SmartSchool.Schema.Mutations;
using SmartSchool.Schema.Queries;
using SmartSchool.Schema.Types;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("MariaDbConnection");

builder.Services.AddPooledDbContextFactory<SmartSchoolDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(11, 4, 0)))
);

builder.Services.AddAutoMapper(typeof(SmartSchoolDbContext));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
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
    .AddType<StudentType>()
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

app.UseCors("AllowSpecificOrigin");

app.MapGraphQL();

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

await app.RunAsync();

