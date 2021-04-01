using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : UIPanel
{
    protected override void OnEnable()
    {
        RestartButton.onClick.AddListener(OnClosePanel);
        ExitButton.onClick.AddListener(Application.Quit);
    }

    protected override void OnDisable()
    {
        RestartButton.onClick.RemoveListener(OnClosePanel);
        ExitButton.onClick.RemoveListener(Application.Quit);
    }

    private void OnClosePanel()
    {
        MenuPanel.SetActive(false);
        Scope.SetActive(true);

        Cursor.visible = false;
        Time.timeScale = 1;
    }
}
