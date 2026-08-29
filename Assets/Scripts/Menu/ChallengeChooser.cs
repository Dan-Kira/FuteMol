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

    void Start()
    {
        if (painelDeBotoes != null && painelDeBotoes.childCount == 0)
        {
            GenerateButtons();
        }
    }

    void GenerateButtons()
    {
        foreach (Transform child in painelDeBotoes)
        {
            Destroy(child.gameObject);
        }
        
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
