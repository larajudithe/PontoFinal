using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.Events;

public class ObjectInterativo : MonoBehaviour
{
    [SerializeField] private Interativos interativo;
    private bool isMoving = false;
    public UnityEvent OnInteract;
    [SerializeField] private InterativosAnteriores[] intAnteriores;

    // Update is called once per frame
    void Update()
    {
        
    }
    public Interativos GetInterativo()
    {
        return interativo;
    }
    public void ChangeMoving(bool state)
    {
        isMoving = state;
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
