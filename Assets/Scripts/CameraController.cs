using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float mouseX, mouseY;

    [SerializeField]
    private float _cameraResponsiveness=1.0f;

    private Vector3 _camStartAngle;

    // Start is called before the first frame update
    void Start()
    {
        _camStartAngle = this.transform.localEulerAngles;
        if (_cameraResponsiveness<1.0f)
        {
            _cameraResponsiveness = 1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        Vector3 _facing = transform.localEulerAngles;
        _facing.x -= mouseY;
        //this.transform.localEulerAngles = _facing;
        this.transform.localRotation = Quaternion.AngleAxis(_facing.x, Vector3.right); 

        //if (transform.eulerAngles.x>0)
        //{
        //    _facing.x = 0;
        //    this.transform.eulerAngles = _facing;
        //}
        //else if (transform.eulerAngles.x < 30)
        //{
        //    _facing.x = 30;
        //    this.transform.eulerAngles = _facing;
        //}

        //this.transform.localEulerAngles = Vector3.MoveTowards(this.transform.localEulerAngles, _camStartAngle, Time.deltaTime * _cameraResponsiveness);

    }
}
