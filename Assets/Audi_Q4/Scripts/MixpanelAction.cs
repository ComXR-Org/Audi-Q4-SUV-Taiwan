using UnityEngine.Events;
using UnityEngine;

public class MixpanelAction : MonoBehaviour
{
    [SerializeField] bool isOpen;
    public UnityEvent actionsOnTrue, actionsOnFalse;
    public void Open()
    {
        isOpen = true;
        actionsOnFalse.Invoke();
    }

    public void Close()
    {
        isOpen = false;
        actionsOnTrue.Invoke();
    }

    public void ToggleOpenClose()
    {
        if (!isOpen)
            Open();
        else
            Close();
    }
}
