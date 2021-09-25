using Unity.Entities;

[GenerateAuthoringComponent]
public struct InertiaResistance : IComponentData
{
    public float value;
    public float maximum;
}