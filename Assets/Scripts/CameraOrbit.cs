using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public float lookSensitivity;
    public float minXLook;
    public float maxXLook;
    public Transform camAnchor;

    public bool invertXRotation;

    public float currentXRotation;

    // Start is called before the first frame update
    void Start()
    {
        //Gets rid of mouse cursor and locks it in the centre of screen
        Cursor.lockState = CursorLockMode.Locked;
    }


    //happens at the end of each frame
    private void LateUpdate()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        //horizontal rotation, eulerAngles gets rotaion of player in this case
        transform.eulerAngles += Vector3.up * x * lookSensitivity;

        //vertical rotation
        currentXRotation -= y * lookSensitivity;
        //makes it so that currentXRotation cant be below minXLook or above maxXLook
        currentXRotation = Mathf.Clamp(currentXRotation,minXLook,maxXLook);
        //gets rotaion of the camera anchor
        Vector3 clampedAngle = camAnchor.eulerAngles;
        clampedAngle.x = currentXRotation;

        camAnchor.eulerAngles = clampedAngle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
