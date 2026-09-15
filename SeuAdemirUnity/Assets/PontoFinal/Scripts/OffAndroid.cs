using UnityEngine;

public class OffAndroid : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
