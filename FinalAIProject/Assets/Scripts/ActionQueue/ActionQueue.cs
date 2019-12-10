using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionQueue : MonoBehaviour
{
    private List<Action> actions = new List<Action>();

    [SerializeField]
    private float totalAvalableActions = 10;

    #region singletonPattern
    public static ActionQueue instance;
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public int getNumActions()
    {
        return actions.Count;
    }

    public int AddAction(float waitTime, Vector3 position)
    {
        if (actions.Count >= totalAvalableActions)
        {
            Debug.Log("Add attempted while list was already full");
            return -1;
        }
        else
        {
            actions.Add(new Action(waitTime, position));
            Debug.Log("Action added to end of list with waitTime: " + waitTime + " and position: " + position);
            return actions.Count - 1;
        }
    }

    public bool removeAction(int index)
    {
        Debug.Log("Remove action called on index " + index);
        if (index >= 0 && index < actions.Count)
        {
            Debug.Log("Action with index " + index + " was removed");
            actions.RemoveAt(index);
            return true;
        }
        else { return false; }
    }

    public void clearActionQueue()
    {
        actions.Clear();
    }

    public bool editAction(int index, float waitTime, Vector3 position)
    {
        actions[index].EditAction(waitTime, position);
        return true;
    }

    public Action GetAction(int index)
    {
        if(index >= 0 && index < actions.Count)
        {
            return actions[index];
        }
        else
        {
            Debug.LogError("Given index is not within the action list");
            return null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
