using UnityEngine;
using UnityEngine.InputSystem;


public class DragDrop : MonoBehaviour
{
    [Header("Referências")]
    [SerializeField] private RectTransform objectToDrag;
    [SerializeField] private RectTransform objectDragToPos;
   
    [Header("Configurações")]
    [SerializeField] private float dropDistance = 30f;
   
    private Canvas canvas;
    private Camera mainCamera;
    private Vector2 objectInitAnchoredPos;
    private bool isLocked;


    void Start()
    {
        // Encontra o Canvas pai automaticamente
        canvas = GetComponentInParent<Canvas>();
       
        if (canvas != null && canvas.renderMode != RenderMode.ScreenSpaceOverlay)
        {
            mainCamera = canvas.worldCamera != null ? canvas.worldCamera : Camera.main;
        }
        


        if (objectToDrag != null)
        {
            // Salva a posição inicial ancorada (independe do tamanho/resolução da tela)
            objectInitAnchoredPos = objectToDrag.anchoredPosition;
        }
    }


    public void DragObject()
    {
        if (isLocked || objectToDrag == null || canvas == null) return;


        // pega a posicao do ponteiro em pixels da tela
        Vector2 mouseScreenPosition = Pointer.current.position.ReadValue();


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


        // calcula a distância diretamente entre as posições ancoradas na UI
        float distance = Vector2.Distance(objectToDrag.anchoredPosition, objectDragToPos.anchoredPosition);


        if (distance <= dropDistance)
        {
            isLocked = true;
            // encaixa perfeitamente na posição do alvo
            objectToDrag.anchoredPosition = objectDragToPos.anchoredPosition;
        }
        else
        {
            // retorna para a posição inicial
            objectToDrag.anchoredPosition = objectInitAnchoredPos;
        }
    }


}
