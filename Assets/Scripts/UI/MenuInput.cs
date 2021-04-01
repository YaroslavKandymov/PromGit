using UnityEngine;

public class MenuInput : MonoBehaviour
{
    [SerializeField] private UIPanel _panel;

    private UIInput _uiInput;

    private void Awake()
    {
        _uiInput = new UIInput();
        _uiInput.UIMap.OpenPanel.performed += ctx => OnOpen();
    }

    private void OnEnable()
    {
        _uiInput.Enable();
    }

    private void OnDisable()
    {
        _uiInput.Disable();
    }

    private void OnOpen()
    {
        _panel.OnOpenPanel();
    }
}
