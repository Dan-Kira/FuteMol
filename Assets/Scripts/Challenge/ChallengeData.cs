using UnityEngine;

[CreateAssetMenu(fileName = "ChallengeData", menuName = "Challenge/Challenge Data")]
public class ChallengeData : ScriptableObject
{
    [Header("Level Info")]
    public string nomeFase = "Fase 1";
    public int levelIndex;

    [Header("Estrelas (Tempo em Segundos)")]
    public float tempo3Estrelas = 5f;
    public float tempo2Estrelas = 10f;

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