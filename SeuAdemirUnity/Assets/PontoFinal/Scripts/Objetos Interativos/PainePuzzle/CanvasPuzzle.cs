using UnityEngine;

public class CanvasPuzzle : MonoBehaviour
{
    private int unscreleds = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddUnscrew()
    {
        unscreleds++;
        if (unscreleds >= 4)
        {
            Debug.Log("Puzzle completed!");
        }
    }
}
