using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARSubsystems;


public class FootballCatchManagerProtoScene : MonoBehaviour
{
    public GameObject Football;
    public Transform ThrowStartPoint;
    public float SpeedPower;
    


    // Start is called before the first frame update
    void Start()
    {
        if (Input.touchCount >= 0)
        {
            Football.GetComponent<Rigidbody>().AddForce(ThrowStartPoint.forward * SpeedPower);
        }
    }
    void Update()
    {
        if (Input.touchCount >= 0)
        {
            Football.GetComponent<Rigidbody>().AddForce(ThrowStartPoint.forward * SpeedPower);
        }
    }
}

