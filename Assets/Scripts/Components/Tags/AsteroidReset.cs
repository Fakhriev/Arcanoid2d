using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct AsteroidReset : IComponentData
{
    public float minimalMoveSpeed;
    public float maximalMoveSpeed;

    public float3 minimalRotationDirection;
    public float3 maximalRotationDirection;

    public float minimalRotationSpeed;
    public float maximalRotationSpeed;
}