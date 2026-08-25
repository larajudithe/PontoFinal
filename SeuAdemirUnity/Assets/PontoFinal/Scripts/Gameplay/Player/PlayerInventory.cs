using UnityEngine;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
//using System.Diagnostics;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] Extintor ExtintorScript;
    private List<Interativos> inventarioInts = new(); // Lista de itens do inventário
    public static PlayerInventory Instance { get; private set; } // Singleton
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
    public void AddInvisibleItem(Interativos item)
    {
        inventarioInts.Add(item);
    }
    public bool CheckItem(Interativos[] item) // Verifica se um item existe na lista
    {
        foreach (Interativos index in item)
        {
            Debug.Log("Verificando " + index);
            if (!inventarioInts.Contains(index))
            {
                Debug.Log("Não contem " + index);
                return false;
            }
            else
            {
                ExtintorScript.Ativar1();
            }
        }
        return true;
    }
}
