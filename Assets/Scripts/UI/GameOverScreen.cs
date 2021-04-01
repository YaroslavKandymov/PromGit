using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : UIPanel
{
    [SerializeField] private Player _player;
    [SerializeField] private WaveSpawner _waveSpawner;

    protected override void OnEnable()
    {
        _player.OnDied += OnOpenPanel;
        RestartButton.onClick.AddListener(OnRestartButtonClick);
        ExitButton.onClick.AddListener(Application.Quit);
    }

    protected override void OnDisable()
    {
        _player.OnDied -= OnOpenPanel;
        RestartButton.onClick.RemoveListener(OnRestartButtonClick);
        ExitButton.onClick.RemoveListener(Application.Quit);
    }

    private void OnRestartButtonClick()
    {
        _player.Reset();
        _waveSpawner.Reset();

        Cursor.visible = false;
        Time.timeScale = 1;

        Scope.SetActive(true);
    }
}
