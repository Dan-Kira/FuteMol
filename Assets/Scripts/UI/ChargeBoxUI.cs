using UnityEngine;

public class ChargeBoxUI : MonoBehaviour
{
    [SerializeField] private ChallengeData currentChallenge;

    [Header("Positive Charge")]
    [SerializeField] private Transform positiveChargeBox;

    [Header("Negative Charge")]
    [SerializeField] private Transform negativeChargeBox;

    private void Awake()
    {
        InstantiateCharges(currentChallenge.positiveParticleUIPrefab, currentChallenge.positiveParticleWorldPrefab, currentChallenge.maxPositiveParticles, positiveChargeBox);

        InstantiateCharges(currentChallenge.negativeParticleUIPrefab, currentChallenge.negativeParticleWorldPrefab, currentChallenge.maxNegativeParticles, negativeChargeBox);
    }

    private void InstantiateCharges(GameObject uiPrefab, GameObject worldPrefab, int amount, Transform box)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject chargeObject = Instantiate(uiPrefab, box);

            ChargeParticleUI chargeUI = chargeObject.GetComponent<ChargeParticleUI>();

            chargeUI.Initialize(worldPrefab);
        }
    }
}