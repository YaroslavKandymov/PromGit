using TMPro;
using UnityEngine;

public class WaveNumber : MonoBehaviour
{
    [SerializeField] private WaveSpawner _waveSpawner;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _waveSpawner.WaveStarted += OnWaveDisplay;
    }

    private void OnDisable()
    {
        _waveSpawner.WaveStarted -= OnWaveDisplay;
    }

    private void OnWaveDisplay(int waveNumber)
    {
        _text.text = waveNumber.ToString();
    }
}
