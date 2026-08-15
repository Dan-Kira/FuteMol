using UnityEngine;

public class ChallengeData : ScriptableObject
{
    public int maxPositiveParticles;
    public GameObject positiveParticlesPrefab;

    public int maxNegativeParticles;
    public GameObject negativeParticlesPrefab;


    public int obstaclesQuant;
    public GameObject obstaclesPrefab;


    public GameObject goalPrefab;
}