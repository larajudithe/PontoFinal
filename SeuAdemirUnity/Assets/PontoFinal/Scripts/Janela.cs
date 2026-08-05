using UnityEngine;

public class Janela : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject objetoParaAtivar;
    [SerializeField] private string triggerName = "Interagir";

    private void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }
    public void Interagir()
    {
        if (animator != null)
        {
            animator.SetTrigger(triggerName);
        }
    }

    public void AtivarOutroObjeto()
    {
        if (objetoParaAtivar != null)
        {
            objetoParaAtivar.SetActive(true);
        }

    }

}