using UnityEngine;
using UnityEngine.InputSystem;

public class SkipCinematic : MonoBehaviour
{
    private InputAction skipCine;
     private void Awake()
    {
        skipCine = InputSystem.actions.FindAction("Skip");
    }
    // Update is called once per frame
    void Update()
    {
        if (skipCine.WasPressedThisFrame())
        {
            Debug.Log("Skip");
            CinematicManager.Instance.LoadGame();
        }
    }
}
