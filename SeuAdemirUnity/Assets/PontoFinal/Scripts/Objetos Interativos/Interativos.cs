using UnityEngine;

[CreateAssetMenu(fileName = "Interativos", menuName = "Scriptable Objects/Interativos")]
public class Interativos : ScriptableObject
{
    [SerializeField] private string texto;
    [SerializeField] private bool pegavel;
    [SerializeField] private bool carregavel;
    [SerializeField] private AudioClip audio;
    [SerializeField] private Sprite image;

    [Header("Inventario")]
    public bool inventoryItem;
    public string collectMessage;

    public string GetTexto()
    {
        return texto;
    }
    public bool GetPegavel()
    {
        return pegavel;
    }
    public bool GetCarregavel()
    {
        return carregavel;
    }
    public AudioClip GetAudio()
    {
        return audio;
    }
    public Sprite GetImage()
    {
        return image;
    }
    public bool GetInventoryItem()
    {
        return inventoryItem;
    }
    public string GetCollectMessage()
    {
        return collectMessage;
    }
}
