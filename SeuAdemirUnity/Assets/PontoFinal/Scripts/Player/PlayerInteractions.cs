using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System.Collections;

public class PlayerInteractions : MonoBehaviour
{
    [Header("Hay Cast")]
    [SerializeField] private float rayDistance = 2f; // Distância do raycast
    [SerializeField] private Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0.3f); // Ponto de origen do raycast
    [SerializeField] private Transform viewPoint;

    [Header("Input Actions")]
    private InputAction interactAction; // Interação (Botão esquerdo do mouse)
    private InputAction stopAction; // Parar interação (Botão direito do mouse)
    private InputAction mouseLook; // Movimentação do mouse

    [Header("Eventos")]
    public UnityEvent StartMovimentation; // Voltar a mover o player
    public UnityEvent StopMovimentation; // Parar de mover o player

    [Header("Interação")]
    private ObjectInterativo currentInteraction; // Script do objeto interagido
    private Interativos currentInterativo; // Scriptable Object do objeto interagido

    [Header("Movimentação/Rotação")]
    [SerializeField] int rotationSpeed; // Velocidade de rotação do objeto
    private Vector3 objOriginPosition = new Vector3(); // Posição original do objeto
    private Quaternion objOriginRotate = new Quaternion(); // Rotação original do objeto

    [Header("Avulsos")]
    private bool canFinish = false; // Pode terminar a alteração
    private Camera myCamera; // Camera
    [SerializeField] public Extintor ExtintorScript;
    [SerializeField] private AudioPlayer audioPlayer;


    private bool isInteracting = false;
    private void Awake()
    {
        audioPlayer = GetComponent<AudioPlayer>();
    }
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
    private void CheckInteractions() // Checa as interações
    {
        if (isInteracting) // Interrompe o método caso já esteja interagindo
        {
            if (currentInteraction.GetInterativo().GetPegavel() && interactAction.IsPressed()) // Gira o objeto (Objeto pegavel + botão esquerdo do mouse)
            {
                RotateObject();
            }
            if (canFinish && stopAction.WasPressedThisFrame()) // Finaliza a interação (Pode terminar + botão direito do mouse)
            {
                FinishInteraction();
            }
            return;
        }
        RaycastHit hit; // Raycast
        Vector3 originPoint = myCamera.ViewportToWorldPoint(rayOrigin); // Ponto de origem do raycast (centro da tela)
        if (Physics.Raycast(originPoint, myCamera.transform.forward, out hit, rayDistance)) // Se o raycast colidir com algum objeto
        {
            ObjectInterativo objectInterativo = hit.collider.GetComponent<ObjectInterativo>(); // Pega o script ObjectInterativo do objeto atingido
            if (objectInterativo != null) // Se o objeto atingido tiver o script ObjectInterativo
            {
                UIManager.Instance.ChangeInteract(true); // Ativa o cursor de interação
                if (interactAction.WasPressedThisFrame()) // Botão esquerdo do mouse
                {
                    //Debug.Log("Clicou no objeto");
                    if (objectInterativo.GetMoving()) // Verifica se o objeto já está em movimento
                    {
                        //Debug.Log("Já esta movendo");
                        return;
                    }
                    StartInteraction(objectInterativo); // Começa interação
                }
            }else
            {
                UIManager.Instance.ChangeInteract(false); // Desativa o cursor de interação
            }
            
        }else
        {
            UIManager.Instance.ChangeInteract(false); // Desativa o cursor de interação
        }
        
    }
    private void StartInteraction(ObjectInterativo objeto) // Inicia interação com o objeto
    {
        //Debug.Log("Começou interação");
        currentInteraction = objeto;
        currentInteraction.OnInteract.Invoke(); // Chama o evento de interação com o objeto
        // ExtintorScript.FollowPlayer();
        if (currentInteraction.GetInterativo() != null) // Verifica se o objeto tem um scriptable object
        {
            if (!currentInteraction.GetInterativo().GetCarregavel())
            {
                StopMovimentation.Invoke(); // Para a movimentação do jogador
            }
            isInteracting = true; // Ativa a interação
            bool hasPreviousItem = false; // Existe interações anteriores
            for (int i = 0; i < currentInteraction.IntAnterioresLenght(); i++) // Verifica todas as ações anteriores
            {
                if(PlayerInventory.Instance.CheckItem(currentInteraction.GetIntAnteriores(i).GetItemRequirido())) // Verifica se item para a interação está no inventário
                {
                    Interact(currentInteraction.GetIntAnteriores(i).GetInterativoAtual()); // Interage
                    currentInteraction.GetIntAnteriores(i).OnInteractAtual.Invoke(); // Evento de interação
                    hasPreviousItem = true;
                    break;
                }
            }
            if (hasPreviousItem) // Interrompe o código depois da primeira interação
            {
                return;
            }
            Interact(currentInteraction.GetInterativo()); // Interage
            if (currentInteraction.GetInterativo().GetPegavel()) // Objetos que podem ser segurados
            {
                objOriginPosition = currentInteraction.transform.position;
                objOriginRotate = currentInteraction.transform.rotation;
                StartCoroutine(currentInteraction.MovingObject(viewPoint.position)); // Move o objeto até o player
            }
        }
    }
    private void Interact(Interativos interativo) // interação com o objeto
    {
        //Debug.Log("interagindo");
        currentInterativo = interativo;
        if (currentInterativo.GetImage() != null) // Mostra a imagem do objeto no canvas
        {
            UIManager.Instance.SetInterativoImage(currentInterativo.GetImage(), true);
        }
        if (interativo.GetAudioDuration() > 0)
        {
            audioPlayer.PlayAudio(interativo.GetAudio());
        }
        UIManager.Instance.SetCaptions(interativo.GetTexto());
        Invoke("CanFinish", interativo.GetAudioDuration() + 0.5f); // Depois de um segundo pode terminar a interação
    }
    private void CanFinish()
    {
        if (!currentInterativo.GetStopInPuzzle())
        {
            //Debug.Log("Pode finalizar interação");
            canFinish = true;
            UIManager.Instance.SetEndInteractionImage(true);
            if (currentInterativo.GetImage() == null && !currentInterativo.GetPegavel()) // Caso o objeto não tenha imagem e nem seja seguravel, termina interação
            {
                //Debug.Log("Termino antecipado");
                FinishInteraction();
            }
            UIManager.Instance.SetCaptions("");
        }else
        {
            UIManager.Instance.SetCaptions("");
            Debug.Log("Puzzle");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            return;
        }
    }
    public void FinishInteraction() // Termina a interação
    {
        //Debug.Log("Finalizou interação");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        canFinish = false;
        isInteracting = false;
        UIManager.Instance.SetEndInteractionImage(false);
        UIManager.Instance.SetInterativoImage(null, false); // Desabilita a imagem do canvas
        // ExtintorScript.ExitPlayer();
        if (currentInterativo.GetInventoryItem()) // Coleta o item para o invenrário
        {
            PlayerInventory.Instance.AddItem(currentInterativo);
            currentInteraction.OnCollectObjeto.Invoke();
        }
        if (currentInterativo.GetPegavel()) // Solta o item
        {
            currentInteraction.transform.rotation = objOriginRotate;
            StartCoroutine(currentInteraction.MovingObject(objOriginPosition));
        }
        StartMovimentation.Invoke(); // Ativa a movimentação do player
    }
    private void RotateObject() // Rotaciona o objeto baseado nop mouse
    {
        Vector2 rotateLook = mouseLook.ReadValue<Vector2>();
        currentInteraction.transform.Rotate(myCamera.transform.right, -Mathf.Deg2Rad * rotateLook.y * rotationSpeed, Space.World);
        currentInteraction.transform.Rotate(myCamera.transform.up, -Mathf.Deg2Rad * rotateLook.x * rotationSpeed, Space.World);
    }

}
