using UnityEngine;
using UnityEngine.Events;

public class Parafusos : MonoBehaviour
{
    private int unscrewing = 0;
    private Animator animator;
    public UnityEvent OnDesparafusado;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("Screws", unscrewing);
    }
    public void Screw()
    {
        if (unscrewing < 3)
        {
            unscrewing++;
        }else
        {
            OnDesparafusado.Invoke();
        }
    }
}
