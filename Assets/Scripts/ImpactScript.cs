using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var _scalefix = this.transform.parent.transform.localScale;
        _scalefix.x = 1 / _scalefix.x;
        _scalefix.y = 1 / _scalefix.y;
        _scalefix.z = 1 / _scalefix.z;
        transform.localScale= new Vector3(_scalefix.x, _scalefix.y, _scalefix.z);
        Destroy(this.gameObject, 1.5f);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
