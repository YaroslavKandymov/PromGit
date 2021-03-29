using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MainMenu))]

public class MenuOpener : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private MainMenu _menu;

    private UIInput _uiInput;

    private void Awake()
    {
        _uiInput = new UIInput();
        _uiInput.UIMap.OpenPanel.performed += ctx => OnOpen();

        _menu = GetComponent<MainMenu>();
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
        _menu.OpenPanel(_panel);
    }
}
