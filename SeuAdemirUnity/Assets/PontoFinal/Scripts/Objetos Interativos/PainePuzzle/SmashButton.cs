using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Events;

public class SmashButton : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private int acressValue;
    [SerializeField] private float timeIntervalo;
    [SerializeField] private Transform chapaTransform;
    public UnityEvent OnPuzzleCompleted;

    private float timer;
    private InputAction spaceClick;
    void Awake()
    {
        spaceClick = InputSystem.actions.FindAction("jump");
    }
    private void Start()
    {
        timer = timeIntervalo;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && slider.value > 1)
        {
            slider.value--;
            timer = timeIntervalo;
        }
        if (spaceClick.WasPressedThisFrame())
        {
            slider.value += acressValue;
        }
        if (slider.value >= (slider.maxValue - acressValue*2))
        {
            Debug.Log("Puzzle completed!");
            OnPuzzleCompleted.Invoke();
        }
        chapaTransform.rotation = Quaternion.Euler(-slider.value/100, chapaTransform.rotation.y, chapaTransform.rotation.z);
        Debug.Log(-slider.value/100);
    }
}
