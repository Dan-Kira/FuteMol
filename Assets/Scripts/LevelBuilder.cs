using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    private void Awake()
    {
        if (GameManager.DesafioSelecionado == null)
        {
            Debug.LogWarning("Nenhum desafio selecionado! Jogue a partir do Menu Principal.");
            return;
        }

        GenerateScene(GameManager.DesafioSelecionado);
    }

    private void GenerateScene(ChallengeData dadosFase)
    {
        if (dadosFase.ballPrefab != null)
            Instantiate(dadosFase.ballPrefab, dadosFase.ballSpawnPosition, Quaternion.identity);

        if (dadosFase.goalPrefab != null)
            Instantiate(dadosFase.goalPrefab, dadosFase.goalSpawnPosition, Quaternion.identity);

        if (dadosFase.obstaclesPrefab != null && dadosFase.obstacleSpawnPositions != null)
        {
            int quant = Mathf.Min(dadosFase.obstaclesQuant, dadosFase.obstacleSpawnPositions.Length);
            
            for (int i = 0; i < quant; i++)
            {
                Instantiate(dadosFase.obstaclesPrefab, dadosFase.obstacleSpawnPositions[i], Quaternion.identity);
            }
        }
    }
}