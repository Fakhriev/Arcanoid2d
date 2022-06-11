using Unity.Entities;
using Unity.Mathematics;

public struct Portal : IComponentData
{
    public float3 moveValue;
}

public enum PortalSide
{
    Left,
    Right,
    Up,
    Down
}