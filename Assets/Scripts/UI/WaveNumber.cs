﻿using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]

public class WaveNumber : MonoBehaviour
{
    [SerializeField] private WaveSpawner _waveSpawner;
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

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
        _text.text = (waveNumber + 1).ToString();
    }
}
