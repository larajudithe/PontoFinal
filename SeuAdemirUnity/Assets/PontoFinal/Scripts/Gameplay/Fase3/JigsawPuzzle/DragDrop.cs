using UnityEngine;
using UnityEngine.InputSystem;
using FMODUnity;

public class DragDrop : MonoBehaviour
{
    [Header("referencias")]
    [SerializeField] private RectTransform objectToDrag;
    [SerializeField] private RectTransform objectDragToPos;
    [SerializeField] private PuzzleManager puzzleManager; 
    [Header("configuracoes")]
    [SerializeField] private float dropDistance = 30f;
    [Header("input system")]
    [SerializeField] private InputActionReference pointerPositionAction; 
    [SerializeField] private InputActionReference clickAction; 

    private Canvas canvas;
    private Camera mainCamera;
    private Vector2 objectInitAnchoredPos;
    private bool isLocked;
    private bool isDragging;

    void Start()
    {
        // encontra o canvas pai automaticamente
        canvas = GetComponentInParent<Canvas>();
        
        if (canvas != null && canvas.renderMode != RenderMode.ScreenSpaceOverlay)
        {
            mainCamera = canvas.worldCamera != null ? canvas.worldCamera : Camera.main;
        }

        // Se você esqueceu de arrastar ou se o Unity bugou a referência, 
        // ele pega o RectTransform deste próprio objeto automaticamente!
        if (objectToDrag == null)
        {
            objectToDrag = GetComponent<RectTransform>();
        }

        if (objectToDrag != null)
        {
            // salva a posicao inicial ancorada
            objectInitAnchoredPos = objectToDrag.anchoredPosition;
        }

    }

    void OnEnable()
    {
        // ativa e escuta os inputs do mapa de acoes
        if (pointerPositionAction != null) pointerPositionAction.action.Enable();
        if (clickAction != null)
        {
            clickAction.action.Enable();
            clickAction.action.performed += OnClickPerformed;
            clickAction.action.canceled += OnClickCanceled;
        }
    }

    void OnDisable()
    {
        // desativa para evitar vazamento de memoria ou erros
        if (pointerPositionAction != null) pointerPositionAction.action.Disable();
        if (clickAction != null)
        {
            clickAction.action.Disable();
            clickAction.action.performed -= OnClickPerformed;
            clickAction.action.canceled -= OnClickCanceled;
        }
    }

    private void OnClickPerformed(InputAction.CallbackContext context)
    {
        // aqui voce pode checar se clicou em cima do objeto antes de comecar a arrastar
        isDragging = true;
    }

    private void OnClickCanceled(InputAction.CallbackContext context)
    {
        if (isDragging)
        {
            isDragging = false;
            DropObjects();
        }
    }

    void Update()
    {
        if (isDragging)
        {
            DragObject();
        }
    }

    public void DragObject()
    {
        if (isLocked || objectToDrag == null || canvas == null || pointerPositionAction == null) return;

        // pega a posicao diretamente do input action configurado no inspector
        Vector2 mouseScreenPosition = pointerPositionAction.action.ReadValue<Vector2>();

        // converte a posicao da tela para a posicao exata dentro do canvas
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            mouseScreenPosition,
            mainCamera,
            out Vector2 localPoint
        );

        // move o objeto na ui
        objectToDrag.anchoredPosition = localPoint;
    }

    public void DropObjects()
    {
        if (isLocked || objectToDrag == null || objectDragToPos == null) return;

        // calcula a distancia diretamente entre as posicoes ancoradas na ui
        float distance = Vector2.Distance(objectToDrag.anchoredPosition, objectDragToPos.anchoredPosition);

        if (distance <= dropDistance)
        {
            isLocked = true;
            // encaixa perfeitamente na posicao do alvo
            objectToDrag.anchoredPosition = objectDragToPos.anchoredPosition;

            // avisa o gerenciador para somar 1 ponto
            if (puzzleManager != null)
            {
                puzzleManager.AdicionarPonto();
            }
        }
        else
        {
            // retorna para a posicao inicial
            objectToDrag.anchoredPosition = objectInitAnchoredPos;
        }
    }
}