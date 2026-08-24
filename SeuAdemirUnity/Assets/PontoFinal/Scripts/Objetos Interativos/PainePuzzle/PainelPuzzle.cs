using UnityEngine;

public class PainelPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject puzzleUI;
    [SerializeField] private GameObject playerUI;
    [SerializeField] private Interativos openDoor;
    private ObjectInterativo objectInterativo;
    void Start()
    {
        objectInterativo = GetComponent<ObjectInterativo>();
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
        PlayerInventory.Instance.AddInvisibleItem(openDoor);
        objectInterativo.enabled = false;
        Debug.Log(objectInterativo.enabled);
    }
}
