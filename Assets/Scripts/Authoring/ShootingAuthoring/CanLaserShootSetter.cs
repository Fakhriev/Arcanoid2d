using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[DisallowMultipleComponent]
public class CanLaserShootSetter : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
{
    public GameObject laserPrefab;
    public int laserMaxAmount;
    public float laserReloadTime;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new CanLaserShoot()
        {
            entity = conversionSystem.GetPrimaryEntity(laserPrefab),
            amount = laserMaxAmount,
            maxAmount = laserMaxAmount,
            reload = laserReloadTime,
            reloadTime = laserReloadTime
        });
    }

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(laserPrefab);
    }
}