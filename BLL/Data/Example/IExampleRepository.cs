using BLL.Entities;

namespace BLL.Data.Example;

public interface IExampleRepository
{
    List<ExampleEntity> GetAll();
}