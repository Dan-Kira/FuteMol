using UnityEngine;

public class ChallengeManager : MonoBehaviour
{
    public enum ChallengeStates
    {
        Iniciando,
        Formulando,
        Simulando,
        Derrota,
        Vitoria
    }
    public ChallengeStates currentChallenge;

    [Header("Referências")]
    public GoalManager goal;
    public ResultsManager resultsManager;


    public void Update()
    {
        StatesChanger();

        if(goal.goalConceded == true)
        {
            currentChallenge = ChallengeStates.Vitoria;
        }
    }

    public void StatesChanger()
    {
        switch (currentChallenge) {
            case ChallengeStates.Iniciando:

                break;

            case ChallengeStates.Formulando:

                break;

            case ChallengeStates.Simulando:

                break;

            case ChallengeStates.Derrota:
                resultsManager.Defeat();
                break;

            case ChallengeStates.Vitoria:
                resultsManager.Victory();
                break;
        }
    }
}
