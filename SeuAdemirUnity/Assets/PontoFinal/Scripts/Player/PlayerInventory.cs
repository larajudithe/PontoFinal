using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private List<Interativos> inventarioInts = new();
    public static PlayerInventory Instance {get; private set;}
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
       Instance = this;
       DontDestroyOnLoad(gameObject);
    }
    public void AddItem(Interativos item)
    {
        if (inventarioInts.Contains(item))
        {
            Debug.Log("Item já está no invetário");
            return;
        }
        inventarioInts.Add(item);
        foreach (Interativos interativo in inventarioInts)
        {
            Debug.Log("Item no inventário: " + interativo.collectMessage);
        }
    }
    public bool CheckItem(Interativos item)
    {
        return inventarioInts.Contains(item);
    }
}
