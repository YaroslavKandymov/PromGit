using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class ScreenBlinker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _duration;
    [SerializeField] private float _alpha = 50;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _player.TakenDamage += OnScreenBlinking;
    }

    private void OnDisable()
    {
        _player.TakenDamage -= OnScreenBlinking;
    }

    private void OnScreenBlinking()
    {
        _image.DOFade(_alpha, _duration).OnComplete(() => _image.DOFade(0, _duration));
    }
}
