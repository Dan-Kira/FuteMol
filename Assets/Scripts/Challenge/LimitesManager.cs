using UnityEngine;

public class LimitesManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ball"))
            return;

        ChallengeManager.Instance.Defeat();
    }
}