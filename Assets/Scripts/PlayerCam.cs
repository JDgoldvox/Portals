using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    //camera 
    public float sensitivityX;
    public float sensitivityY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    bool stopCam = false;

    void Start()
    {
        // Lock and Hide the Cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Cursor.visible = false;

        //when escape is pressed, stop position of camera
        if (Input.GetKeyDown(KeyCode.Escape) && !stopCam)
        {
            stopCam = true;
        }  //when escape is pressed, start position of camera again
        else if(Input.GetKeyDown(KeyCode.Escape) && stopCam)
        {
            stopCam = false;
        }

        if (!stopCam)
        {
            OnLook();
        }
    }

    private void OnLook()
    {
        //Get mouse Axis input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivityX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivityY;

        //add to rotation X and Y
        yRotation += mouseX;
        xRotation -= mouseY;

        //clamp rotation for camera
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate camera and orientation
        //camera
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        //player
        orientation.rotation = Quaternion.Euler(0, yRotation, 0f);
    }
}
