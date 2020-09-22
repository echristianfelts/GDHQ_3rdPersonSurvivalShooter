using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float mouseX, mouseY;

    [SerializeField]
    private float _cameraResponsiveness = 1.0f;

    [SerializeField]
    private float _cameraCenterResponsiveness = 1.0f;

    private Vector3 _camStartAngle;

    // Start is called before the first frame update
    void Start()
    {
        _camStartAngle = this.transform.localEulerAngles;

    }

    // Update is called once per frame
    void Update()
    {   
        //  Get Inputs.
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        //  Calculate.
        Vector3 _facing = transform.localEulerAngles;
        _facing.x -= mouseY* _cameraResponsiveness;

        // Set Rotation.
        this.transform.localRotation = Quaternion.AngleAxis(_facing.x, Vector3.right); 

        // Reset Camera Rotation.
        this.transform.localEulerAngles = Vector3.MoveTowards(this.transform.localEulerAngles, _camStartAngle, Time.deltaTime * _cameraCenterResponsiveness);

    }
}
