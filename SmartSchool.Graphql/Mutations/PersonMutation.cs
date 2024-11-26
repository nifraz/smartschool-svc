using AutoMapper;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using SmartSchool.Graphql.Helpers;
using SmartSchool.Graphql.Inputs;
using SmartSchool.Graphql.Models;
using SmartSchool.Schema;
using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Enums;
using SmartSchool.Service.Services;

namespace SmartSchool.Graphql.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class PersonMutation
    {
        private readonly IAuthService authService;

        public PersonMutation(
            IAuthService authService
        )
        {
            this.authService = authService;
        }

        public async Task<PersonModel> CreatePersonAsync(AppDbContext dbContext, PersonInput input)
        {
            if (input.Email != null && await authService.IsEmailRegisteredAsync(input.Email))
            {
                throw new InvalidDataException("Email address is already registered.");
            }
            if (input.MobileNo != null && await authService.IsMobileNoRegisteredAsync(input.MobileNo))
            {
                throw new InvalidDataException("Mobile number is already registered.");
            }

            return await MutationHelper.CreateRecordAsync<Person, PersonInput, PersonModel>(dbContext, input);
        }

        public async Task<PersonModel> UpdatePersonAsync(AppDbContext dbContext, PersonInput input)
        {
            ArgumentNullException.ThrowIfNull(input.Id);

            if (input.Email != null && await authService.IsEmailRegisteredAsync(input.Email, input.Id.Value))
            {
                throw new InvalidDataException("Email address is already registered.");
            }
            if (input.MobileNo != null && await authService.IsMobileNoRegisteredAsync(input.MobileNo, input.Id.Value))
            {
                throw new InvalidDataException("Mobile number is already registered.");
            }

            return await MutationHelper.UpdateRecordAsync<Person, PersonInput, PersonModel>(dbContext, input);
        }

        public async Task<PersonRelationshipModel> CreatePersonRelationshipAsync(AppDbContext dbContext, PersonRelationshipInput input)
        {
            var existingPersonRelationships = await dbContext.PersonRelationships
                .Include(x => x.Person1)
                .Include(x => x.Person2)
                .Where(x => (x.Person1Id == input.Person1Id && x.Person2Id == input.Person2Id) || (x.Person1Id == input.Person2Id && x.Person2Id == input.Person1Id))
                .ToListAsync();

            if (existingPersonRelationships.Count != 0)
            {
                throw new InvalidOperationException($"Relationship already exists between {input.Person1Id} and {input.Person2Id}.");
            }

            return await MutationHelper.CreateRecordAsync<PersonRelationship, PersonRelationshipInput, PersonRelationshipModel>(dbContext, input);
        }

    }
}
