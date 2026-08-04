using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadGame ()
    {
        SceneManager.LoadScene ("TestScene");
    }
}
