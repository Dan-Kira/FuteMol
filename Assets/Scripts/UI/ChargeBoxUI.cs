using UnityEngine;

public class ChargeBoxUI : MonoBehaviour
{
    public ChallengeData currentChallenge;

    [Header("Positive Charge")]
    public GameObject positiveChargePrefab;
    public GameObject positiveChargeBox;
    public int currentPositiveCharges;

    [Header("Negative Charge")]
    public GameObject negativeChargePrefab;
    public GameObject negativeChargeBox;
    public int currentNegativeCharges;

    private void Awake()
    {
        InstantiateCharges(positiveChargePrefab, positiveChargeBox, currentChallenge.maxPositiveParticles);
        InstantiateCharges(negativeChargePrefab, negativeChargeBox, currentChallenge.maxNegativeParticles);
    }

    public void InstantiateCharges(GameObject instantiatedCharge, GameObject instantiationBox, int instaintiationTime)
    {
        for (int i = 0; i < instaintiationTime; i++)
        {
            Instantiate(instantiatedCharge);
            instantiatedCharge.transform.position = instantiationBox.transform.position;
        }
    }
}
