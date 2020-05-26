using ODataSerializationTest.Model;
using System.Linq;

namespace ODataSerializationTest.Data
{
    public interface IPersonRespository
    {
        IQueryable<Person> People { get; }
    }
}
