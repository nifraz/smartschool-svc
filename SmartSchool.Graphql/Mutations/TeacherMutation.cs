using AutoMapper;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using SmartSchool.Graphql.Inputs;
using SmartSchool.Graphql.Models;
using SmartSchool.Schema;
using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Enums;

namespace SmartSchool.Graphql.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class TeacherMutation
    {
        //private readonly IDbContextFactory<SmartSchoolDbContext> dbContextFactory;
        private readonly IMapper mapper;

        public TeacherMutation(
            //IDbContextFactory<SmartSchoolDbContext> dbContextFactory,
            IMapper mapper
        )
        {
            //this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
        }

        public async Task<TeacherModel> CreateTeacherAsync(AppDbContext dbContext, TeacherInput input)
        {
            //using var dbContext = await dbContextFactory.CreateDbContextAsync();
            var newRecord = mapper.Map<Teacher>(input);
            //newRecord.DateOfBirth = DateTime.SpecifyKind(newRecord.DateOfBirth, DateTimeKind.Utc); //need fix

            dbContext.Teachers.Add(newRecord);
            await dbContext.SaveChangesAsync();

            return mapper.Map<TeacherModel>(newRecord);
        }

        public async Task<TeacherModel> UpdateTeacherAsync(AppDbContext dbContext, TeacherInput input)
        {
            ArgumentNullException.ThrowIfNull(input.Id);

            var existingRecord = await dbContext.Teachers.FindAsync(input.Id.Value) ?? throw new KeyNotFoundException($"No matching record found (id={input.Id.Value})");
            mapper.Map(input, existingRecord);

            await dbContext.SaveChangesAsync();

            return mapper.Map<TeacherModel>(existingRecord);
        }

    }
}
