namespace BLL.Entities;

public class WorkspacePlacement
{
    private readonly int _height;
    private readonly Guid _id;
    private readonly int _positionX;
    private readonly int _positionY;
    private readonly int _rotation;
    private readonly int _width;

    public WorkspacePlacement(Guid? id = null,
        int? positionX = null, int? positionY = null, int? width = null,
        int? height = null, int? rotation = null)
    {
        _id = id ?? Guid.NewGuid();
        _positionX = positionX ?? 0;
        _positionY = positionY ?? 0;
        _width = width ?? 0;
        _height = height ?? 0;
        _rotation = rotation ?? 0;
    }

    public Guid Id => _id;
    public int PositionX => _positionX;
    public int PositionY => _positionY;
    public int Width => _width;
    public int Height => _height;
    public int Rotation => _rotation;
}