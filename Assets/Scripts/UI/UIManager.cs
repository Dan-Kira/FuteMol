using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void IniciarSimulacao()
    {
        ChallengeManager.Instance.Simular();
    }
}