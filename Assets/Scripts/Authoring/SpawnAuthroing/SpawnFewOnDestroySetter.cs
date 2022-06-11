using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[RequireComponent(typeof(SpawnFewOnDestroy))]
public class SpawnFewOnDestroySetter : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
{
    public GameObject spawnPrefab;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        SpawnFewOnDestroy spawnFewOnDestroy = dstManager.GetComponentData<SpawnFewOnDestroy>(entity);
        spawnFewOnDestroy.entityToSpawn = conversionSystem.GetPrimaryEntity(spawnPrefab);
        dstManager.SetComponentData(entity, spawnFewOnDestroy);
    }

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(spawnPrefab);
    }
}