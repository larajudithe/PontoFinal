using UnityEngine;
using UnityEngine.InputSystem;

public class PauseActions : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;
    [SerializeField] private GameObject playerCanvas;
    [SerializeField] private GameObject pauseCanvas;
    private InputAction pausePlayer;
    private InputAction pauseMenu;
    void Awake()
    {
        pausePlayer = InputSystem.actions.FindAction("Player/PauseOn");
        pauseMenu = InputSystem.actions.FindAction("UI/PauseOff");
    }

    // Update is called once per frame
    void Update()
    {
        if (pausePlayer.WasPressedThisFrame())
        {
            inputActions.FindActionMap("Player").Disable();
            inputActions.FindActionMap("UI").Enable();
            playerCanvas.SetActive(false);
            pauseCanvas.SetActive(true);
        }
        else if (pauseMenu.WasPressedThisFrame())
        {
            inputActions.FindActionMap("UI").Disable();
            inputActions.FindActionMap("Player").Enable();
            pauseCanvas.SetActive(false);
            playerCanvas.SetActive(true);
        }
    }
}
