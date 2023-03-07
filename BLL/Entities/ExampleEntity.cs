namespace BLL.Entities;

public class ExampleEntity
{
    private readonly Guid _id;

    public ExampleEntity(Guid id)
    {
        _id = id;
    }
    
    public Guid Id => _id;
}