using UnityEngine;

public class ChallengeManager : MonoBehaviour
{
    public static ChallengeManager Instance;

    public enum ChallengeStates { Formulando, Simulando, Derrota, Vitoria }

    public ChallengeStates CurrentState;

    [Header("Referências")]
    [SerializeField] private GoalManager goal;
    [SerializeField] private ResultsManager resultsManager;
    [SerializeField] private UIManager uiManager;

    [Header("Obstáculos")]
    [SerializeField] private ChallengeData currentChallenge;
    [SerializeField] private Transform[] obstacleSpawnPoints;

    public float tempoDecorrido;

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

        currentChallenge = GameManager.DesafioSelecionado;

        CurrentState = ChallengeStates.Formulando;
    }

    private void Start()
    {
        SpawnObstacles();
    }

    private void Update()
    {
        if (CurrentState == ChallengeStates.Simulando)
        {
            tempoDecorrido += Time.deltaTime;
        }
    }

    private void SpawnObstacles()
    {
        if (currentChallenge.obstaclesPrefab == null) return;

        int amountToSpawn = Mathf.Min(currentChallenge.obstaclesQuant, obstacleSpawnPoints.Length);

        for (int i = 0; i < amountToSpawn; i++)
        {
            Instantiate(currentChallenge.obstaclesPrefab, obstacleSpawnPoints[i].position, Quaternion.identity);
        }
    }

    public void Simular()
    {
        if (CurrentState != ChallengeStates.Formulando)
            return;

        CurrentState = ChallengeStates.Simulando;
        uiManager.AtivarPainelSimulacao();
    }

    public void Victory()
    {
        if (CurrentState != ChallengeStates.Simulando) return;

        CurrentState = ChallengeStates.Vitoria;

        int stars = 1;
        if (tempoDecorrido <= currentChallenge.tempo3Estrelas) stars = 3;
        else if (tempoDecorrido <= currentChallenge.tempo2Estrelas) stars = 2;

        DataPersistence.Instance.SaveLevelProgress(currentChallenge.levelIndex, stars, tempoDecorrido);

        float melhorTempo = DataPersistence.Instance.GetBestTime(currentChallenge.levelIndex);

        resultsManager.Victory(stars, tempoDecorrido, melhorTempo);
    }

    public void Defeat()
    {
        if (CurrentState != ChallengeStates.Simulando)
            return;

        CurrentState = ChallengeStates.Derrota;
        resultsManager.Defeat();
    }

    public void PararSimulacao()
    {
        if (CurrentState != ChallengeStates.Simulando) return;
        ResetarSimulacao();
    }

    public void ResetarSimulacao(bool zerarTempo = false)
    {
        CurrentState = ChallengeStates.Formulando;
        uiManager.AtivarPainelFormulacao();

        if (zerarTempo)
        {
            tempoDecorrido = 0f;
        }

        ChargedObject ball = FindAnyObjectByType<ChargedObject>();
        if (ball != null) ball.ResetarPosicao();
    }

    public void LimparCargas()
    {
        if (CurrentState != ChallengeStates.Formulando) return;

        foreach (var charge in ChargeParticleWorld.AllCharges.ToArray())
        {
            ChargeBoxUI.Instance.ReturnChargeToBox(charge.Charge > 0);
            Destroy(charge.gameObject);
        }
    }
}