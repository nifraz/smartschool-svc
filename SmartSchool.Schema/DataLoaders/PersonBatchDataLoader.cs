using GreenDonut;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Schema.Entities;
using SmartSchool.Schema.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.DataLoaders
{
    // This is one way of implementing a data loader. You will find the different ways of declaring
    // data loaders further down the page.
    public class PersonBatchDataLoader : BatchDataLoader<long, Person>
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public PersonBatchDataLoader(
            IDbContextFactory<AppDbContext> dbContextFactory,
            IBatchScheduler batchScheduler,
            DataLoaderOptions? options = null)
            : base(batchScheduler, options)
        {
            _dbContextFactory = dbContextFactory;
        }

        protected override async Task<IReadOnlyDictionary<long, Person>>
        LoadBatchAsync(IReadOnlyList<long> keys, CancellationToken cancellationToken)
        {
            await using AppDbContext dbContext =
                _dbContextFactory.CreateDbContext();

            //return await dbContext.Persons
            //    .Where(s => keys.Contains(s.Id))
            //    .ToDictionaryAsync(t => t.Id, ct);
            throw new NotImplementedException();
        }

        //protected override async Task<IReadOnlyDictionary<string, Person>> LoadBatchAsync(
        //    IReadOnlyList<string> keys,
        //    CancellationToken cancellationToken)
        //{
        //    // instead of fetching one person, we fetch multiple persons
        //    var persons = await _repository.GetPersonByIds(keys);
        //    return persons.ToDictionary(x => x.Id);
        //}
    }


    //public class Query
    //{
    //    public async Task<Person> GetPerson(
    //        string id,
    //        PersonBatchDataLoader dataLoader)
    //        => await dataLoader.LoadAsync(id);
    //}

}
