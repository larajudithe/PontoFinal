using System.Collections;
using UnityEngine;

public class Janela : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject objetoParaAtivar;
    [SerializeField] private float NHEEEUU;
    [SerializeField] private Vector3 finalPosition;
    private bool jaFoiAtivado = false;

    public IEnumerator Interagir()
    {
        finalPosition = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 1);
        float time = 0;

        while (time < 1)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, finalPosition, time * NHEEEUU);
            yield return null;
        }
        transform.position = finalPosition;

    }

    public void AtivarOutroObjeto()
    {
        if (objetoParaAtivar != null && !jaFoiAtivado)
        {
            objetoParaAtivar.SetActive(true);
            StartCoroutine(Interagir());
            jaFoiAtivado = true;

        }

    }

}