using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionElement : MonoBehaviour
{
    public int index;

    private Text titleText;
    private InputField input;

    [SerializeField]
    private float waitTime;
    private Vector3 destPoint = new Vector3();
    private bool newAction;

    public void setDestPoint()
    {

    }

    public void updateElement()
    {
        if(newAction)
        {
            titleText.text = "New Step";
        }
        else
        {
            titleText.text = "Step " + (index + 1);
        }
    }

    public void saveElement()
    {
        if(newAction)
        {
            index = ActionQueue.instance.AddAction(waitTime, destPoint);
            if(index == -1)
            {
                Destroy(gameObject);
            }
            newAction = false;
        }
        else
        {
            ActionQueue.instance.editAction(index, waitTime, destPoint);
        }
        updateElement();
    }

    public void deleteElement()
    {
        if(!newAction)
        {
            ActionQueue.instance.removeAction(index);
        }
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        titleText = gameObject.transform.GetChild(0).GetComponentInChildren<Text>();
        input = gameObject.transform.GetChild(1).GetComponentInChildren<InputField>();
        newAction = true;
        updateElement();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(input.text != "")
        {
            waitTime = float.Parse(input.text);
        }
    }
}
