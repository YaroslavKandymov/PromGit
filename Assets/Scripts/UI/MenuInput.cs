using UnityEngine;

public class MenuInput : MonoBehaviour
{
    [SerializeField] private MenuPanel _panel;

    private UIInput _uiInput;

    private void Awake()
    {
        _uiInput = new UIInput();
        _uiInput.UIMap.OpenPanel.performed += ctx => OnOpenPanel();
    }

    private void OnEnable()
    {
        _uiInput.Enable();
    }

    private void OnDisable()
    {
        _uiInput.Disable();
    }

    private void OnOpenPanel()
    {
        _panel.OnOpenPanel();
    }
}
