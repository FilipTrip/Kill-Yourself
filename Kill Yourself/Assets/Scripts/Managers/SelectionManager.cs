using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private KeyCode[] up;
    [SerializeField] private KeyCode[] down;
    [SerializeField] private KeyCode[] left;
    [SerializeField] private KeyCode[] right;
    [SerializeField] private KeyCode[] select;

    private Selectable nextSelectable;
    private Button button;

    private void Update()
    {
        if (eventSystem.currentSelectedGameObject == null)
            return;

        if (GetKeyDown(up))
        {
            if (nextSelectable = eventSystem.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp())
                nextSelectable.Select();
        }
        else if (GetKeyDown(down))
        {
            if (nextSelectable = eventSystem.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown())
                nextSelectable.Select();
        }
        else if (GetKeyDown(left))
        {
            if (nextSelectable = eventSystem.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnLeft())
                nextSelectable.Select();
        }
        else if (GetKeyDown(right))
        {
            if (nextSelectable = eventSystem.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnRight())
                nextSelectable.Select();
        }
        else if (GetKeyDown(select))
        {
            if (button = eventSystem.currentSelectedGameObject.GetComponent<Button>())
                button.onClick.Invoke();
            else
                Debug.Log("Selectable could not be pressed");
        }
    }

    private bool GetKeyDown(KeyCode[] keyCodes)
    {
        foreach (KeyCode keyCode in keyCodes)
        {
            if (Input.GetKeyDown(keyCode))
                return true;
        }
        return false;
    }
}
