using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.InputSystem;

public class CinematicManager : MonoBehaviour
{
    private Coroutine cineTimerCoroutine;
    [SerializeField] private string sceneGame; // Nome da cena a ser carregada
    [SerializeField] private string sceneCine; // Nome da cena a ser carregada
    [SerializeField] private float changeTime;
    public static CinematicManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void LoadGame()
    {
        StopCoroutine(cineTimerCoroutine);
        Debug.Log("Game");
        SceneManager.LoadScene(sceneGame); // Ir para a cena de jogo
    }
    public void LoadCinematic()
    {
        Debug.Log("Cine");
        SceneManager.LoadScene(sceneCine); // Ir para a cinematic
        cineTimerCoroutine = StartCoroutine(CinematicTime(sceneGame, changeTime)); // Iniciar a corrotina para carregar a cena cinematica ap�s o tempo definido
    }
    private IEnumerator CinematicTime(string nextScene, float cinematicTime)
    {
        Debug.Log("Esta contando o tempo da cinematic");
        yield return new WaitForSeconds(cinematicTime);
        SceneManager.LoadScene(nextScene);
    }
}
