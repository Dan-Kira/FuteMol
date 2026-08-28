using UnityEngine;

public class ChargeBoxUI : MonoBehaviour
{
    public static ChargeBoxUI Instance;

    private ChallengeData currentChallenge;

    [Header("Positive Charge")]
    [SerializeField] private Transform positiveChargeBox;

    [Header("Negative Charge")]
    [SerializeField] private Transform negativeChargeBox;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentChallenge = GameManager.DesafioSelecionado;

        if (currentChallenge == null) return;

        InstantiateCharges(currentChallenge.positiveParticleUIPrefab, currentChallenge.positiveParticleWorldPrefab, currentChallenge.maxPositiveParticles, positiveChargeBox);

        InstantiateCharges(currentChallenge.negativeParticleUIPrefab, currentChallenge.negativeParticleWorldPrefab, currentChallenge.maxNegativeParticles, negativeChargeBox);
    }

    private void InstantiateCharges(GameObject uiPrefab, GameObject worldPrefab, int amount, Transform box)
    {
        for (int i = 0; i < amount; i++)
        {
            CreateChargeInUI(uiPrefab, worldPrefab, box);
        }
    }

    public void ReturnChargeToBox(bool isPositive)
    {
        if (isPositive)
        {
            CreateChargeInUI(currentChallenge.positiveParticleUIPrefab, currentChallenge.positiveParticleWorldPrefab, positiveChargeBox);
        }
        else
        {
            CreateChargeInUI(currentChallenge.negativeParticleUIPrefab, currentChallenge.negativeParticleWorldPrefab, negativeChargeBox);
        }
    }

    private void CreateChargeInUI(GameObject uiPrefab, GameObject worldPrefab, Transform box)
    {
        GameObject chargeObject = Instantiate(uiPrefab, box);
        ChargeParticleUI chargeUI = chargeObject.GetComponent<ChargeParticleUI>();
        chargeUI.Initialize(worldPrefab);
    }
}