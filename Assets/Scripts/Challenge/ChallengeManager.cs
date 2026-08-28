using UnityEngine;

public class ChallengeManager : MonoBehaviour
{
    public static ChallengeManager Instance;

    public enum ChallengeStates { Formulando, Simulando, Derrota, Vitoria }

    public ChallengeStates CurrentChallenge;

    [Header("Referências")]
    [SerializeField] private GoalManager goal;
    [SerializeField] private ResultsManager resultsManager;
    [SerializeField] private UIManager uiManager;

    [Header("Obstáculos")]
    [SerializeField] private ChallengeData currentChallenge;
    [SerializeField] private Transform[] obstacleSpawnPoints;


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

        CurrentChallenge = ChallengeStates.Formulando;
    }

    private void Start()
    {
        SpawnObstacles();
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
        if (CurrentChallenge != ChallengeStates.Formulando)
            return;

        CurrentChallenge = ChallengeStates.Simulando;
        uiManager.AtivarPainelSimulacao();
    }

    public void Victory()
    {
        if (CurrentChallenge != ChallengeStates.Simulando)
            return;

        CurrentChallenge = ChallengeStates.Vitoria;
        resultsManager.Victory();
    }

    public void Defeat()
    {
        if (CurrentChallenge != ChallengeStates.Simulando)
            return;

        CurrentChallenge = ChallengeStates.Derrota;
        resultsManager.Defeat();
    }

    public void PararSimulacao()
    {
        if (CurrentChallenge != ChallengeStates.Simulando) return;
        ResetarSimulacao();
    }

    public void ResetarSimulacao()
    {
        CurrentChallenge = ChallengeStates.Formulando;
        uiManager.AtivarPainelFormulacao();

        ChargedObject ball = FindAnyObjectByType<ChargedObject>();
        if (ball != null) ball.ResetarPosicao();
    }

    public void LimparCargas()
    {
        if (CurrentChallenge != ChallengeStates.Formulando) return;

        // É preciso usar .ToArray() porque ao destruir e chamar OnDisable, a lista original muda de tamanho
        foreach (var charge in ChargeParticleWorld.AllCharges.ToArray())
        {
            ChargeBoxUI.Instance.ReturnChargeToBox(charge.Charge > 0);
            Destroy(charge.gameObject);
        }
    }
}