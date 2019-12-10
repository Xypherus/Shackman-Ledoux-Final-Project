using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointManager : MonoBehaviour
{
    private ActionElement elementToEdit;
    private bool currentlyPolling = false;

    public void StartMouseSample(ActionElement returnToElement)
    {
        elementToEdit = returnToElement;
        currentlyPolling = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentlyPolling = false;
    }

    private void MouseSample()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            elementToEdit.setDestPoint(pos);
            currentlyPolling = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentlyPolling) { MouseSample(); }
    }
}
