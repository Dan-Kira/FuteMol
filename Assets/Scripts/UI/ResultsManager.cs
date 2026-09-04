using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultsManager : MonoBehaviour
{
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject defeatPanel;

    [SerializeField] private Image[] estrelasVitoria;

    [SerializeField] private TextMeshProUGUI textoTempo;
    [SerializeField] private TextMeshProUGUI textoMelhorTempo;

    private void Awake()
    {
        if (victoryPanel != null)
        {
            estrelasVitoria = new Image[3];
            estrelasVitoria[0] = victoryPanel.transform.Find("Star")?.GetComponent<Image>();
            estrelasVitoria[1] = victoryPanel.transform.Find("Star (1)")?.GetComponent<Image>();
            estrelasVitoria[2] = victoryPanel.transform.Find("Star (2)")?.GetComponent<Image>();

            victoryPanel.SetActive(false);
        }

        if (defeatPanel != null) 
        {
            defeatPanel.SetActive(false);
        }

        Time.timeScale = 1f;
    }

    private void Start()
    {
        Debug.Log("===== RESULTS MANAGER START =====");

        Debug.Log($"VictoryPanel: {victoryPanel}");

        for (int i = 0; i < estrelasVitoria.Length; i++)
        {
            Debug.Log($"Star {i}: {estrelasVitoria[i]}");
        }
    }


    public void Victory(int stars, float tempoAtual, float melhorTempo)
    {
        if (victoryPanel != null) victoryPanel.SetActive(true);
        Time.timeScale = 0f;

        if (estrelasVitoria != null)
        {
            for (int i = 0; i < estrelasVitoria.Length; i++)
            {
                if (estrelasVitoria[i] != null)
                {
                    estrelasVitoria[i].color = (i < stars) ? Color.white : Color.black;
                }
            }
        }

        if (textoTempo != null)
            textoTempo.text = $"Tempo: {tempoAtual:F2}s";

        if (textoMelhorTempo != null)
        {
            if (melhorTempo < 0 || melhorTempo == float.MaxValue) 
                textoMelhorTempo.text = $"Melhor tempo: {tempoAtual:F2}s";
            else 
                textoMelhorTempo.text = $"Melhor tempo: {melhorTempo:F2}s";
        }
    }

    public void Defeat()
    {
        if (defeatPanel != null) defeatPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ContinuarFases()
    {
        Time.timeScale = 1f;
        ChallengeChooser.Instance.CarregarProximaFase();
    }

    public void TentarNovamente()
    {
        Time.timeScale = 1f;
        if (victoryPanel != null) victoryPanel.SetActive(false);
        if (defeatPanel != null) defeatPanel.SetActive(false);

        ChallengeManager.Instance.ResetarSimulacao(zerarTempo: false);
    }

    public void ReiniciarFase()
    {
        Time.timeScale = 1f;
        if (victoryPanel != null) victoryPanel.SetActive(false);
        if (defeatPanel != null) defeatPanel.SetActive(false);

        ChallengeManager.Instance.ResetarSimulacao(zerarTempo: true);
    }
}