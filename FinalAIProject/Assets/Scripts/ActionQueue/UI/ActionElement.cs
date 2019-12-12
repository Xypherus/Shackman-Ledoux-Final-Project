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
    private MousePointManager mousePointManager;

    //Destination Point Display
    private GameObject destPointDisplay;
    public GameObject destPointPrefab;

    public void setDestPoint(Vector3 point)
    {
        destPoint = point;
        Debug.Log("destPoint set to" + destPoint);
        
        if(!destPointDisplay)
        {
            destPointDisplay = Instantiate(destPointPrefab, point, Quaternion.identity);
        }
        destPointDisplay.transform.position = point;
    }

    public void updateElement()
    {
        if (newAction)
        {
            titleText.text = "New Step";
        }
        else
        {
            titleText.text = "Step " + (index + 1);
            input.text = string.Format("{0:0.##}", ActionQueue.instance.GetAction(index).waitTime);
        }
    }

    public void StartPointPolling()
    {
        mousePointManager.StartMouseSample(this);
        Debug.Log("Starting Point Polling...");
    }

    public void saveElement()
    {
        if (newAction)
        {
            index = ActionQueue.instance.AddAction(waitTime, destPoint);
            if (index == -1)
            {
                Destroy(gameObject);
            }
            newAction = false;
            transform.SetSiblingIndex(index);
        }
        else
        {
            ActionQueue.instance.editAction(index, waitTime, destPoint);
        }
        updateElement();
    }

    public void deleteElement()
    {
        if (!newAction)
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
        mousePointManager = GameObject.Find("InputManager").GetComponent<MousePointManager>();
        updateElement();

    }

    // Update is called once per frame
    void Update()
    {
        if (input.text != "")
        {
            waitTime = float.Parse(input.text);
        }
    }
}
