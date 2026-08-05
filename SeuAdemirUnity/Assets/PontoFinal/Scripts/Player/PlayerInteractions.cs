using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System.Collections;

public class PlayerInteractions : MonoBehaviour
{
    [Header("Hay Cast")]
    [SerializeField] private float rayDistance = 2f; // Distância do raycast
    private Camera myCamera;
    private InputAction interactAction;
    private InputAction stopAction;
    private InputAction mouseLook;
    private ObjectInterativo currentInteraction;
    public UnityEvent StopMovimentation;
    public UnityEvent StartMovimentation;
    private bool canFinish = false;
    private Interativos currentInterativo;
    [SerializeField] int rotationSpeed;

    private Vector3 objOriginPosition = new Vector3();
    private Quaternion objOriginRotate = new Quaternion();
    [SerializeField] private Transform viewPoint;
    [SerializeField] public Extintor ExtintorScript;


    private bool isInteracting = false;
    void Start()
    {
        myCamera = Camera.main;
        interactAction = InputSystem.actions.FindAction("RotateInteract");
        stopAction = InputSystem.actions.FindAction("StopInteract");
        mouseLook = InputSystem.actions.FindAction("look");
    }

    // Update is called once per frame
    void Update()
    {
        CheckInteractions();
    }
    private void CheckInteractions() // Usa do RayCast para
    {
        if (isInteracting)
        {
            if (currentInteraction.GetInterativo().GetPegavel() && interactAction.IsPressed())
            {
                RotateObject();
            }
            if (canFinish && stopAction.WasPressedThisFrame())
            {
                FinishInteraction();
            }
            return;
        }
        RaycastHit hit;
        Vector3 originPoint = myCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f)); // Ponto de origem do raycast (centro da tela)
        if (Physics.Raycast(originPoint, myCamera.transform.forward, out hit, rayDistance)) // Se o raycast colidir com algum objeto
        {
            ObjectInterativo objectInterativo = hit.collider.GetComponent<ObjectInterativo>(); // Pega o script ObjectInterativo do objeto atingido
            if (objectInterativo != null) // Se o objeto atingido tiver o script ObjectInterativo
            {
                UIManager.Instance.ChangeInteract(true); // Ativa o cursor de interação
                if (interactAction.WasPressedThisFrame())
                {
                    Debug.Log("Clicou no objeto");
                    if (objectInterativo.GetMoving())
                    {
                        Debug.Log("Já esta movendo");
                        return;
                    }
                    StartInteraction(objectInterativo);
                }
            }else
            {
                UIManager.Instance.ChangeInteract(false); // Desativa o cursor de interação
            }
            
        }else
        {
            UIManager.Instance.ChangeInteract(false);
        }
        
    }
    private void StartInteraction(ObjectInterativo objeto)
    {
        Debug.Log("Começou interação");
        currentInteraction = objeto;
        currentInteraction.OnInteract.Invoke();
        //ExtintorScript.FollowPlayer();
        if (currentInteraction.GetInterativo() != null)
        {
            if (!currentInteraction.GetInterativo().GetCarregavel())
            {
                StopMovimentation.Invoke();
            }
            isInteracting = true;
            bool hasPreviousItem = false;
            for (int i = 0; i < currentInteraction.IntAnterioresLenght(); i++)
            {
                if(PlayerInventory.Instance.CheckItem(currentInteraction.GetIntAnteriores(i).GetItemRequirido()))
                {
                    Interact(currentInteraction.GetIntAnteriores(i).GetInterativoAtual());
                    currentInteraction.GetIntAnteriores(i).OnInteractAtual.Invoke();
                    hasPreviousItem = true;
                    break;
                }
            }
            if (hasPreviousItem)
            {
                return;
            }
            Interact(currentInteraction.GetInterativo());
            if (currentInteraction.GetInterativo().GetPegavel())
            {
                objOriginPosition = currentInteraction.transform.position;
                objOriginRotate = currentInteraction.transform.rotation;
                StartCoroutine(currentInteraction.MovingObject(viewPoint.position));
            }
        }
    }
    private void Interact(Interativos interativo)
    {
        Debug.Log("interagindo");
        currentInterativo = interativo;
        if (currentInterativo.GetImage() != null)
        {
            UIManager.Instance.SetInterativoImage(currentInterativo.GetImage(), true);
        }
        Invoke("CanFinish", 1f);
    }
    private void CanFinish()
    {
        Debug.Log("Pode finalizar interação");
        canFinish = true;
        if (currentInterativo.GetImage() == null && !currentInterativo.GetPegavel())
        {
            Debug.Log("Termino antecipado");
            FinishInteraction();
        }
    }
    private void FinishInteraction()
    {
        Debug.Log("Finalizou interação");
        canFinish = false;
        isInteracting = false;
        UIManager.Instance.SetInterativoImage(null, false);
        //ExtintorScript.ExitPlayer();
        if (currentInterativo.inventoryItem)
        {
            PlayerInventory.Instance.AddItem(currentInterativo);
            currentInteraction.OnCollectObjeto.Invoke();
        }
        if (currentInterativo.GetPegavel())
        {
            currentInteraction.transform.rotation = objOriginRotate;
            StartCoroutine(currentInteraction.MovingObject(objOriginPosition));
        }
        StartMovimentation.Invoke();
    }
    private void RotateObject()
    {
        Vector2 rotateLook = mouseLook.ReadValue<Vector2>();
        currentInteraction.transform.Rotate(myCamera.transform.right, -Mathf.Deg2Rad * rotateLook.y * rotationSpeed, Space.World);
        currentInteraction.transform.Rotate(myCamera.transform.up, -Mathf.Deg2Rad * rotateLook.x * rotationSpeed, Space.World);
    }

    // Tirar numeros mágicos
    // Trocar Moving par ao Objeto
    // Tirar o publica do Interativos
}
