using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public bool sensorState = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            sensorState = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            sensorState = false;
        }

    }

}
