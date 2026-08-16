using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [Header("Configurações")]
    [SerializeField] private int pontosTotais = 0;
    
    [Header("Telas / Canvases")]
    [SerializeField] private GameObject canvasAtual; // o canvas ou painel do jogo atual
    [SerializeField] private GameObject proximoQuebraCabeca; // objeto/Painel do proximo quebra-cabeca
    [SerializeField] private GameObject canvasPrincipal; // o Canvas geral que vai fechar ao chegar em 8

    public void AdicionarPonto()
    {
        pontosTotais++;
        Debug.Log("Pontos atuais: " + pontosTotais);

        // quando fizer 4 pontos, muda para o proximo quebra-cabeca
        if (pontosTotais == 4)
        {
            MudarParaProximoQuebraCabeca();
        }
        // quando fizer 8 pontos, fecha o canvas/jogo
        else if (pontosTotais >= 8)
        {
            FecharCanvas();
        }
    }

    private void MudarParaProximoQuebraCabeca()
    {
        Debug.Log("Mudando para o próximo quebra-cabeca!");
        
        if (canvasAtual != null)
            canvasAtual.SetActive(false); // desativa o primeiro quebra-cabeca

        if (proximoQuebraCabeca != null)
            proximoQuebraCabeca.SetActive(true); // ativa o segundo quebra-cabeca
    }

    private void FecharCanvas()
    {
        Debug.Log("Fechando o Canvas!");

        if (canvasPrincipal != null)
        {
            canvasPrincipal.SetActive(false); // desativa o Canvas inteiro
        }
    }
}