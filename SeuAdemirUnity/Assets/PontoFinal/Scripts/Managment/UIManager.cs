using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField] private GameObject interactCursor;
    [SerializeField] private Image InterativoImage;
    void Start()
    {
        
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    
    void Update()
    {
        
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
