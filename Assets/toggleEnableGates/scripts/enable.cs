using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enable : MonoBehaviour
{

    public bool isOn = false;
    public List<GameObject> objs;

    //toggles the state of all objects
    public void toggle() {

        isOn = !isOn;

        foreach (var obj in objs)
        {

            obj.SetActive(!obj.activeSelf);

        }

    }

    //sets all objects to enabled
    public void enableAll() {

        isOn = true;

        foreach (var obj in objs)
        {

            obj.SetActive(true);

        }

    }

    //sets all objects to disabled
    public void disableAll()
    {

        isOn = false;

        foreach (var obj in objs)
        {

            obj.SetActive(false);

        }

    }

}
