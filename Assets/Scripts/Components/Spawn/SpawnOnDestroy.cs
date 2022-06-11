using Unity.Entities;

[GenerateAuthoringComponent]
public struct SpawnOnDestroy : IComponentData
{
    public Entity entityToSpawn;
}