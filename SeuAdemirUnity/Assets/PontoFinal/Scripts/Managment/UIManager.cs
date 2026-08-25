using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; } // Singleton
    [Header("Inventário")]
    [SerializeField] private GameObject inventoryUI; // Inventario image
    [SerializeField] private InputAction openInventory; // Ação de abrir o inventário
    [SerializeField] private TextMeshProUGUI[] inventoryText; // Texto dos itens do inventário
    [Header("Images")]
    [SerializeField] private GameObject interactCursor; // Imagem que indíca que o personagem pode interagir
    [SerializeField] private GameObject finishInteractionImage;
    [SerializeField] private Image InterativoImage; // Objetos com imagem na tela
    [SerializeField] private TextMeshProUGUI captionsText;
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
        if (openInventory.WasPressedThisFrame()) // Abrir inventário (tecla E)
        {
            inventoryUI.SetActive(!inventoryUI.activeInHierarchy);
        }
    }
    public void ChangeInteract(bool stage) // Ativa/Desativa a imagem de interação
    {
        interactCursor.SetActive(stage);
    }
    public void SetInterativoImage(Sprite sprite, bool state) // Define a imagem de objeto interativo
    {
        InterativoImage.sprite = sprite;
        InterativoImage.enabled = state;
    }
    public void SetEndInteractionImage(bool state)
    {
        finishInteractionImage.SetActive(state);
    }
    public void SetItens(Interativos interativo, int index) // Define os textos dos itens do inventário
    {
        inventoryText[index].text = "-"+interativo.GetCollectMessage();
    }
    public void SetCaptions(string text)
    {
        captionsText.text = text;
    }
}
