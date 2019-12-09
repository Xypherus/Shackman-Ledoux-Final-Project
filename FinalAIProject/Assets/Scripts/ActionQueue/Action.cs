using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action
{
    public float waitTime { get; private set; }
    public Vector3 destinationPoint { get; private set; }

    public Action(float wait, Vector3 destination)
    {
        if (wait > 0) { waitTime = wait; }
        destinationPoint = destination;
    }

    public void EditAction(float wait, Vector3 destination)
    {
        if( wait < 0)
        {
            Debug.LogError("Wait time cannot be negitive");
            return;
        }
        waitTime = wait;
        destinationPoint = destination;
    }
}
