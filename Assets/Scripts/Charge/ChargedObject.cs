using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ChargedObject : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float charge = 1f;

    [Header("Electric Field")]
    [SerializeField] private float k = 50f;
    [SerializeField] private float minDistance = 0.5f;

    private Rigidbody2D rb;

    private Vector2 startPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (ChallengeManager.Instance.CurrentState != ChallengeManager.ChallengeStates.Simulando)
        {
            return;
        }

        Vector2 totalForce = Vector2.zero;

        foreach (ChargeParticleWorld particle in ChargeParticleWorld.AllCharges)
        {
            Vector2 direction = (Vector2)transform.position - (Vector2)particle.transform.position;

            float distance = Mathf.Max(direction.magnitude, minDistance);

            Vector2 forceDirection = direction.normalized;

            float forceMagnitude = k * Mathf.Abs(charge * particle.Charge) / (distance * distance);

            bool sameSign = charge * particle.Charge > 0f;

            if (!sameSign) forceDirection *= -1f;

            totalForce += forceDirection * forceMagnitude;
        }

        rb.AddForce(totalForce * Time.deltaTime);
    }

    public void ResetarPosicao()
{
    transform.position = startPosition;
    rb.linearVelocity = Vector2.zero;
    rb.angularVelocity = 0f;
}
}