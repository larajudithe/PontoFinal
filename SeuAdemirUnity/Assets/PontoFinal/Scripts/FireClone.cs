using UnityEngine;
using System.Collections;

public class FireClone : MonoBehaviour
{
    float posicaoz = 2.04f;
    public GameObject originalObject;
    private Vector3 spawnPosition;

    void Start()
    {
        // Clones the object at a specific position with its default rotation
        StartCoroutine(ClonarFogo());
    }
    void Update()
    {
        
    }
    IEnumerator ClonarFogo()
    {
        posicaoz += 1f;
        yield return new WaitForSeconds(5f);
        GameObject clone = Instantiate(originalObject, spawnPosition = new Vector3(-9.621f, 1.545f, posicaoz), originalObject.transform.rotation);
        GameObject clone2 = Instantiate(originalObject, spawnPosition = new Vector3(-11.634f, 1.545f, posicaoz), originalObject.transform.rotation);
        Debug.Log(posicaoz);
    }
}
