using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rotative))]
public class RandomizeRotativeAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public float3 minimalRotation;
    public float3 maximalRotation;

    public float minimalSpeed;
    public float maximalSpeed;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        Rotative rotative = dstManager.GetComponentData<Rotative>(entity);
        float3 randomDirection = new float3(Random.Range(minimalRotation.x, maximalRotation.x),
                                            Random.Range(minimalRotation.y, maximalRotation.y),
                                            Random.Range(minimalRotation.z, maximalRotation.z));

        rotative.rotateDirection = randomDirection;
        rotative.rotationSpeed = Random.Range(minimalSpeed, maximalSpeed);

        dstManager.SetComponentData(entity, rotative);
    }
}