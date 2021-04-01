using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : UIPanel
{
    [SerializeField] private Player _player;
    [SerializeField] private WaveSpawner _waveSpawner;
    [SerializeField] private TMP_Text _wavesCount;

    private void OnEnable()
    {
        _player.OnDied += OnOpenPanel;
        ContinueButton.onClick.AddListener(OnRestartButtonClick);
        ExitButton.onClick.AddListener(Application.Quit);
    }

    private void OnDisable()
    {
        _player.OnDied -= OnOpenPanel;
        ContinueButton.onClick.RemoveListener(OnRestartButtonClick);
        ExitButton.onClick.RemoveListener(Application.Quit);
    }

    private void OnRestartButtonClick()
    {
        _player.Reset();
        _waveSpawner.Reset();

        Cursor.visible = false;
        Time.timeScale = 1;

        MenuPanel.SetActive(false);
        Scope.SetActive(true);
    }

    public override void OnOpenPanel()
    {
        MenuPanel.SetActive(true);
        Scope.SetActive(false);

        _wavesCount.text = (_waveSpawner.CurrentWaveNumber + 1).ToString();

        Time.timeScale = 0;
        Cursor.visible = true;
    }
}
