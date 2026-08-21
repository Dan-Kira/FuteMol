using UnityEngine;

[CreateAssetMenu(
    fileName = "ChallengeData",
    menuName = "Challenge/Challenge Data"
)]
public class ChallengeData : ScriptableObject
{
    [Header("Positive Charge")]
    public int maxPositiveParticles;
    public GameObject positiveParticleUIPrefab;
    public GameObject positiveParticleWorldPrefab;

    [Header("Negative Charge")]
    public int maxNegativeParticles;
    public GameObject negativeParticleUIPrefab;
    public GameObject negativeParticleWorldPrefab;

    [Header("Obstacles")]
    public int obstaclesQuant;
    public GameObject obstaclesPrefab;

    [Header("Goal")]
    public GameObject goalPrefab;
}