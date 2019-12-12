using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeadState : FSMState
{
    Text youDiedText;

    public PlayerDeadState(Text deadText)
    {
        stateID = FSMStateID.PlayerDead;
        youDiedText = deadText;
    }

    public override void Act(Transform player, GameObject self)
    {
        //Nothing, they're dead
    }

    public override void OnStateEnter(Transform player, GameObject self)
    {
        player.rotation = Quaternion.Euler(0f, 0f, 180f);
        youDiedText.text = "YOU DIED";
        Time.timeScale = 0;
    }

    public override void OnStateExit(Transform player, GameObject self)
    {
        //Can't leave
    }

    public override void Reason(Transform player, GameObject self)
    {
        //Nothing, they're dead
    }
}
