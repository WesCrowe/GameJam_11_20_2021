using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMenuManager : MonoBehaviour
{
    public SubMenu[] subMenus;
    private SubMenu last;
    private SubMenu cur;

    public void Start()
    {
        if (cur == null && subMenus.Length != 0)
        {
            cur = subMenus[0];
            cur.SetFocused(true);
            for (int i = 1; i < subMenus.Length; i++)
            {
                subMenus[i].SetFocused(false);
            }
        }
    }

    public void goBack()
    {
        if (last != null)
        {
            SubMenu temp = last;
            last = cur;
            cur = temp;
            cur.SetFocused(true);
            last.SetFocused(false);
        }
    }

    public void goTo(int idx)
    {
        if (cur != null)
        {
            last = cur;
            last.SetFocused(false);
        }
        cur = subMenus[idx];
        cur.SetFocused(true);
    }
}
