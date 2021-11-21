using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SetCurrentSelected : MonoBehaviour
{
    public EventSystem eventManager;
    public GameObject setButton;
    public void setSelected()
    {
        eventManager.SetSelectedGameObject(setButton);
    }
}
