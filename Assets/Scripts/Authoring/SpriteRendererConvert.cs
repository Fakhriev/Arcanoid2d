using Unity.Entities;
using UnityEngine;

[DisallowMultipleComponent]
public class SpriteRendererConvert : MonoBehaviour, IConvertGameObjectToEntity
{
    public SpriteRenderer spriteRenderer;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        conversionSystem.AddHybridComponent(spriteRenderer);
    }
}