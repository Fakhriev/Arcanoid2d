using System;
using Unity.Entities;

[Serializable]
public struct Spawner : IComponentData
{
    public Entity entityToSpawn;
    public float timeToSpawn;
    public float spawnInterval;
}