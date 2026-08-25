using FMOD.Studio;
using FMODUnity;
using UnityEngine;

[CreateAssetMenu(fileName = "Interativos", menuName = "Scriptable Objects/Interativos")]
public class Interativos : ScriptableObject
{
    [Header("Características")]
    [SerializeField] private bool pegavel; // O item pode ser segurado
    [SerializeField] private bool carregavel; // O tiem pode ser carregado
    [SerializeField] private string texto; // Descrição narrada
    [SerializeField] private EventReference audioEvent; // Audio
    [SerializeField] private Sprite image; // Imagem que é mostrada na tela
    [SerializeField] private bool stopInPuzzle;
    [SerializeField] private float captionTime;
    private float audioDuration;

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
    public EventReference GetAudio()
    {
        //Debug.Log(audioEvent.IsNull);
        return audioEvent;
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
    public float GetAudioDuration()
    {
        if (!audioEvent.IsNull)
        {
            RuntimeManager.GetEventDescription(audioEvent).getLength(out int time);
            audioDuration = time / 1000f;
            Debug.Log(audioDuration);
        }else
        {
            audioDuration = 0f;
        }
        return audioDuration;
    }
    public bool GetStopInPuzzle()
    {
        return stopInPuzzle;
    }
    public float GetCaptionTime()
    {
        return captionTime;
    }
}
