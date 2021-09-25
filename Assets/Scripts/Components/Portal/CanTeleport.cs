using Unity.Entities;

[GenerateAuthoringComponent]
public struct CanTeleport : IComponentData
{
    public float immuneTime;
    public float defaultImmuneTime;
}