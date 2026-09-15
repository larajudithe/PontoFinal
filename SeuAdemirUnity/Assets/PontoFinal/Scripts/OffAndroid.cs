using UnityEngine;

public class OffAndroid : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            gameObject.SetActive(false);
            Debug.Log("Desativa");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
