using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveTo : MonoBehaviour
{

    public Transform target;

    public float minDistance = 5, maxDistance = 20;

    NavMeshAgent agent;
    float startSpeed;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        startSpeed = agent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) < minDistance)
        {
            anim.SetBool("Attack", true);
            agent.speed = 0;
            agent.updateRotation = false;

            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, 360);
            return;
        }
        else
        {
            anim.SetBool("Attack", false);
            agent.speed = startSpeed;
            agent.updateRotation = true;
        }

        if(Vector3.Distance(transform.position, target.position) < maxDistance) {

            agent.destination = target.position;
            anim.SetFloat("Speed", agent.velocity.magnitude);
        }


        Debug.Log("Speed: " + agent.velocity.magnitude);
    }
}

