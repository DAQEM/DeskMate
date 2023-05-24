namespace BLL.Entities;

public class Permission
{
    private readonly Guid _id;
    private readonly Role _role;
    private readonly string _type;

    public Permission(Guid? id = null, string? type = null, Role? role = null)
    {
        _id = id ?? Guid.NewGuid();
        _type = type ?? "";
        _role = role ?? new Role();
    }

    public Guid Id => _id;
    public string Type => _type;
    public Role Role => _role;
}