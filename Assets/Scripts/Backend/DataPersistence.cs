using UnityEngine;

public class DataPersistence : MonoBehaviour
{
    public static DataPersistence Instance;
    public SaveData currentSave;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if(currentSave != null) SaveController.DeleteSave();
    }

    public void SaveLevelProgress(int levelIndex, int stars, float tempo)
    {
        if (currentSave.highestLevelUnlocked < levelIndex + 1)
            currentSave.highestLevelUnlocked = levelIndex + 1;

        while (currentSave.levelStars.Count <= levelIndex)
            currentSave.levelStars.Add(0);

        while (currentSave.levelBestTime.Count <= levelIndex)
            currentSave.levelBestTime.Add(float.MaxValue);

        if (stars > currentSave.levelStars[levelIndex])
            currentSave.levelStars[levelIndex] = stars;

        if (tempo < currentSave.levelBestTime[levelIndex])
            currentSave.levelBestTime[levelIndex] = tempo;

        SaveController.Save(currentSave);
    }

    public float GetBestTime(int levelIndex)
    {
        if (levelIndex < currentSave.levelBestTime.Count)
            return currentSave.levelBestTime[levelIndex];
        return 0f;
    }
}