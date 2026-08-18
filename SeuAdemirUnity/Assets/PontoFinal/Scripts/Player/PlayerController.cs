using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Input Actions")]
    [SerializeField] private InputActionAsset inputActions; // InputMap
    private InputAction actionMove; // Ação move (x e y 0,1)
    private InputAction actionJump; // Ação Jump
    private InputAction actionExtintor; // Atira com o extintor

    [Header ("Movimento")]
    [SerializeField] private int playerSpeed; // Velocidade do jogador
    private Vector2 moveInput; // Movimento do jogador (-1, 0, 1
    private CharacterController characterController;
    private Vector3 forwardDirection; // Movimento pra frente e pra trás
    private Vector3 strafeDirection; // Movimentos laterais
    private Vector3 verticalDirection; // Movimento pra cima e para baixo
    private Vector3 finalDirection; // Soma dos vetores de movimento

    [Header("Pulo")]
    private float gravity; // Gravidade
    private float jumpSpeed; // Velocidade do pulo
    [SerializeField] private float jumpHeight; // Altura do pulo
    [SerializeField] private float jumpTime; // Tempo do pulo

    [Header("Camera")]
    private Camera myCamera;
    public GameObject Extintor;

    void Awake()
    {
        // Define as ações de input
        actionMove = InputSystem.actions.FindAction("move");
        actionJump = InputSystem.actions.FindAction("jump");
        actionExtintor = InputSystem.actions.FindAction("Extintor");
    }


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        myCamera = Camera.main;
        // Configuração do cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // Define gravidade e velocidade do pulo (Função da posição e velocidade MRUV)
        gravity = (-2 * jumpHeight) / Mathf.Pow(jumpTime, 2);
        jumpSpeed = (2 * jumpHeight) / jumpTime;
    }


    void Update()
    {
        moveInput = actionMove.ReadValue<Vector2>(); // Lê o input do jogador
        // Rotaciona o jogador para o angulo da câmera
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, myCamera.transform.eulerAngles.y, transform.eulerAngles.z);
        // Define a direção do movimento
        forwardDirection = moveInput.y * playerSpeed * transform.forward;
        strafeDirection = moveInput.x * playerSpeed * transform.right;
        if (characterController.isGrounded) // Verifica se o player esá no chão
        {
            verticalDirection = Vector3.down; // Impede o player de ganhar velocidade enquanto está parado
        }else
        {
            verticalDirection += gravity * Time.deltaTime * Vector3.up; // Ganha velocidade em queda livre (gravidade)
        }
        if (actionJump.WasPressedThisFrame() && characterController.isGrounded) // Pulo
        {
            verticalDirection = jumpSpeed * Vector3.up;
        }
         if (actionExtintor.IsPressed()) // Atirar
        {
            Extintor.SetActive(true); 

        }else
        {
            Extintor.SetActive(false); 
        }
        if (verticalDirection.y > 0 && (characterController.collisionFlags & CollisionFlags.Above) != 0) // Zero a velocidade quando player bate no teto
        {
            verticalDirection = Vector3.zero;
        }

        finalDirection = forwardDirection + strafeDirection + verticalDirection; // Soma os movimentos
        characterController.Move(finalDirection * Time.deltaTime); // Move o personagem
    }
}
