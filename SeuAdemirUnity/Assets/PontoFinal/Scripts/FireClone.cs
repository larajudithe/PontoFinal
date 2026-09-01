using UnityEngine;
using System.Collections;

public class FireClone : MonoBehaviour
{
    int posicaoz = 1;
    public GameObject originalObject;
    public Transform Fire;
    public Transform Fire2;
    Vector3 offset;
    [SerializeField] PlayerController PlayerControllerScript;
    GameObject clone;
    GameObject clone2;
    int fogo = 7;

    void Start()
    {
        // Clones the object at a specific position with its default rotation
        StartCoroutine(ClonarFogo());
        offset = new Vector3(0f, 0f, posicaoz);
    }
    void Update()
    {

    }
    IEnumerator ClonarFogo()
    {
        posicaoz += 1;
        yield return new WaitForSeconds(20f);
        clone = Instantiate(originalObject, Fire.position - offset, originalObject.transform.rotation);
        clone2 = Instantiate(originalObject, Fire2.position - offset, originalObject.transform.rotation);
        fogo += 7;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerControllerScript.PerderVida();
        }
        if (other.CompareTag("Tiro"))
        {
            PerderFogo();
        }
    }
    public void PerderFogo()
    {
        Debug.Log("fogo: " + fogo);
        fogo -= 1;
        if (fogo == 0)
        {
            Destroy(clone);
            Destroy(clone2);
            Destroy(gameObject);
        }
    }
    public void Ativar()
    {
        gameObject.SetActive(true);
    }
}
