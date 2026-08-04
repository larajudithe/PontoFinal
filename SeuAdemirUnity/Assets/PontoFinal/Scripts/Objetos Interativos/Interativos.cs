using UnityEngine;

[CreateAssetMenu(fileName = "Interativos", menuName = "Scriptable Objects/Interativos")]
public class Interativos : ScriptableObject
{
    public string texto;
    public bool pegavel;
    public bool carregavel;
    public AudioClip audio;
    public Sprite image;

    [Header("Inventario")]
    public bool inventoryItem;
    public string collectMessage;
}
