using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct Velocity : IComponentData
{
    public float3 vector;

    public float maximum;

    public bool isDecreasing;
}