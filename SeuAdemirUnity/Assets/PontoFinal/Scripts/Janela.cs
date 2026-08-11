using UnityEngine;

public class Janela : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject objetoParaAtivar;
    [SerializeField] private string triggerName = "Interagir";
    [SerializeField] private float NHEEEUU;
    private bool jaFoiAtivado = false;
    

    private void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }
    public void Interagir()
    {
        // if (animator != null)
        // {
        //     animator.SetTrigger(triggerName);

        // }

        if (!jaFoiAtivado)
        {
            float time = 0;

          while (time < 1)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * NHEEEUU);
                time += Time.deltaTime;
            } 
        }
    }

    public void AtivarOutroObjeto()
    {
        if (objetoParaAtivar != null && !jaFoiAtivado)
        {
            objetoParaAtivar.SetActive(true);
            jaFoiAtivado = true;
           
        }

    }

}