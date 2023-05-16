namespace BLL.Entities;

public class Role
{
    private readonly Employee? _employee;
    private readonly Guid _id;
    private readonly List<Permission> _permissions;
    private readonly string _type;

    public Role(Guid? id = null, string? type = null,
        List<Permission>? permissions = null, Employee? employee = null)
    {
        _id = id ?? Guid.Empty;
        _type = type ?? "";
        _permissions = permissions ?? new List<Permission>();
        _employee = employee;
    }

    public Guid Id => _id;
    public string Type => _type;
    public List<Permission> Permissions => _permissions;
    public Employee? Employee => _employee;
}