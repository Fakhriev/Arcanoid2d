using Unity.Entities;

[GenerateAuthoringComponent]
public struct LimitedLifetime : IComponentData
{
    public float value;
}