using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARPlaneManager))]
public class PlaneToggle : MonoBehaviour
{

    private ARPlaneManager planeManager;
    [SerializeField]
    private Text ToggleText;


    // Start is called before the first frame update
    void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
        ToggleText.text = "disable";
    }

    public void TogglePlane()
    {
        planeManager.enabled = !planeManager.enabled;
        string toggleMessage = "";

        if (planeManager.enabled)
        {
            toggleMessage = "disable";
            SetAllPlanesActive(true);
        }
        else
        {
            toggleMessage = "Activate";
            SetAllPlanesActive(false);
        }

        ToggleText.text = toggleMessage;
    }
    private void SetAllPlanesActive(bool Issa)
    {
        foreach(var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(Issa);
        }
    }
}
   
