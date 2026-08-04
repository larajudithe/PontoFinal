using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField] private GameObject interactCursor;
    [SerializeField] private Image InterativoImage;
    [SerializeField] private InputAction openInventory;
    void Start()
    {
        
    }
    private void Awake()
    {
        openInventory = InputSystem.actions.FindAction("OpenInventory");
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    
    void Update()
    {
        if (openInventory.WasPressedThisFrame())
        {
            Debug.Log("Abrindo inventário");
        }
    }
    public void ChangeInteract(bool stage)
    {
        interactCursor.SetActive(stage);
    }
    public void SetInterativoImage(Sprite sprite, bool state)
    {
        InterativoImage.sprite = sprite;
        InterativoImage.enabled = state;
    }
}
