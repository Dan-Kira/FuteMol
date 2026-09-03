using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public string currentChallenge;
    public int highestLevelUnlocked = 0;
    
    public List<int> levelStars = new List<int>();
    public List<float> levelBestTime = new List<float>();
}