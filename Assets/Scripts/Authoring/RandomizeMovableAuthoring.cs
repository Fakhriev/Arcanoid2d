using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Movable))]
public class RandomizeMovableAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public float minimalSpeed;
    public float maximalSpeed;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        Movable movable = dstManager.GetComponentData<Movable>(entity);
        float randomSpeed = UnityEngine.Random.Range(minimalSpeed, maximalSpeed);

        float randomAngle = UnityEngine.Random.Range(0, 360);
        float radians = math.radians(randomAngle);
        float3 direction = new float3(math.cos(radians), math.sin(radians), 0);

        movable.speed = randomSpeed;
        movable.moveVector = direction;

        //Debug.Log($"Angle: {randomAngle}. Rad: {radians}, Direction: {direction}. Cos: {math.cos(randomAngle)}. Sin: {math.sin(randomAngle)}");
        dstManager.SetComponentData(entity, movable);
    }
}