using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(enable))]
[RequireComponent(typeof(toIsActive))]

public class toggleXor : MonoBehaviour
{
    public enable enable1;
    public enable enable2;

    private void Update()
    {

        if ((enable1.isOn || enable2.isOn) && !(enable1.isOn && enable2.isOn))
        {

            gameObject.GetComponent<enable>().toggle();
            gameObject.GetComponent<toIsActive>().toggle();

        }

    }
}
