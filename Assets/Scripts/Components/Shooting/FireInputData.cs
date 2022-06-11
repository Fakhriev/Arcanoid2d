using Unity.Entities;

[GenerateAuthoringComponent]
public struct FireInputData : IComponentData
{
    public bool isFiring;
}