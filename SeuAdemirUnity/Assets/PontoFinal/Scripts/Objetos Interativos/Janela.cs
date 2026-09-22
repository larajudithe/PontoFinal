using System.Collections;
using UnityEngine;

public class Janela : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject objetoParaAtivar;
    [SerializeField] private float velocidade;
    private Vector3 finalPosition;
    [SerializeField] private float sidePositionsZ;
    private bool jaFoiAtivado = false;

    public IEnumerator Interagir()
    {

        if (UIManager.Instance != null)
        {
            UIManager.Instance.SetCaptions("Feche as Janelas e colete os bilhetes");
        }

        finalPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + sidePositionsZ);
        float time = 0;

        while (time < 1)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, finalPosition, time * velocidade);
            yield return null;
        }
        transform.position = finalPosition;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.SetCaptions("Veja seu inventario");
        }

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