using UnityEngine;
using UnityEngine.InputSystem;
using FMODUnity;

public class DragDrop : MonoBehaviour
{
    [Header("Referências")]
    [SerializeField] private RectTransform objectToDrag;
    [SerializeField] private RectTransform objectDragToPos;
    [SerializeField] private PuzzleManager puzzleManager; 
    [Header("Configurações")]
    [SerializeField] private float dropDistance = 30f;
    
    private Canvas canvas;
    private Camera mainCamera;
    private Vector2 objectInitAnchoredPos;
    private bool isLocked;

    void Start()
    {
        // encontra o Canvas pai automaticamente
        canvas = GetComponentInParent<Canvas>();
        
        if (canvas != null && canvas.renderMode != RenderMode.ScreenSpaceOverlay)
        {
            mainCamera = canvas.worldCamera != null ? canvas.worldCamera : Camera.main;
        }

        if (objectToDrag != null)
        {
            // salva a posicao inicial ancorada
            objectInitAnchoredPos = objectToDrag.anchoredPosition;
        }

        /*
        if (puzzleManager == null)
        {
            puzzleManager = FindObjectOfType<PuzzleManager>();
        }
        */
    }

    public void DragObject()
    {
        if (isLocked || objectToDrag == null || canvas == null) return;

        // pega a posição do ponteiro em pixels da tela
        Vector2 mouseScreenPosition = Pointer.current.position.ReadValue(); //MUDAR PARA INPUT MANAGER 

        // converte a posição da tela para a posição exata dentro do canvas
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            mouseScreenPosition,
            mainCamera,
            out Vector2 localPoint
        );

        // move o objeto na UI
        objectToDrag.anchoredPosition = localPoint;
    }

    public void DropObjects()
    {
        if (isLocked || objectToDrag == null || objectDragToPos == null) return;

        // calcula a distancia diretamente entre as posições ancoradas na UI
        float distance = Vector2.Distance(objectToDrag.anchoredPosition, objectDragToPos.anchoredPosition);

        if (distance <= dropDistance)
        {
            isLocked = true;
            // encaixa perfeitamente na posicao do alvo
            objectToDrag.anchoredPosition = objectDragToPos.anchoredPosition;

            // avisa o Gerenciador para somar 1 ponto
            if (puzzleManager != null)
            {
                puzzleManager.AdicionarPonto();
            }
        }
        else
        {
            // retorna para a posição inicial
            objectToDrag.anchoredPosition = objectInitAnchoredPos;
        }
    }

    //HAHHAHAHAHA FOI
}