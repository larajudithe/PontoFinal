using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Events;

public class Ignition : MonoBehaviour
{
    [Header("Progress")]
    [SerializeField] private GameObject progressIgnition;
    [SerializeField] private float ativeProgress;
    [SerializeField] private float ativeMaxTime;
    [SerializeField] private float passiveProgress;
    [SerializeField] private float passiveMaxTime;
    private float ativeTime = 0;
    private float passiveTime = 0;
    [Header("Goal")]
    [SerializeField] private float goalMin = 0.7f;
    [SerializeField] private float goalMax = 0.75f;
    private InputAction interAction;
    private bool startIgnition = false;
    public UnityEvent OnPuzzleComplete;
    [SerializeField] private Image progressIgnitionImage;

    void Awake()
    {
        interAction = InputSystem.actions.FindAction("Attack");
    }
    private void Start()
    {
        //progressIgnitionImage = GetComponent<Image>();
        Debug.Log(progressIgnitionImage.fillAmount);
    }
    void Update()
    {
        if (startIgnition && interAction.IsPressed())
        {
            //Debug.Log("Ignition");
            Debug.Log(progressIgnitionImage.fillAmount);
            passiveTime += Time.deltaTime;
            if (passiveTime >= passiveMaxTime)
            {
                if (progressIgnitionImage.fillAmount > passiveProgress)
                {
                    progressIgnitionImage.fillAmount -= passiveProgress;
                }
                passiveTime = 0;
            }
            ativeTime += Time.deltaTime;
            if (ativeTime >= ativeMaxTime)
            {
                progressIgnitionImage.fillAmount += ativeProgress;
                /*if (progressIgnitionImage.fillAmount > 1)
                {
                    progressIgnitionImage.fillAmount = 1;
                }*/
                ativeTime = 0;
            }
        }
        if (startIgnition && interAction.WasReleasedThisFrame())
        {
            if (progressIgnitionImage.fillAmount > goalMin && progressIgnitionImage.fillAmount < goalMax)
            {
                Debug.Log("Hey bro");
                OnPuzzleComplete.Invoke();
            }
            progressIgnition.SetActive(false);
            progressIgnitionImage.fillAmount = 0f;
            startIgnition = false;
            //Debug.Log("Stop Ignition");
        }
    }
    public void StartIgnition()
    {
        //Debug.Log("Start Ignition");
        startIgnition = true;
        progressIgnitionImage.fillAmount = 0f;
        progressIgnition.SetActive(true);
    }
}
