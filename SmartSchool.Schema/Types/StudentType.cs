using AutoMapper;
using HotChocolate;
using SmartSchool.Schema.DataLoaders;
using SmartSchool.Schema.Entities;

namespace SmartSchool.Schema.Types
{
    public class StudentType : PersonType
    {
        //[IsProjected(true)]
        //public int Id { get; set; }
        //[IsProjected(true)]
        //public long PersonId { get; set; }
        //[UseProjection]
        //[UseFiltering]
        ////[UseSorting]
        //public PersonType Person { get; set; }
        //public async Task<PersonType> Person([Service] PersonBatchDataLoader dataLoader)
        //{
        //    var record = await dataLoader.LoadAsync(PersonId);
        //    if (record == null) { throw new KeyNotFoundException($"No matching record found (PersonId={PersonId})"); }

        //    return new PersonType
        //    {
        //        Id = record.Id,
        //        Guid = record.Guid,
        //        CreatedBy = record.CreatedBy,
        //        CreatedOn = record.CreatedOn,
        //        LastModifiedBy = record.LastModifiedBy,
        //        LastModifiedOn = record.LastModifiedOn,
        //        FullName = record.FullName,
        //        Nickname = record.Nickname,
        //        Username = record.Username,
        //        DateOfBirth = record.DateOfBirth,
        //        BcNo = record.BcNo,
        //        Sex = record.Sex,
        //        NicNo = record.NicNo,
        //        MobileNo = record.MobileNo,
        //        Email = record.Email,
        //        Address = record.Address,
        //    };
        //}

        //public ICollection<Admission> Admissions { get; set; } = [];
        //public ICollection<Leave> Leaves { get; set; } = [];
    }
}
