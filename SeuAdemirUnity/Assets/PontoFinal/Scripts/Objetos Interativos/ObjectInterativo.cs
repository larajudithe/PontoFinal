using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class ObjectInterativo : MonoBehaviour
{
    [Header("Interações")]
    [SerializeField] private Interativos interativo; // Scriptable object do item
    [SerializeField] private InterativosAnteriores[] intAnteriores; // Interações prévias

    [Header("Eventos")]
    public UnityEvent OnInteract; // Eveneto de interação
    public UnityEvent OnCollectObjeto; // Evento de coleta do item

    [Header("Movimentação")]
    private bool isMoving = false; // Está se movendo
    [SerializeField] private float movimentationSpeed = 5;
    [SerializeField] private float movimentationTime = 1;

    // Métodos para pegar o valor das variáveis
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
    public IEnumerator MovingObject(Vector3 finalPosition) // Movimentação do objeto
    {
        //Debug.Log("Movendo objeto");
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
public class InterativosAnteriores // Interação prévia de um objeto
{
    [SerializeField] private Interativos[] itemRequirido; // Item necessário para iniciar interação
    [SerializeField] private Interativos interativoAtual; // Interação do item
    public UnityEvent OnInteractAtual; // Evento de interação do item
    // Métodos para pegar as varáveis
    public Interativos[] GetItemRequirido()
    {
        Debug.Log("Pedinfo ityem "+itemRequirido);
        return itemRequirido;
    }
    public Interativos GetInterativoAtual()
    {
        Debug.Log("Funcinando item");
        return interativoAtual;
    }
}


