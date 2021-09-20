using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct Rotative : IComponentData
{
    public float3 eulerRotation;
    public float rotationSpeed;
}