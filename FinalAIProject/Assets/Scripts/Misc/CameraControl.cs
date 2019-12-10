using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float xMod = 1;
    public float yMod = 1;
    public float zoomMod = 1;

    // Update is called once per frame
    void Update()
    {
        float xAxisValue = Input.GetAxisRaw("Horizontal") * xMod;
        float yAxisValue = Input.GetAxisRaw("Vertical") * yMod;
        float cameraZoom = gameObject.GetComponent<Camera>().orthographicSize;
        cameraZoom += Input.GetAxisRaw("Zoom") * zoomMod;

        cameraZoom = Mathf.Clamp(cameraZoom, 5f, 20f);

        if (Camera.current != null)
        {
            Camera.current.transform.Translate(new Vector3(xAxisValue, yAxisValue, 0.0f));
            gameObject.GetComponent<Camera>().orthographicSize = cameraZoom;
        }
    }

    private void Start()
    {
        //Time.timeScale = 0;
    }
}
