using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionTrigger : MonoBehaviour
{
    public GameObject PlayGameCanvas;

    private GameObject FootballPlayer;
    private AudioSource Intro;
    private Animator Talking;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FootballPlayer = GameObject.Find("US_Football_Player");
            Intro = FootballPlayer.GetComponent<AudioSource>();

            Talking = FootballPlayer.GetComponent<Animator>();

            Intro.Play();
            Talking.Play("Acknowledge");
        }
    }


    private void Update()
    {
        if (Intro.isPlaying == false)
        {
            PlayGameCanvas.SetActive(true);
        }
        else if (Intro.isPlaying == true)
        {
            PlayGameCanvas.SetActive(false);
        }
    }
}
