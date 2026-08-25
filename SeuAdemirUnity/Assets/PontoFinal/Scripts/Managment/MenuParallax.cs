using UnityEngine;
using UnityEngine.InputSystem;

public class MenuParallax : MonoBehaviour
{
    [SerializeField] private float offsetMultiplicator = 1f;
    [SerializeField] private float smoothTime = 0.3f;
    private Vector2 startPosition;
    private Vector3 velocity;
    [SerializeField] InputActionAsset inputActions;
    private InputAction mouseAction;

    void Awake()
    {
        mouseAction = inputActions.FindAction("UI/Point", true);

    }
    void Start()
    {
        startPosition = transform.position;
    }   

    // Update is called once per frame
    void Update()
    {
        //Vector2 mousePos = mouseAction.ReadValue<Vector2>();
        Vector2 mousePos = mouseAction.ReadValue<Vector2>();
        Vector2 offset = Camera.main.ScreenToViewportPoint(mousePos);
        transform.position = Vector3.SmoothDamp(transform.position, startPosition + (offset * offsetMultiplicator), ref velocity, smoothTime);
    }

    void OnEnable()
    {
        mouseAction.Enable();
    }

    void OnDisable()
    {
        mouseAction.Disable();
    }
}
