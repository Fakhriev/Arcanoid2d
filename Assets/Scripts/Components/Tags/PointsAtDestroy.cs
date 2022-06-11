using Unity.Entities;

[GenerateAuthoringComponent]
public struct PointsAtDestroy : IComponentData
{
    public int value;
}