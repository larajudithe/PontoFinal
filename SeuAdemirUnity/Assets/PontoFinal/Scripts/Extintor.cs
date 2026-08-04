using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Extintor : MonoBehaviour
{
    public Transform Player;
    Vector3 offset = new Vector3(-2f, 0f, -2f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FollowPlayer()
    {
        transform.position = Player.position + offset;
    }
}
