using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Player _player;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
    }

    private void OnEnable()
    {
        _player.OnDied += OnFinishGame;
    }

    private void OnDisable()
    {
        _player.OnDied -= OnFinishGame;
    }

    private void OnFinishGame()
    {
        _canvasGroup.alpha = 1;
        Time.timeScale = 0;
        Cursor.visible = true;
    }
}
