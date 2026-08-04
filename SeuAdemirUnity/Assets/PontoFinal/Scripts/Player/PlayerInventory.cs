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
        UIManager.Instance.SetItens(item, inventarioInts.Count);
        inventarioInts.Add(item);
    }
    public bool CheckItem(Interativos item)
    {
        return inventarioInts.Contains(item);
    }
}
