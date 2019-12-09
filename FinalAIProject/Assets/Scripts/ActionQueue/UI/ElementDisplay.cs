﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ElementDisplay : MonoBehaviour
{
    public ScrollRect scroll;
    public GameObject actionElementPrefab;

    public void clearList()
    {
        /* foreach (Transform child in scroll.content.transform)
        {
            ActionElement act = child.GetComponent<ActionElement>();
            if(act)
            {
                act.deleteElement();
            }
        } */

        for(int i = scroll.content.transform.childCount-1; i >= 0; i--)
        {
            ActionElement act = scroll.content.GetChild(i).GetComponent<ActionElement>();
            if(act)
            {
                act.deleteElement();
            }
        }
    }

    public void AddActionElement()
    {
        var prefabTemp = Instantiate(actionElementPrefab);
        prefabTemp.transform.SetParent(scroll.content.transform);
    }

    // Start is called before the first frame update
    void Start()
    {
        scroll = gameObject.GetComponent<ScrollRect>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}