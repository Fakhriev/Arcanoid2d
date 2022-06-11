using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[RequireComponent(typeof(SpawnOnDestroy))]
public class SpawnOnDestroyEntitySetter : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
{
    public GameObject spawnPrefab;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        SpawnOnDestroy spawnOnDestroy = dstManager.GetComponentData<SpawnOnDestroy>(entity);
        spawnOnDestroy.entityToSpawn = conversionSystem.GetPrimaryEntity(spawnPrefab);
        dstManager.SetComponentData(entity, spawnOnDestroy);
    }

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(spawnPrefab);
    }
}