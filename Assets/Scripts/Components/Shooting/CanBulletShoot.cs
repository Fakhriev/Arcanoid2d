using Unity.Entities;

[GenerateAuthoringComponent]
public struct CanBulletShoot : IComponentData
{
    [UnityEngine.HideInInspector] public Entity bulletEntity;

    public float reloadingTime;

    public bool isShooting;
}