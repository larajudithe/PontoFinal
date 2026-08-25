using UnityEngine;

public class Tiro : MonoBehaviour
{
    [SerializeField] FireClone FireCloneScript;
    int fogo = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("fogo: " + fogo);
        if (other.gameObject.CompareTag("fogo"))
        {
            FireCloneScript.PerderFogo();
        }
    }
}
