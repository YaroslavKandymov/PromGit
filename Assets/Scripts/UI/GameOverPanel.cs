using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : UIPanel
{
    [SerializeField] private Player _player;
    [SerializeField] private WaveSpawner _waveSpawner;
    [SerializeField] private TMP_Text _wavesCount;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    private void OnEnable()
    {
        _player.Died += OnDied;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(Application.Quit);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(Application.Quit);
    }

    private void OnRestartButtonClick()
    {
        _player.Reset();
        _waveSpawner.Reset();

        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        MenuPanel.SetActive(false);
        Scope.SetActive(true);
    }

    public void OnDied()
    {
        _player.Died -= OnDied;
        MenuPanel.SetActive(true);
        Scope.SetActive(false);

        _wavesCount.text = (_waveSpawner.CurrentWaveNumber + 1).ToString();

        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
