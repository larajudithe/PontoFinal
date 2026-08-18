using UnityEngine;

public class PainelPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject puzzleUI;
    [SerializeField] private GameObject playerUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartPuzzle()
    {
        playerUI.SetActive(false);
        puzzleUI.SetActive(true);
    }
    public void EndPuzzle()
    {
        puzzleUI.SetActive(false);
        playerUI.SetActive(true);
    }
}
