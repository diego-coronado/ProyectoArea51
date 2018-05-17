using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraPositionInLevel : MonoBehaviour {

    public Transform newCameraPosition;
    public float newCameraSize;

    private bool changePos = false;

    private void Update()
    {
        if(changePos)
        {
            var cameraPosition = Camera.main.transform.position;
            Camera.main.transform.position = Vector3.Lerp(cameraPosition, newCameraPosition.position, 5 * Time.deltaTime);

            var currentCameraSize = Camera.main.orthographicSize;
            Camera.main.orthographicSize = Mathf.Lerp(currentCameraSize, newCameraSize, 5 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var camera = Camera.main;
        changePos = true;
    }
}
