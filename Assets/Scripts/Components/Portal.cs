using Unity.Entities;

[GenerateAuthoringComponent]
public struct Portal : IComponentData
{
    public PortalSide side;
    public float sideDelta;
}

public enum PortalSide
{
    Left,
    Right,
    Up,
    Down
}