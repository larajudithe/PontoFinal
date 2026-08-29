using UnityEngine;

public class Extintor : MonoBehaviour
{
    [SerializeField] FireClone FireCloneScript;
    public Transform player;
    Vector3 offset;
    bool seguir = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = new Vector3(0.5f, 0f, -0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(seguir==true)
        {
        transform.position = player.transform.position + offset;
        }
    }
    public void FollowPlayer()
    {
        seguir = true;
        FireCloneScript.Ativar();
    }
}
