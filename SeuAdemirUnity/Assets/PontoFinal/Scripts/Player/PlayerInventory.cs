using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private List<Interativos> inventarioInts = new(); // Lista de itens do inventário
    public static PlayerInventory Instance {get; private set;} // Singleton
    void Awake()
    {
        // Instanciamento do singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
       Instance = this;
    }
    public void AddItem(Interativos item) // Adicionar itens no inventário
    {
        if (inventarioInts.Contains(item)) // Verifica se o inventário já contem o item
        {
            Debug.Log("Item já está no invetário");
            return;
        }
        UIManager.Instance.SetItens(item, inventarioInts.Count); // Altera o texto do inventário para o nome do item (CollectMessage)
        inventarioInts.Add(item); // Adiciona o item na lista
    }
    public bool CheckItem(Interativos item) // Verifica se um item existe na lista
    {
        return inventarioInts.Contains(item);
    }
}
