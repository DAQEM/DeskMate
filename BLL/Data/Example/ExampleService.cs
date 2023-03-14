using BLL.Entities;

namespace BLL.Data.Example;

public class ExampleService : IExampleService
{
    private readonly IExampleRepository _exampleRepository;

    public ExampleService(IExampleRepository exampleRepository)
    {
        _exampleRepository = exampleRepository;
    }

    public List<ExampleEntity> GetAll()
    {
        return _exampleRepository.GetAll();
    }
}