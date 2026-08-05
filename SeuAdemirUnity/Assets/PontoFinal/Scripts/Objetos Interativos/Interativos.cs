using UnityEngine;

[CreateAssetMenu(fileName = "Interativos", menuName = "Scriptable Objects/Interativos")]
public class Interativos : ScriptableObject
{
    [Header("Características")]
    [SerializeField] private bool pegavel; // O item pode ser segurado
    [SerializeField] private bool carregavel; // O tiem pode ser carregado
    [SerializeField] private string texto; // Descrição narrada
    [SerializeField] private AudioClip audio; // Audio
    [SerializeField] private Sprite image; // Imagem que é mostrada na tela

    [Header("Inventario")]
    [SerializeField] private bool inventoryItem; // O item pode ser adicionado ao inventário
    [SerializeField] private string collectMessage; // Nome do item no inventário

    // Métodos para pegar as variáveis
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
