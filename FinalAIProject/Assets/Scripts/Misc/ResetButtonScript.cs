using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButtonScript : MonoBehaviour
{
    public void ResetLevelState()
    {
        ActionQueue.instance.ResetLevelState();
    }
}
