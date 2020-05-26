using ODataSerializationTest.Model;
using System.Collections.Generic;
using System.Linq;

namespace ODataSerializationTest.Data
{
    public class PersonRepository : IPersonRespository
    {
        private readonly IReadOnlyCollection<Person> backingStore;

        public PersonRepository()
        {
            this.backingStore = new List<Person>
            {
                new Person { Id = 1, FirstName = "Ahyan", LastName = "Preece" },
                new Person { Id = 2, FirstName = "Korey", LastName = "Davenport" },
                new Person { Id = 3, FirstName = "Nicole", LastName = "Larson" },
                new Person { Id = 4, FirstName = "Kirsten", LastName = "Riley" },
                new Person { Id = 5, FirstName = "Codey", LastName = "O'Brien" },
            };
        }

        public IQueryable<Person> People => this.backingStore.AsQueryable();
    }
}
