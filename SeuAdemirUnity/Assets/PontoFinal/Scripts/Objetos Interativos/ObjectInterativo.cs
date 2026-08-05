using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class ObjectInterativo : MonoBehaviour
{
    [SerializeField] private Interativos interativo;
    private bool isMoving = false;
    public UnityEvent OnInteract;
    public UnityEvent OnCollectObjeto;
    [SerializeField] private InterativosAnteriores[] intAnteriores;
    [SerializeField] private float movimentationSpeed = 5;
    [SerializeField] private float movimentationTime = 1;
    public Interativos GetInterativo()
    {
        return interativo;
    }
    public bool GetMoving()
    {
        return isMoving;
    }
    public int IntAnterioresLenght()
    {
        return intAnteriores.Length;
    }
    public InterativosAnteriores GetIntAnteriores(int index)
    {
        return intAnteriores[index];
    }
    public IEnumerator MovingObject(Vector3 finalPosition)
    {
        Debug.Log("Movendo objeto");
        isMoving = true;
        float time = 0f;
        while (time < movimentationTime)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, finalPosition, time * movimentationSpeed);
            yield return null;
        }
        transform.position = finalPosition;
        isMoving = false;
    }
}
[System.Serializable]
public class InterativosAnteriores
{
    [SerializeField] Interativos itemRequirido;
    [SerializeField] Interativos interativoAtual;
    public UnityEvent OnInteractAtual;
    public Interativos GetItemRequirido()
    {
        return itemRequirido;
    }
    public Interativos GetInterativoAtual()
    {
        return interativoAtual;
    }
}


