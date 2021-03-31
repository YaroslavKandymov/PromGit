using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    public void OpenPanel(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;
        Time.timeScale = 0;
    }

    public void ClosePanel(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
