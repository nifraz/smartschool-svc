using AutoMapper;
using SmartSchool.Graphql.Inputs;
using SmartSchool.Graphql.Models;
using SmartSchool.Schema;
using SmartSchool.Schema.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Graphql.Helpers
{
    public static class MutationHelper
    {
        private static IMapper mapper;

        public static void Configure(IMapper? mapper)
        {
            ArgumentNullException.ThrowIfNull(mapper);
            MutationHelper.mapper = mapper;
        }

        public static async Task<M> CreateRecordAsync<E, I, M>(AppDbContext dbContext, I input) where E : AbstractRecord where I : AbstractRecordInput where M : AbstractRecordModel
        {
            var newRecord = mapper.Map<E>(input);
            newRecord.Id = 0;

            dbContext.Add(newRecord);
            await dbContext.SaveChangesAsync();

            return mapper.Map<M>(newRecord);
        }

        public static async Task<M> UpdateRecordAsync<E, I, M>(AppDbContext dbContext, I input) where E : AbstractRecord where I : AbstractRecordInput where M : AbstractRecordModel
        {
            if (input.Id == null || input.Id < 1)
            {
                throw new ArgumentException($"Invalid ID {input.Id}.");
            }

            var existingRecord = await dbContext.Set<E>()
                .FindAsync(input.Id) ?? throw new KeyNotFoundException($"No matching record found for the ID {input.Id}.");

            mapper.Map(input, existingRecord);

            await dbContext.SaveChangesAsync();

            return mapper.Map<M>(existingRecord);
        }
    }
}
