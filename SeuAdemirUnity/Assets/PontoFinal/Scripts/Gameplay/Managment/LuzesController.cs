using UnityEngine;

public class LuzesController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Light light;

    [SerializeField] private float minIntensity = 0.5f;
    [SerializeField] private float maxIntensity = 5f;
    [SerializeField] private float flickerSpeed = .1f;

    private void Start()
    {
        light = GetComponent<Light>();
        InvokeRepeating ("Flicker", 0f, flickerSpeed);
    }

    private void Flicker()
    {
        float randomIntensity = Random.Range(minIntensity, maxIntensity);
        light.intensity = randomIntensity;

    }
}
