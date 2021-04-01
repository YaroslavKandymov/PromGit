using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : UIPanel
{
    private void OnEnable()
    {
        ContinueButton.onClick.AddListener(OnClosePanel);
        ExitButton.onClick.AddListener(Application.Quit);
    }

    private void OnDisable()
    {
        ContinueButton.onClick.RemoveListener(OnClosePanel);
        ExitButton.onClick.RemoveListener(Application.Quit);
    }

    public override void OnOpenPanel()
    {
        MenuPanel.SetActive(true);
        Scope.SetActive(false);

        Time.timeScale = 0;
        Cursor.visible = true;
    }

    private void OnClosePanel()
    {
        MenuPanel.SetActive(false);
        Scope.SetActive(true);

        Cursor.visible = false;
        Time.timeScale = 1;
    }
}
