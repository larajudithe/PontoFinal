using UnityEngine;

public class Extintor : MonoBehaviour
{
    [SerializeField] FireClone FireCloneScript;
    public Transform player;
    Vector3 offset;
    bool seguir = false;
    // // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("seguir " + seguir);
        offset = new Vector3(0.1f, -0.8f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(seguir==true)
        {
        transform.position = player.transform.position + offset;
        }

    }
    public void StartFollow()
    {
        FireCloneScript.Ativar();
        seguir = true;
    }
}
