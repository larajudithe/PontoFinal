using FMODUnity;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    private StudioEventEmitter eventEmitter;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        eventEmitter = GetComponentInChildren<StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAudio(EventReference evento)
    {
        Debug.Log(eventEmitter);
        eventEmitter.EventReference = evento;
        eventEmitter.Play();
    }
}
