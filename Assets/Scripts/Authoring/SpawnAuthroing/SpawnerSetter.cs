using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SpawnerSetter : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
{
    public GameObject spawnPrefab;
    public float timeToSpawn;
    public float spawnInterval;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new Spawner() 
        {   entityToSpawn = conversionSystem.GetPrimaryEntity(spawnPrefab),
            timeToSpawn = timeToSpawn,
            spawnInterval = spawnInterval
        });
    }

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(spawnPrefab);
    }
}