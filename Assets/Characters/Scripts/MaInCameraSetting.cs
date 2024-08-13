using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaInCameraSetting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameObject;
    public float hightCameraMore = 10f;
    private float AxisZ;
    void Start()
    {
        var positionObject = gameObject.transform.position;
        AxisZ = positionObject.z;
    }

    // Update is called once per frame
    void Update()
    {
        
        var positionObject = gameObject.transform.position;
        positionObject.z = AxisZ + hightCameraMore;
        transform.position = positionObject;
    }
}
