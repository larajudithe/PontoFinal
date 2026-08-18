using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneMenager : MonoBehaviour
{
    [SerializeField] private string sceneCine; // Nome da cena a ser carregada
    [SerializeField] private string sceneGame; // Nome da cena a ser carregada
    [SerializeField] private string sceneMenu; // Nome da cena a ser carregada
    [SerializeField] private float changeTime;
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
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(sceneGame); // Ir para a cena de jogo
    }
    public void LoadCinematic()
    {
        SceneManager.LoadScene(sceneCine); // Ir para a cinematic
        StartCoroutine(CinematicTime(sceneGame, changeTime)); // Iniciar a corrotina para carregar a cena cinematica ap�s o tempo definido
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(sceneMenu); // Ir para a cena de jogo
    }
    public IEnumerator CinematicTime(string nextScene, float cinematicTime)
    {
        Debug.Log("Esta contando o tempo da cinematic");
        yield return new WaitForSeconds(cinematicTime);
        SceneManager.LoadScene(nextScene);
    }
}

