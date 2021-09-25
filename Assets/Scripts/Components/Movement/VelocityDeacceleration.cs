using Unity.Entities;

[GenerateAuthoringComponent]
public struct VelocityDeacceleration : IComponentData
{
    public float speed;
    public float stopThreshold;   
}