using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct Rotative : IComponentData
{
    public float3 rotateDirection;
    public float rotationSpeed;
}