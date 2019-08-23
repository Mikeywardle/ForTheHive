using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIUtils
{
    public static bool mouseIsOverUI()
    {
        return EventSystem.current.currentSelectedGameObject == null;
    }

}
