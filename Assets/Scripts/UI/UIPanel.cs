using UnityEngine;

public abstract class UIPanel : MonoBehaviour
{
    [SerializeField] protected GameObject MenuPanel;
    [SerializeField] protected GameObject Scope;

    /*private void Start()
    {
        MenuPanel.SetActive(false);
    }*/

    public abstract void OnOpenPanel();
}
