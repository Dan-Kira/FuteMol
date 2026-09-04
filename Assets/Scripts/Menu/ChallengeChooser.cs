using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ChallengeChooser : MonoBehaviour
{
    public static ChallengeChooser Instance;

    [Header("Configurações")]
    [SerializeField] private string nomeCenaDoJogo = "GameplayScene";
    [SerializeField] private ChallengeData[] todasAsFases;

    [Header("UI")]
    [SerializeField] private GameObject botaoFasePrefab;
    [SerializeField] private Transform painelDeBotoes;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Instance.painelDeBotoes = this.painelDeBotoes;
            Instance.botaoFasePrefab = this.botaoFasePrefab;
            
            Instance.GenerateButtons();

            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        GenerateButtons();
    }

    public void GenerateButtons()
    {
        if (painelDeBotoes == null || botaoFasePrefab == null) return;

        foreach (Transform child in painelDeBotoes)
        {
            Destroy(child.gameObject);
        }

        int levelDesbloqueado = 0;
        if (DataPersistence.Instance != null && DataPersistence.Instance.currentSave != null)
        {
            levelDesbloqueado = DataPersistence.Instance.currentSave.highestLevelUnlocked;
        }

        for (int i = 0; i < todasAsFases.Length; i++)
        {
            ChallengeData fase = todasAsFases[i];
            if (fase == null) continue;

            GameObject novoBotao = Instantiate(botaoFasePrefab, painelDeBotoes);
            LevelButtonUI botaoUI = novoBotao.GetComponent<LevelButtonUI>();

            if (botaoUI == null) continue;

            if (botaoUI.nomeFaseText != null)
                botaoUI.nomeFaseText.text = fase.nomeFase;

            int estrelasObtidas = 0;
            if (DataPersistence.Instance != null &&  DataPersistence.Instance.currentSave != null &&  fase.levelIndex < DataPersistence.Instance.currentSave.levelStars.Count)
            {
                estrelasObtidas = DataPersistence.Instance.currentSave.levelStars[fase.levelIndex];
            }

            if (botaoUI.estrelas != null)
            {
                for (int e = 0; e < botaoUI.estrelas.Length; e++)
                {
                    if (botaoUI.estrelas[e] != null)
                    {
                        botaoUI.estrelas[e].color = (e < estrelasObtidas)  ? Color.white  : new Color(0.2f, 0.2f, 0.2f, 1f);
                    }
                }
            }

            Button btn = novoBotao.GetComponent<Button>();
            if (btn != null)
            {
                bool estaDesbloqueada = fase.levelIndex <= levelDesbloqueado;
                btn.interactable = estaDesbloqueada;

                if (estaDesbloqueada)
                {
                    btn.onClick.AddListener(() => CarregarFase(fase));
                }
            }
        }
    }

    private void CarregarFase(ChallengeData faseEscolhida)
    {
        GameManager.DesafioSelecionado = faseEscolhida;
        SceneManager.LoadScene(nomeCenaDoJogo);
    }

    public void CarregarProximaFase()
    {
        for (int i = 0; i < todasAsFases.Length; i++)
        {
            if (todasAsFases[i] == GameManager.DesafioSelecionado)
            {
                if (i + 1 < todasAsFases.Length)
                {
                    CarregarFase(todasAsFases[i + 1]);
                }
                else
                {
                    SceneManager.LoadScene("CenaInicial");
                }
                return;
            }
        }
    }
}