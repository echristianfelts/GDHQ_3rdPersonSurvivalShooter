using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public LayerMask clickmask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //  Left Click to fire.
        //  Cast a Ray from the center of screen.
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed primary button. Screen Position :"+ Input.mousePosition);
            Vector3 clickPos = -Vector3.one;
            //  float _screenTargetX = Screen.width * 0.5f;
            //  float _screenTargetY = Screen.height * 0.5f;
            //Ray ray = Camera.main.ScreenPointToRay(new Vector3(_screenTargetX, _screenTargetY, 0));
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, clickmask))
            {
                clickPos = hit.point;
            }

            if (hit.transform != null)
            {
                Debug.Log("Target :"+ hit.transform.name+". Hit.");
            }
            //  Debug name of object you hit.
        }
    }
}
