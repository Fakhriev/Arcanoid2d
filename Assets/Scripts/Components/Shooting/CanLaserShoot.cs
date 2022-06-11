using Unity.Entities;

public struct CanLaserShoot : IComponentData
{
    public Entity entity;

    public int amount;
    public int maxAmount;

    public float reload;
    public float reloadTime;

    public bool isLaserActive;
}