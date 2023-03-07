using BLL.Data.Repositories;
using BLL.Entities;

namespace DAL.Repositories;

public class ExampleRepository : IExampleRepository
{
    public List<ExampleEntity> GetAll()
    {
        //TODO: Get data from the database.
        
        //This is temporary code.
        return new List<ExampleEntity>()
        {
            new (Guid.NewGuid()),
            new (Guid.NewGuid()),
            new (Guid.NewGuid()),
            new (Guid.NewGuid()),
            new (Guid.NewGuid())
        };
    }
}