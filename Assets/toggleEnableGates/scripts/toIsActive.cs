using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toIsActive : MonoBehaviour
{

    public List<isActiveScript> objs;

    //toogles the isActive boolean for each script in the list
    public void toggle() {

        foreach (var obj in objs)
        {

            obj.isActive = !obj.isActive;

        }

    }

    //sets all to true
    public void allOn() {

        foreach (var obj in objs)
        {

            obj.isActive = true;

        }

    }

    //sets all to false
    public void allOff()
    {

        foreach (var obj in objs)
        {

            obj.isActive = false;

        }

    }

}
