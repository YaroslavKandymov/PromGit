using UnityEngine;
using UnityEngine.UI;

public abstract class UIPanel : MonoBehaviour
{
    [SerializeField] protected GameObject MenuPanel;
    [SerializeField] protected Button RestartButton;
    [SerializeField] protected Button ExitButton;
    [SerializeField] protected GameObject Scope;

    private void Awake()
    {
        MenuPanel.SetActive(false);
    }

    protected abstract void OnEnable();

    protected abstract void OnDisable();

    public void OnOpenPanel()
    {
        MenuPanel.SetActive(true);
        Scope.SetActive(false);

        Time.timeScale = 0;
        Cursor.visible = true;
    }
}
