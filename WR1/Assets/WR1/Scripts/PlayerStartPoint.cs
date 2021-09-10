using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    public GameObject RouteSelectCanvas;

    private GameObject Football;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Football = GameObject.Find("Football");
            Football.SetActive(true);
            RouteSelectCanvas.SetActive(true);
        }
    }
}
