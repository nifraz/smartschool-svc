using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Graphql.Models;
using SmartSchool.Schema;

namespace SmartSchool.Graphql.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class PersonsQuery
    {
        private readonly IMapper mapper;

        public PersonsQuery(
            IMapper mapper
        )
        {
            this.mapper = mapper;
        }

        [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 10, MaxPageSize = 100)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<PersonModel> GetPersons(AppDbContext dbContext)
        {
            return dbContext.Persons
                .ProjectTo<PersonModel>(mapper.ConfigurationProvider)
                ;
        }

        public async Task<PersonModel?> GetPersonAsync(AppDbContext dbContext, long id)
        {
            var existingRecord = await dbContext.Persons
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingRecord == null)
            {
                return null;
            }

            var response = mapper.Map<PersonModel>(existingRecord);

            return response;
        }

        [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 10, MaxPageSize = 100)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<PersonRelationshipModel> GetPersonRelationships(AppDbContext dbContext)
        {
            return dbContext.PersonRelationships
                .ProjectTo<PersonRelationshipModel>(mapper.ConfigurationProvider)
                ;
        }

        public async Task<PersonRelationshipModel?> GetPersonRelationshipAsync(AppDbContext dbContext, long id)
        {
            var existingRecord = await dbContext.PersonRelationships
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingRecord == null)
            {
                return null;
            }

            var response = mapper.Map<PersonRelationshipModel>(existingRecord);

            return response;
        }

    }
}
