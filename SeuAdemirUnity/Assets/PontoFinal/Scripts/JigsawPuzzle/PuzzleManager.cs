using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    [Header("Painel Principal do Puzzle")]
    //[Tooltip("Arraste aqui o GameObject raiz do Canvas/Painel do quebra-cabeça")]
    [SerializeField] private GameObject puzzleCanvasGroup;

    [Header("Fases do Quebra-Cabeça")]
    //Grupo que contém as peças e slots da FASE 1 (Primeira foto)")]
    [SerializeField] private GameObject fase1Group;

    //Grupo que contém as peças e slots da FASE 2 (Segunda foto)")]
    [SerializeField] private GameObject fase2Group;

    [Header("Eventos de Conclusão")]
    [SerializeField] private UnityEvent OnFase1Concluida;
    [SerializeField] private UnityEvent OnPuzzleFinalizado;

    private int pontuacaoAtual = 0;
    private bool fotoItemColetado = false;

    void Start()
    {
        // esconde o puzzle 
        if (puzzleCanvasGroup != null)
        {
            puzzleCanvasGroup.SetActive(false);
        }

        //prepara as fases internas para quando o painel for aberto
        if (fase1Group != null) fase1Group.SetActive(true);
        if (fase2Group != null) fase2Group.SetActive(false);

        // grante o estado inicial correto
        if (fase1Group != null) fase1Group.SetActive(true);
        if (fase2Group != null) fase2Group.SetActive(false);
        {
            pontuacaoAtual++;
            Debug.Log("Pontuação do Puzzle: " + pontuacaoAtual);

            ChecarProgresso();
        }
    }

    private void ChecarProgresso()
    {
        if (pontuacaoAtual == 4)
        {
            ConcluirFase1();
        }
        else if (pontuacaoAtual >= 8)
        {
            ConcluirPuzzleGlobal();
        }

    }

    private void ConcluirFase1()
    {
        //     Debug.Log("FOI FINALMENTE PRA FASE 2  ");

        // desativa os slots e peças antigos e ativa o novo grupo de slots e peças
        if (fase1Group != null) fase1Group.SetActive(false);
        if (fase2Group != null) fase2Group.SetActive(true);

        OnFase1Concluida?.Invoke();
    }

    private void ConcluirPuzzleGlobal()
    {
        Debug.Log("Quebra-cabeça concluído com 8 pontos!");

        OnPuzzleFinalizado?.Invoke();

        // - para dajr da twla od canvas      
        /*
             if (puzzleCanvasGroup != null)
             {
                 puzzleCanvasGroup.SetActive(false);
             }
             */
    }

    //  {
    /*
    if (puzzleCanvasGroup != null)
    {
        puzzleCanvasGroup.SetActive(false);
    }
    */
    // }
}
