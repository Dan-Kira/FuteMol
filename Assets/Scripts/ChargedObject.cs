using UnityEngine;

public class ChargedObject : MonoBehaviour
{
    [Header("Propriedades do objeto")]
    public float charge = 1.0f;
    public float mass = 1.0f;
    public Vector3 velocity;
    
    [Header("Configurações do sistema")]
    public float k = 50.0f;
    public float minDistance = 0.5f;

    public void Update(){
        GameObject[] particles = GameObject.FindGameObjectsWithTag("ChargeParticle");
        Vector3 totalForce = Vector3.zero;

        foreach (GameObject particleObj in particles)
        {
            ChargeParticle particleScript = particleObj.GetComponent<ChargeParticle>();
            if (particleScript == null) continue;

            Vector3 direction = transform.position - particleObj.transform.position;
            float distance = direction.magnitude;

            distance = Mathf.Max(distance, minDistance);

            float forceMagnitude = k * Mathf.Abs(charge * particleScript.charge) / (distance * distance);

            bool sameSign = (charge * particleScript.charge) > 0;
            Vector3 forceDirection = sameSign ? direction.normalized : -direction.normalized;

            totalForce += forceDirection * forceMagnitude;
        }

        Vector3 acceleration = totalForce / mass;
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }
}
