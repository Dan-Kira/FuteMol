using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultsManager : MonoBehaviour
{
    public GameObject victoryPanel;
    public GameObject defeatPanel;

    private void Awake()
    {
        victoryPanel.SetActive(false);
        defeatPanel.SetActive(false);

        Time.timeScale = 1.0f;
    }

    public void Victory()
    {
        victoryPanel.SetActive(true);

        Time.timeScale = 0;
    }

    public void Defeat()
    {
        defeatPanel.SetActive(true);

        Time.timeScale = 0;
    }

    public void TentarNovamente()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
