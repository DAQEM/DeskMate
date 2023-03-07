using BLL.Entities;

namespace BLL.Data.Repositories;

public interface IExampleRepository
{
    List<ExampleEntity> GetAll();
}