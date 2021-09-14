using Unity.Entities;
using UnityEngine;

[DisallowMultipleComponent]
public class CameraAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public Camera Camera;
    public AudioListener AudioListener;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new CameraTag() { });

        conversionSystem.AddHybridComponent(Camera);
        conversionSystem.AddHybridComponent(AudioListener);
    }
}