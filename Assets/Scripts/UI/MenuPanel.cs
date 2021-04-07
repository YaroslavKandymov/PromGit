using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : UIPanel
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _exitButton;

    private void OnEnable()
    {
        _continueButton.onClick.AddListener(OnContinueButtonClick);
        _exitButton.onClick.AddListener(Application.Quit);
    }

    private void OnDisable()
    {
        _continueButton.onClick.RemoveListener(OnContinueButtonClick);
        _exitButton.onClick.RemoveListener(Application.Quit);
    }

    public void OnOpenPanel()
    {
        MenuPanel.SetActive(true);
        Scope.SetActive(false);

        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnContinueButtonClick()
    {
        MenuPanel.SetActive(false);
        Scope.SetActive(true);

        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
