using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARCore;

public class PlacementManager : MonoBehaviour
{

    public ARRaycastManager aRRaycastManager;
    public GameObject PointerObject;


    // Start is called before the first frame update
    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        PointerObject = this.transform.GetChild(0).gameObject;
        PointerObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        List<ARRaycastHit> hitpoint = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hitpoint, TrackableType.Planes);
        if (hitpoint.Count > 0)
        {
            transform.position = hitpoint[0].pose.position;
            transform.rotation = hitpoint[0].pose.rotation;
            if(!PointerObject.activeInHierarchy)
            {
                PointerObject.SetActive(true);
            }
        }
    }
}
