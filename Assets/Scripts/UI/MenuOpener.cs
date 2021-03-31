using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MenuPanel))]

public class MenuOpener : MonoBehaviour
{
    [SerializeField] private CanvasGroup _panel;

    private MenuPanel _menuPanel;

    private UIInput _uiInput;

    private void Awake()
    {
        _uiInput = new UIInput();
        _uiInput.UIMap.OpenPanel.performed += ctx => OnOpen();

        _menuPanel = GetComponent<MenuPanel>();
    }

    private void OnEnable()
    {
        _uiInput.Enable();
    }

    private void OnDisable()
    {
        _uiInput.Disable();
    }

    public void OnOpen()
    {
        _menuPanel.OpenPanel(_panel);
    }
}
