using UnityEngine;
using UnityEngine.InputSystem;
using FMODUnity;


public class DragDrop : MonoBehaviour
{
    [Header("Referências")]
    [SerializeField] private RectTransform objectToDrag;
    [SerializeField] private RectTransform objectDragToPos;
    [SerializeField] private CanvasGroup dragCanvasGroup; // deixe VAZIO ou use um CanvasGroup na propria peca, nunca o do pai
    [SerializeField] private PuzzleManager puzzleManager;

    [Header("Configurações")]
    [SerializeField] private float dropDistance = 30f; // em pixels de tela
    [SerializeField] private bool fadeEnquantoArrasta = false;

    private Canvas canvas;
    private Camera uiCamera;
    private RectTransform dragParent;
    private Vector2 objectInitAnchoredPos;
    private Vector2 grabOffset;
    private bool isDragging;
    private bool isLocked;

    private InputAction mousePointer;


    void Awake()
    {
        mousePointer = InputSystem.actions.FindAction("position");
    }


    void Start()
    {
        canvas = GetComponentInParent<Canvas>();

        if (canvas != null && canvas.renderMode != RenderMode.ScreenSpaceOverlay)
        {
            uiCamera = canvas.worldCamera != null ? canvas.worldCamera : Camera.main;
        }

        if (objectToDrag != null)
        {
            dragParent = objectToDrag.parent as RectTransform;
            objectInitAnchoredPos = objectToDrag.anchoredPosition;
        }

        if (mousePointer == null)
        {
            Debug.LogError("DragDrop: action 'position' não encontrada no Input Actions.", this);
        }
    }


    // Opcional: ligue no Pointer Down. Se não ligar, o DragObject se vira sozinho.
    public void BeginDrag()
    {
        if (isLocked || objectToDrag == null || dragParent == null) return;
        if (!TryGetLocalPoint(out Vector2 localPoint)) return;

        grabOffset = objectToDrag.anchoredPosition - localPoint;
        isDragging = true;

        if (fadeEnquantoArrasta && dragCanvasGroup != null)
        {
            dragCanvasGroup.alpha = 0.6f;
            dragCanvasGroup.blocksRaycasts = false;
        }
    }


    // Ligue no evento Drag
    public void DragObject()
    {
        if (isLocked || objectToDrag == null || dragParent == null) return;

        // Se ninguem chamou BeginDrag, calcula o offset agora e segue o jogo.
        if (!isDragging)
        {
            BeginDrag();
            return;
        }

        if (!TryGetLocalPoint(out Vector2 localPoint)) return;

        objectToDrag.anchoredPosition = localPoint + grabOffset;
    }


    // Ligue no evento Pointer Up (ou End Drag)
    public void DropObjects()
    {
        if (isLocked || objectToDrag == null || objectDragToPos == null) return;

        isDragging = false;

        if (fadeEnquantoArrasta && dragCanvasGroup != null)
        {
            dragCanvasGroup.alpha = 1f;
            dragCanvasGroup.blocksRaycasts = true;
        }

        Vector2 dragScreen = RectTransformUtility.WorldToScreenPoint(uiCamera, objectToDrag.position);
        Vector2 targetScreen = RectTransformUtility.WorldToScreenPoint(uiCamera, objectDragToPos.position);
        float distance = Vector2.Distance(dragScreen, targetScreen);

        if (distance <= dropDistance)
        {
            isLocked = true;
            objectToDrag.position = objectDragToPos.position;
            objectToDrag.rotation = objectDragToPos.rotation;
            objectToDrag.localScale = objectDragToPos.localScale;


            if (puzzleManager != null)
            {
                puzzleManager.AdicionarPonto();
            }
        }
        else
        {
            objectToDrag.anchoredPosition = objectInitAnchoredPos;
        }
    }


    private bool TryGetLocalPoint(out Vector2 localPoint)
    {
        localPoint = Vector2.zero;

        if (mousePointer == null || dragParent == null) return false;

        Vector2 mouseScreenPosition = mousePointer.ReadValue<Vector2>();

        return RectTransformUtility.ScreenPointToLocalPointInRectangle(
            dragParent,
            mouseScreenPosition,
            uiCamera,
            out localPoint
        );
    }
}