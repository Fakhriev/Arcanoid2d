using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct VelocityAcceleration : IComponentData
{
    public float3 vector;
    public float speed;
}