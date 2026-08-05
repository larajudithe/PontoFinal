using UnityEngine;

public class Janela : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   [SerializeField] private Animator animator;
    
    // Nome do parâmetro exatamente como criado no Animator
    private string triggerName = "Interagir";

    private void Awake()
    {
        // Caso o Animator esteja no próprio GameObject e não tenha sido arrastado no Inspector
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    // Chame este método onde a sua lógica de interação já é executada
    public void Interagir()
    {
        if (animator != null)
        {
            animator.SetTrigger(triggerName);
        }
    }

}
