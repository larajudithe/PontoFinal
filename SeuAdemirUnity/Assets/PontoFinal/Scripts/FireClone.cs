using UnityEngine;
using System.Collections;

public class FireClone : MonoBehaviour
{
    [SerializeField] float posicaoz;
    public GameObject originalObject;
    public Transform Fire;
    public Transform Fire2;
    Vector3 offset;
    [SerializeField] PlayerController PlayerControllerScript;
    GameObject clone;
    GameObject clone2;
    [SerializeField] private GameObject Puzzle;
    [SerializeField] float SomaPosicaoZ;
    [SerializeField] int SomaFogo;
    [SerializeField] int DiminuirFogo;
    [SerializeField] int fogo;

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
        posicaoz = posicaoz + SomaPosicaoZ;
        yield return new WaitForSeconds(15f);
        clone = Instantiate(originalObject, Fire.position - offset, originalObject.transform.rotation);
        clone2 = Instantiate(originalObject, Fire2.position - offset, originalObject.transform.rotation);
        fogo = fogo + SomaFogo;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tiro"))
        {
            PerderFogo();
        }
    }
    public void PerderFogo()
    {
        Debug.Log("fogo: " + fogo);
        fogo = fogo - DiminuirFogo;
        if (fogo == 0)
        {
            Destroy(clone);
            Destroy(clone2);
            Destroy(gameObject);
            Puzzle.SetActive(true);
        }
    }
    public void Ativar()
    {
        gameObject.SetActive(true);
    }
}
