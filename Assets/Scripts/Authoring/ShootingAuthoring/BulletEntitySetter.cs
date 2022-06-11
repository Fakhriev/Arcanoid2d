using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[RequireComponent(typeof(CanBulletShoot))]
public class BulletEntitySetter : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
{
    public GameObject bulletPrefab;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        CanBulletShoot canBulletShoot = dstManager.GetComponentData<CanBulletShoot>(entity);
        canBulletShoot.bulletEntity = conversionSystem.GetPrimaryEntity(bulletPrefab);
        dstManager.SetComponentData(entity, canBulletShoot);
    }

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(bulletPrefab);
    }
}