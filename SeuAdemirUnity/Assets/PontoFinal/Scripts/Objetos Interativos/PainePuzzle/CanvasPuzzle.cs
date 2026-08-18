using UnityEngine;
using UnityEngine.UI;

public class CanvasPuzzle : MonoBehaviour
{
    private int unscreleds = 0;
    [SerializeField] private GameObject[] parafusos;
    [SerializeField] private GameObject smashUI;
    [SerializeField] private GameObject chapa;
    [SerializeField] private Button Fios;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddUnscrew()
    {
        Debug.Log("Chamado");
        unscreleds++;
        if (unscreleds >= 4)
        {
            smashUI.SetActive(true);
            Debug.Log("Puzzle completed!");
        }
    }
    public void InsidePainel()
    {
        smashUI.SetActive(false);
        chapa.SetActive(false);
        foreach (GameObject parafuso in parafusos)
        {
            parafuso.SetActive(false);
        }
        Fios.enabled = true;
    }
}
