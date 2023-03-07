using BLL.Data.Repositories;
using BLL.Entities;
using DAL.Repositories;

namespace DataFactory.Factories;

public class ExampleFactory
{
    private readonly IExampleRepository _exampleRepository;
    
    public ExampleFactory()
    {
        _exampleRepository = new ExampleRepository();
    }
    
    public List<ExampleEntity> GetAll()
    {
        return _exampleRepository.GetAll();
    }
}