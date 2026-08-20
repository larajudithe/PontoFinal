using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.InputSystem;

public class SceneMenager : MonoBehaviour
{
    [SerializeField] private string sceneCine; // Nome da cena a ser carregada
    [SerializeField] private string sceneGame; // Nome da cena a ser carregada
    [SerializeField] private string sceneMenu; // Nome da cena a ser carregada
    [SerializeField] private float changeTime;
    private Coroutine cineTimerCoroutine;
    private InputAction skipCine;
    public static SceneMenager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        skipCine = InputSystem.actions.FindAction("Skip");
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == sceneCine && skipCine.WasPressedThisFrame())
        {
            StopCoroutine(cineTimerCoroutine);
            LoadGame();
        }
    }
    public void LoadGame()
    {
        Debug.Log("Game");
        SceneManager.LoadScene(sceneGame); // Ir para a cena de jogo
    }
    public void LoadCinematic()
    {
        Debug.Log("Cine");
        SceneManager.LoadScene(sceneCine); // Ir para a cinematic
        cineTimerCoroutine = StartCoroutine(CinematicTime(sceneGame, changeTime)); // Iniciar a corrotina para carregar a cena cinematica ap�s o tempo definido
    }
    public void LoadMenu()
    {
        Debug.Log("Game");
        SceneManager.LoadScene(sceneMenu); // Ir para a cena de jogo
    }
    public void Sair()
    {
        Debug.Log("Sair");
    }
    private IEnumerator CinematicTime(string nextScene, float cinematicTime)
    {
        Debug.Log("Esta contando o tempo da cinematic");
        yield return new WaitForSeconds(cinematicTime);
        SceneManager.LoadScene(nextScene);
    }
}

