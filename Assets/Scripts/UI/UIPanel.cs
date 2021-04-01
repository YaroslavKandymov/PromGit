using UnityEngine;
using UnityEngine.UI;

public abstract class UIPanel : MonoBehaviour
{
    [SerializeField] protected GameObject MenuPanel;
    [SerializeField] protected Button ContinueButton;
    [SerializeField] protected Button ExitButton;
    [SerializeField] protected GameObject Scope;

    private void Start()
    {
        MenuPanel.SetActive(false);
    }

    public abstract void OnOpenPanel();
}
