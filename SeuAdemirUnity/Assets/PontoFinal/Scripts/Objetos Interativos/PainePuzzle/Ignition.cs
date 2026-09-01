using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Events;
using FMODUnity;

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
    [SerializeField] private float goalMin;
    [SerializeField] private float goalMax;
    [SerializeField] private GameObject goalImage;
    private InputAction interAction;
    private bool startIgnition = false;
    public UnityEvent OnPuzzleComplete;
    [SerializeField] private Image progressIgnitionImage;
    private StudioEventEmitter ignitionSound;

    void Awake()
    {
        interAction = InputSystem.actions.FindAction("Attack");
    }
    private void Start()
    {
        //progressIgnitionImage = GetComponent<Image>();
        Debug.Log(progressIgnitionImage.fillAmount);
        goalImage.transform.rotation = Quaternion.Euler(goalImage.transform.rotation.x, goalImage.transform.rotation.y, 360 * goalMin);
        goalImage.GetComponent<Image>().fillAmount = goalMax - goalMin;
        ignitionSound = GetComponent<StudioEventEmitter>();
    }
    void Update()
    {
        if (startIgnition && interAction.IsPressed())
        {
            //Debug.Log("Ignition");
            Debug.Log(progressIgnitionImage.fillAmount);
            //passiveTime += Time.deltaTime;
            progressIgnitionImage.fillAmount -= passiveProgress * Time.deltaTime;
            //passiveTime -= passiveMaxTime;
            ativeTime += Time.deltaTime;
            if (ativeTime >= ativeMaxTime)
            {
                progressIgnitionImage.fillAmount += ativeProgress;
                ativeTime -= ativeMaxTime;
                ignitionSound.Stop();
                ignitionSound.Play();
            }
        }
        if (startIgnition && interAction.WasReleasedThisFrame())
        {
            if (progressIgnitionImage.fillAmount > goalMin && progressIgnitionImage.fillAmount < goalMax)
            {
                //Debug.Log("Hey bro");
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
