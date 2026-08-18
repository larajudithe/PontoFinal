using UnityEngine;
using FMODUnity;
using UnityEditor.Events;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    [Header("Configuracoes")]
    [SerializeField] private int pontosTotais = 0;
    
    [Header("Telas / Canvases")]
    [SerializeField] private GameObject canvasAtual; 
    [SerializeField] private GameObject proximoQuebraCabeca; 
    [SerializeField] private GameObject canvasPrincipal; 

    [Header("Referencia de Interacao")]
    [SerializeField] private ObjectInterativo objetoInterativo;

    [Header("Recompensa :O")]
    [SerializeField] private GameObject prefabFicha; 
    [SerializeField] private Transform pontoDeSpawn;  

    [SerializeField] private EventReference somEncaixadp;

    public UnityEvent parardeGirar;


    public void AdicionarPonto()
    {
        pontosTotais++;
        RuntimeManager.PlayOneShot(somEncaixadp);
       // Debug.Log("Pontos atuais: " + pontosTotais);

        // quando fizer 4 pontos, muda para o proximo quebra-cabeca
        if (pontosTotais == 4)
        {
            MudarParaProximoQuebraCabeca();
        }
        // quando fizer 7 pontos, fecha o canvas/jogo
        else if (pontosTotais >= 7)
        {
            FecharCanvas();
            parardeGirar.Invoke();

        }
    }

    private void MudarParaProximoQuebraCabeca()
    {
       // Debug.Log("Mudando para o próximo quebra-cabeca!");
        
        if (canvasAtual != null)
            canvasAtual.SetActive(false); // desativa o primeiro quebra-cabeca

        if (proximoQuebraCabeca != null)
            proximoQuebraCabeca.SetActive(true); // ativa o segundo quebra-cabeca
    }

    private void FecharCanvas()
    {
        //Debug.Log("Fechando o Canvas!");

        if (canvasPrincipal != null)
        {
            canvasPrincipal.SetActive(false); // desativa o Canvas inteiro
        }
     /*   if (canvasPrincipalDoJogo != null)
        {
        canvasPrincipalDoJogo.SetActive(true);

        playerMovimento.enabled = true;
    }
    */

    if (objetoInterativo != null)
    {
        objetoInterativo.OnCollectObjeto.Invoke();
    }

    if (prefabFicha != null && pontoDeSpawn != null)
    {
    Instantiate(prefabFicha, pontoDeSpawn.position, pontoDeSpawn.rotation);
     }
     

    }
    
}