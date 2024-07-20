using AutoMapper;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class StudentMutation
    {
        //private readonly IDbContextFactory<SmartSchoolDbContext> dbContextFactory;
        private readonly IMapper mapper;

        public StudentMutation(
            //IDbContextFactory<SmartSchoolDbContext> dbContextFactory,
            IMapper mapper
        )
        {
            //this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
        }

        public async Task<StudentType> CreateStudentAsync(SmartSchoolDbContext dbContext, StudentInput input)
        {
            //using var dbContext = await dbContextFactory.CreateDbContextAsync();
            var newRecord = mapper.Map<Student>(input);
            //newRecord.DateOfBirth = DateTime.SpecifyKind(newRecord.DateOfBirth, DateTimeKind.Utc); //need fix

            dbContext.Students.Add(newRecord);
            await dbContext.SaveChangesAsync();

            return mapper.Map<StudentType>(newRecord);
        }

        public async Task<StudentType> UpdateStudentAsync(SmartSchoolDbContext dbContext, long id, StudentInput input)
        {
            var existingRecord = await dbContext.Students.FindAsync(id) ?? throw new KeyNotFoundException($"No matching record found (id={id})");
            mapper.Map(input, existingRecord);

            await dbContext.SaveChangesAsync();

            return mapper.Map<StudentType>(existingRecord);
        }
    }
}
