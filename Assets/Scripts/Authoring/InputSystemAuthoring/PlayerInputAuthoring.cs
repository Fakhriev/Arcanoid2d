using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

[DisallowMultipleComponent]
public class PlayerInputAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public PlayerInput playerInput;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        conversionSystem.AddHybridComponent(playerInput);
    }
}