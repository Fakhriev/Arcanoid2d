using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct InputData : IComponentData
{
    public float3 moveInput;
    public float3 rotationInput;
}