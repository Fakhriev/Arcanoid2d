using Unity.Transforms;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Points _points;
    [SerializeField] private GameState _gameState;
    [SerializeField] private Parametres _parametres;

    private void Start()
    {
        instance = this;
    }

    public void Loose()
    {
        _gameState.Loose();
    }

    public void AddPoints(int value)
    {
        _points.Add(value);
    }

    public void UpdateParametres(Translation playerTranslation, Rotation rotation, Velocity playerVelocity, CanLaserShoot playerLaser)
    {
        _parametres.UpdateAll(playerTranslation, rotation, playerVelocity, playerLaser);
    }
}