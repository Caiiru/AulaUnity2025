using UnityEngine;
using UnityEngine.UI;

public class Douglas_EnergyUI : MonoBehaviour
{
 [Header("Energy Parameters")]
    private float maxEnergy = 100f;
    private float energy;

    [Header("Color Parameters")]
    [Tooltip("A cor da barra quando a energia está cheia.")]
    public Color colorFull = Color.green;

    [Tooltip("A cor da barra quando a energia está vazia.")]
    public Color colorEmpty = Color.red;

    [Header("UI References")]
    [Tooltip("Arraste o  Slider para este campo.")]
    [SerializeField] private Slider energySlider;

    [Tooltip("Arraste o Fill para este campo.")]
    [SerializeField] private Image energyFill;

    [Header("Battery References")]
    [Tooltip("Arraste o  Slider para este campo.")]
    [SerializeField] private Douglas_PlayerLightControl playerLight;

    void Start()
    {
        energySlider.maxValue = maxEnergy;
        UpdateBar(); // Atualiza a barra uma vez no início para garantir que ela comece correta.
    }

    void Update()
    {
        energy = playerLight.bateryLevel;
        UpdateBar();
    }

    private void UpdateBar() // Função para atualizar a parte visual da barra.
    {
        energySlider.value = energy; // Define o valor do slider para ser igual à nossa energia atual.
        energyFill.color = Color.Lerp(colorEmpty, colorFull, energy / maxEnergy); // Color.Lerp mistura duas cores, com base no ultimo parametro (no caso energiaAtual / energiaMaxima) entao ele escolhe uma cor entre os dois primeiros parametros.
    }
}
