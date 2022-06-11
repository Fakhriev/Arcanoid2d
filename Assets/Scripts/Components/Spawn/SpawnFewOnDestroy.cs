using Unity.Entities;

[GenerateAuthoringComponent]
public struct SpawnFewOnDestroy : IComponentData
{
    [UnityEngine.HideInInspector] public Entity entityToSpawn;
    public int amount;
}