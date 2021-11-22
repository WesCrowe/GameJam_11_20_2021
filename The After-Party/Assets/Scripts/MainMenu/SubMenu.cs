using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SubMenu : MonoBehaviour
{
    public EventSystem eventManager;
    public GameObject firstButton;
    public void SetFocused(bool focused)
    {
        gameObject.SetActive(focused);
        if (focused)
        {
            eventManager.SetSelectedGameObject(firstButton);
        }
    }
}
