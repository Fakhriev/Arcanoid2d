using System.Collections;
using Unity.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject _gameEndModal;

    [SerializeField] private float _delay;

    public void Loose()
    {
        StartCoroutine(LooseWithDelay());
    }

    public void GameRestart()
    {
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        entityManager.DestroyEntity(entityManager.UniversalQuery);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    private IEnumerator LooseWithDelay()
    {
        yield return new WaitForSeconds(_delay);
        _gameEndModal.SetActive(true);
    }
}