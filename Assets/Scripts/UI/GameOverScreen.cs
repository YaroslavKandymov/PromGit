using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private WaveSpawner _waveSpawner;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        _player.OnDied += OnFinishGame;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(Application.Quit);
    }

    private void OnDisable()
    {
        _player.OnDied -= OnFinishGame;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(Application.Quit);
    }

    private void OnFinishGame()
    {
        _canvasGroup.alpha = 1;
        Time.timeScale = 0;
        Cursor.visible = true;
    }

    private void OnRestartButtonClick()
    {
        _canvasGroup.alpha = 0;
        Time.timeScale = 1;
        _player.Reset();
        _waveSpawner.Reset();
    }
}
