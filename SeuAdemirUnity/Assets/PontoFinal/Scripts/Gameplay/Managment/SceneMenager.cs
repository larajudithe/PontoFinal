using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.InputSystem;

public class SceneMenager : MonoBehaviour
{
    [SerializeField] private string sceneMenu; // Nome da cena a ser carregada
    [SerializeField] private GameObject painelOPC;
        [SerializeField] private GameObject painelNarrativa;
    [SerializeField] private GameObject painelMENU;
    public static SceneMenager Instance { get; private set; }
    public void LoadMenu()
    {
        Debug.Log("Game");
        SceneManager.LoadScene(sceneMenu); // Ir para a cena de jogo
    }

    public void AbrirOPC()
    {
        painelMENU.SetActive(false);
        painelOPC.SetActive(true);
    }

    public void FecharOPC()
    {
        painelMENU.SetActive(true);
        painelOPC.SetActive(false);
    }

     public void AbrirNarrativa()
    {
        painelMENU.SetActive(false);
        painelNarrativa.SetActive(true);
    }

    public void FecharNarrativa()
    {
        painelMENU.SetActive(true);
        painelNarrativa.SetActive(false);
    }
    public void Play()
    {
        CinematicManager.Instance.LoadCinematic();
    }

    public void Sair()
    {
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}

