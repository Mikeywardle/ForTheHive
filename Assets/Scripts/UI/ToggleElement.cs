using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleElement : MonoBehaviour
{
    public void toggleObject(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
    }
}
