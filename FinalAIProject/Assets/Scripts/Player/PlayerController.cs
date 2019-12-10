using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolyNav;

[RequireComponent(typeof(PolyNavAgent))]
public class PlayerController : FSM
{
    //Visable only for debug
    public int currentStep;
    [SerializeField]
    private bool isVisable;
    public Action currentAction { get; private set; }
    public PolyNavAgent agent { get; private set; }

    //Damage Stuff
    public int shotsTaken { get; private set; }
    [SerializeField]
    private int maxShotsTaken = 1;
    public bool dead { get; private set; }

    //Player Activator
    public bool playerActive;

    public void setVisability(bool visable)
    {
        if (visable)
        {
            isVisable = true;
            //Color change code
        }
        else
        {
            isVisable = false;
            //Color change code
        }
    }

    public void TakeShot()
    {
        shotsTaken += 1;
        if(shotsTaken >= maxShotsTaken)
        {
            dead = true;
        }
    }

    protected override void FSMFixedUpdate()
    {

    }

    protected override void FSMUpdate()
    {

    }

    protected override void Initalize()
    {
        currentStep = -1;
        isCurrentlyWaiting = false;
        playerActive = false;
        agent = gameObject.GetComponent<PolyNavAgent>();

        BuildFSM();
    }

    /// <summary>
    /// Sets the next movement step active
    /// </summary>
    /// <returns>True if there are further steps to be taken, false if the final step has been reached</returns>
    public bool setNextStep()
    {
        currentStep += 1;
        if (currentStep >= ActionQueue.instance.getNumActions())
        {
            Debug.Log("SetNextStep has reached final step");
            return false;
        }

        currentAction = ActionQueue.instance.GetAction(currentStep);
        return true;
    }

    protected virtual void BuildFSM()
    {
        PlayerInactiveState inactive = new PlayerInactiveState(this);
        inactive.AddTransitionState(FSMStateID.PlayerWait, FSMTransitions.PlayerActivated);

        PlayerWaitState wait = new PlayerWaitState(this);
        wait.AddTransitionState(FSMStateID.PlayerMove, FSMTransitions.PlayerDoneWaiting);

        PlayerMoveState move = new PlayerMoveState(this);
        move.AddTransitionState(FSMStateID.PlayerDecide, FSMTransitions.PlayerDoneMoving);

        PlayerDecideState decide = new PlayerDecideState(this);
        decide.AddTransitionState(FSMStateID.PlayerWait, FSMTransitions.PlayerMoreStepsFound);
        decide.AddTransitionState(FSMStateID.PlayerComplete, FSMTransitions.PlayerNoStepsFound);

        PlayerCompleteState complete = new PlayerCompleteState();

        AddFSMState(inactive);
        AddFSMState(wait);
        AddFSMState(move);
        AddFSMState(decide);
        AddFSMState(complete);
    }

    #region Delay Scripts

    public bool isCurrentlyWaiting;
    public void startDelay(float delayTime)
    {
        if (!isCurrentlyWaiting)
        {
            isCurrentlyWaiting = true;
            StartCoroutine(Delay(delayTime));
        }
        else
        {
            Debug.LogError("Delay is already running");
        }
    }

    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
        isCurrentlyWaiting = false;
    }

    #endregion
}
