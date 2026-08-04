/*using UnityEngine;
using UnityEngine.InputSystem;

public class DragDrop : MonoBehaviour
{
    [SerializeField] private GameObject objectToDrag; 
    [SerializeField] private GameObject ObjectDragToPos;
    [SerializeField] private float Dropistance;
    [SerializeField] private bool isLockead;
    Vector2 objectInitPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         objectInitPos = objectToDrag.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DragObject()
    {
        if (!isLockead)
        {
            objectToDrag.transform.position = Input.mousePosition; //INPUT ANTIGO

        }
    }
    public void DropObjects()
    {
        float Distance = Vector3.Distance(objectToDrag.transform.position, ObjectDragToPos.transform.position);
        if(Distance < Dropistance)
        {
            isLockead = true;
            objectToDrag.transform.position = ObjectDragToPos.transform.position;
        }
        else
        {
            objectToDrag.transform.position = objectInitPos;
        }
    }
}
*/

using UnityEngine;
using UnityEngine.InputSystem; 

public class DragDrop : MonoBehaviour
{
    [SerializeField] private GameObject objectToDrag; 
    [SerializeField] private GameObject ObjectDragToPos;
    [SerializeField] private float Dropistance;
    [SerializeField] private bool isLockead;
    
    private Camera mainCamera;
    Vector2 objectInitPos;

    void Start()
    {
        objectInitPos = objectToDrag.transform.position;
        // Captura a cAmera principal para converter a posição do mouse
        mainCamera = Camera.main; 
    }

    public void DragObject()
    //                                                  ERRO ERRO ERRO ERRO ERRO  

    //PROBLEMA AQUI: worldPosition é o problema, é necessario achar um jeito de converter ele de um jeito q ele fique usável pro canva.

    // SOLUÇÃO:  canvas usa Screen Space, que usa das coodernada "RectTransform ", entao se ainda quiser usar esse termo é necessario 
    // a conversão (ou da pra encontrar um outro termo que substitua ele)

    //FAZER SOLUÇÃO ASSIM Q POSSIVEL !!

    {
        if (!isLockead) 
        {
            //le a posição atual do mouse ou toque na tela
            Vector2 mouseScreenPosition = Pointer.current.position.ReadValue();

            // Converte a posição da tela para coordenadas do mundo do jogo (3D/2D)
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, 10f));
            
            // Mantém o Z original do objeto para evitar problemas de renderização
            worldPosition.z = objectToDrag.transform.position.z; 

            objectToDrag.transform.position = worldPosition;
        }
    }

    public void DropObjects()
    {
        float Distance = Vector3.Distance(objectToDrag.transform.position, ObjectDragToPos.transform.position);
        if(Distance < Dropistance)
        {
            isLockead = true;
            objectToDrag.transform.position = ObjectDragToPos.transform.position;
        }
        else
        {
            objectToDrag.transform.position = objectInitPos;
        }
    }
   
}

