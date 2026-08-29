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
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        GenerateButtons();
    }

    void GenerateButtons()
    {
        for(int i = 0; i < todasAsFases.Length; i++)
        {
            ChallengeData fase = todasAsFases[i];

            GameObject novoBotao = Instantiate(botaoFasePrefab, painelDeBotoes);

            novoBotao.GetComponentInChildren<TextMeshProUGUI>().text = fase.nomeFase;

            Button btn = novoBotao.GetComponent<Button>();
            btn.onClick.AddListener(() => CarregarFase(fase));
        }
    }

    private void CarregarFase(ChallengeData faseEscolhida)
    {
        GameManager.DesafioSelecionado = faseEscolhida;
        
        SceneManager.LoadScene(nomeCenaDoJogo);
    }
}
