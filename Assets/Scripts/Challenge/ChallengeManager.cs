using UnityEngine;

public class ChallengeManager : MonoBehaviour
{
    public static ChallengeManager Instance;

    public enum ChallengeStates
    {
        Formulando,
        Simulando,
        Derrota,
        Vitoria
    }

    public ChallengeStates CurrentChallenge;

    [Header("Referências")]
    [SerializeField] private GoalManager goal;
    [SerializeField] private ResultsManager resultsManager;


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

    public void Simular()
    {
        if (CurrentChallenge != ChallengeStates.Formulando)
            return;

        CurrentChallenge = ChallengeStates.Simulando;
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
}