using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultsManager : MonoBehaviour
{
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject defeatPanel;

    private void Awake()
    {
        victoryPanel.SetActive(false);
        defeatPanel.SetActive(false);

        Time.timeScale = 1f;
    }

    public void Victory()
    {
        victoryPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Defeat()
    {
        defeatPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void TentarNovamente()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}