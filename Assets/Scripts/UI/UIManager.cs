using System;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject painelFormulacao;
    [SerializeField] private GameObject painelSimulacao;
    [SerializeField] private GameObject pauseMenu;

    private void Awake()
    {
        AtivarPainelFormulacao();

        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
    }

    public void PauseMenu()
    {
        bool active = !pauseMenu.activeSelf;

        pauseMenu.SetActive(active);

        Time.timeScale = 0f;
    }

    public void Retomar()
    {
        if(pauseMenu != null) pauseMenu.SetActive(false);

        Time.timeScale = 1f;
    }

    public void Sair()
    {
        if(pauseMenu != null) pauseMenu.SetActive(false);

        Time.timeScale = 1f;

        SceneManager.LoadScene(0);
    }

    public void AtivarPainelSimulacao()
    {
        painelFormulacao.SetActive(false);
        painelSimulacao.SetActive(true);
    }

    public void AtivarPainelFormulacao()
    {
        painelFormulacao.SetActive(true);
        painelSimulacao.SetActive(false);
    }
}