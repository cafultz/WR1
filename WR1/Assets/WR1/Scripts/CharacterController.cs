using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CharacterController : MonoBehaviour
{
    
    public NavMeshAgent Agent;
    static Animator animator;
    public GameObject FootballStartTarget;
    public GameObject Football;
    public Rigidbody FootballBody;

    private bool atFootballStart;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        atFootballStart = false;
        FootballStartTarget = GameObject.Find("FootballStartTarget");

    }

    // Update is called once per frame
    void Update()
    {
        if(atFootballStart == true)
        {
            Agent.SetDestination(FootballStartTarget.transform.position);
            animator.Play("Walking");
        }
        if (Vector3.Distance(FootballStartTarget.transform.position, transform.position) < 1f)
        {
            atFootballStart = false;
            animator.Play("StopWalking");
        }
    }

    public void WalkToPosition()
    {
        atFootballStart = true;
    }

    public void ThrowBall()
    {
        FootballBody.AddForce(new Vector3(0, 2, 2) * 250);
    }

}
