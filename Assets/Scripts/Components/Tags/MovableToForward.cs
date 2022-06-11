using Unity.Entities;

[GenerateAuthoringComponent]
public struct MovableToForward : IComponentData
{
    public float speed;
}