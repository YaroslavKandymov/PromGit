using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : UIPanel
{
    [SerializeField] private Player _player;
    [SerializeField] private WaveSpawner _waveSpawner;

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
        Debug.Log("Умер");
        MenuPanel.SetActive(true);
        Scope.SetActive(false);

        Time.timeScale = 0;
        Cursor.visible = true;
    }
}
