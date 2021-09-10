using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARSubsystems;

public class FieldManager : MonoBehaviour
{
    public ARRaycastManager aRRaycastManager;
    public ARPlaneManager aRPlaneManager;
    public GameObject footballCharactersPrefab;
    public GameObject Field;
    public GameObject PointerObject;


    private bool isObjectPlaced;
    private List<ARRaycastHit> aRRaycastHits = new List<ARRaycastHit>();


    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>(); 
        PointerObject = this.transform.GetChild(0).gameObject;
        PointerObject.SetActive(false);
    }

    void Update()
    {

        if (Input.touchCount > 0 && isObjectPlaced == false)


        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                if (Input.touchCount == 1)
                {

                    {
                        //Rraycast Planes
                        if (aRRaycastManager.Raycast(touch.position, aRRaycastHits))
                            {
                                var pose = aRRaycastHits[0].pose;
                                CreateField(pose.position);
                                TogglePlaneDetection(false);
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void CreateField(Vector3 position)
        {
            Field = Instantiate(footballCharactersPrefab, position, Quaternion.identity);
            Field.AddComponent<ARAnchor>();
            isObjectPlaced = true;


        }

        private void TogglePlaneDetection(bool state)
        {
            foreach (var plane in aRPlaneManager.trackables)
            {
                plane.gameObject.SetActive(state);
            }
        }

        public void SetPlaneTrackablesInactive()
        {
            if (isObjectPlaced)
            {
                foreach (var plane in aRPlaneManager.trackables)
                {
                    plane.gameObject.SetActive(false);
                }

                PointerObject.SetActive(false);
            }
        }
    }

