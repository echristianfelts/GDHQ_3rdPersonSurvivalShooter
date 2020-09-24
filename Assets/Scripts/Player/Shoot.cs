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
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, clickmask))
            {
                clickPos = hit.point;
            }

            if (hit.transform != null)
            {
                Debug.Log("Target :"+ hit.transform.name+". Hit.");

                if (hit.transform.GetComponent<Health>() == true)
                {

                    hit.transform.GetComponent<Health>().currentHealth -= hit.transform.GetComponent<Health>().damageAmount;
                    Debug.Log("You Shot a thing..!!!");
                }
            }
            //  Debug name of object you hit.
        }
    }
}
