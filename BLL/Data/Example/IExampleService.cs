using BLL.Entities;

namespace BLL.Data.Example;

public interface IExampleService
{
    List<ExampleEntity> GetAll();
}