using UnityEngine;
using UnityEngine.UI;

public class CanvasPuzzle : MonoBehaviour
{
    private int unscreleds = 0;
    [SerializeField] private GameObject[] parafusos;
    [SerializeField] private GameObject smashUI;
    [SerializeField] private GameObject chapa;
    [SerializeField] private Button Fios;
    [SerializeField] private Animator[] screwsAnimators;
    private bool readyToStartSmash = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToStartSmash)
        {
            StartSmash();
        }
    }
    public void AddUnscrew()
    {
       // Debug.Log("Chamado");
        unscreleds++;
        if (unscreleds >= 4)
        {
            readyToStartSmash=true;
            Debug.Log("Parafuso completed!");
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
    private void StartSmash()
    {
        foreach (Animator screwAnimator in screwsAnimators)
        {
            if (!screwAnimator.GetCurrentAnimatorStateInfo(0).IsName("Big"))
            {
                return;
            }
        }
        readyToStartSmash = false;
        smashUI.SetActive(true);
    }
}
