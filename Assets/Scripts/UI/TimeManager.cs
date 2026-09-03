using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Header("UI Reference")]
    [SerializeField] private TextMeshProUGUI textoTempo;

    void Update()
    {
        if (ChallengeManager.Instance.CurrentState == ChallengeManager.ChallengeStates.Simulando)
        {
            AtualizarTempo(ChallengeManager.Instance.tempoDecorrido);
        }
    }

    private void AtualizarTempo(float tempo)
    {
        textoTempo.text = tempo.ToString("F2") + "s";
    }
}