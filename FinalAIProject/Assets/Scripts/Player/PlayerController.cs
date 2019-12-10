using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolyNav;

[RequireComponent(typeof(PolyNavAgent))]
public class PlayerController : FSM
{
    [SerializeField]
    private int currentStep;
    [SerializeField]
    private bool isVisable;
    public Action currentAction { get; private set; }
    public PolyNavAgent agent { get; private set; }

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

    protected override void FSMFixedUpdate()
    {

    }

    protected override void FSMUpdate()
    {

    }

    protected override void Initalize()
    {
        currentStep = 0;
        isCurrentlyWaiting = false;
        agent = gameObject.GetComponent<PolyNavAgent>();

        BuildFSM();
    }

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
        //States here
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
