using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject painelFormulacao;
    [SerializeField] private GameObject painelSimulacao;

    private void Awake()
    {
        AtivarPainelFormulacao();
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