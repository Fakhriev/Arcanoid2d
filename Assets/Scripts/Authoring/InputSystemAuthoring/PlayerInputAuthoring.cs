using Unity.Entities;
using Unity.Mathematics;
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
