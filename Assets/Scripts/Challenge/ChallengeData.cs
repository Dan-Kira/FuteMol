using UnityEngine;

[CreateAssetMenu(fileName = "ChallengeData", menuName = "Challenge/Challenge Data")]
public class ChallengeData : ScriptableObject
{
    [Header("Level Info")]
    public string nomeFase = "Fase 1";

    [Header("Positive Charge")]
    public int maxPositiveParticles;
    public GameObject positiveParticleUIPrefab;
    public GameObject positiveParticleWorldPrefab;

    [Header("Negative Charge")]
    public int maxNegativeParticles;
    public GameObject negativeParticleUIPrefab;
    public GameObject negativeParticleWorldPrefab;

    [Header("Player (Ball)")]
    public GameObject ballPrefab;
    public Vector3 ballSpawnPosition;

    [Header("Goal")]
    public GameObject goalPrefab;
    public Vector3 goalSpawnPosition;

    [Header("Obstacles")]
    public int obstaclesQuant;
    public GameObject obstaclesPrefab;
    public Vector3[] obstacleSpawnPositions;
}