using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    CharacterController CharacterController;
    public GameObject PlayGamePanel;
    public GameObject FootballStart;
    public GameObject PlayerStartPoint;
    
    private AudioSource Intro;
    private GameObject FootballPlayer;

    
    public void RestartScene()
    {
        SceneManager.LoadScene("WR1");
    }

    public void ReplayAudio()
    {
        FootballPlayer = GameObject.Find("US_Football_Player");
        Intro = FootballPlayer.GetComponent<AudioSource>();
        Intro.Play();
    }

    public void RemoveStartPanel()
    {
        PlayGamePanel.SetActive(false);
    }

    public void StartGame()
    {
        CharacterController.WalkToPosition();
        PlayGamePanel.SetActive(false);
    }
}
