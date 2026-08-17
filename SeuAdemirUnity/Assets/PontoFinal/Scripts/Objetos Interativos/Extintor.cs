using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Extintor : MonoBehaviour
{
    public Transform Player;
    Vector3 offset = new Vector3(0f, 0f, -2f);
    private bool interacao = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(interacao==true)
        {
        transform.position = Player.position + offset;
        }
    }
    public void FollowPlayer()
    {
        interacao = true;
    }
    public void ExitPlayer()
    {
        interacao = false;
    }
}
