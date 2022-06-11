using Unity.Entities;

[GenerateAuthoringComponent]
public struct PortalPreparation : IComponentData
{
    public PortalSide side;
    public float sideDelta;
}