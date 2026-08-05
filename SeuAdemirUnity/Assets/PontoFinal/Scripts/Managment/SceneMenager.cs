using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenager : MonoBehaviour
{
    public void LoadGame ()
    {
        SceneManager.LoadScene ("TestScene"); // Troca de cena
    }
}
