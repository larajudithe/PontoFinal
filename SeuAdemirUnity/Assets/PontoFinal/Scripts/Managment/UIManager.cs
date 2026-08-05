using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField] private GameObject interactCursor;
    [SerializeField] private Image InterativoImage;
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private InputAction openInventory;
    [SerializeField] private TextMeshProUGUI[] inventoryText;
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
            inventoryUI.SetActive(!inventoryUI.activeInHierarchy);
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
    public void SetItens(Interativos interativo, int index)
    {
        inventoryText[index].text = "-"+interativo.GetCollectMessage();
    }
}
