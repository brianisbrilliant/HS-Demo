using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{

    public Transform target;

    public float minDistance = 5, maxDistance = 20;

    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target.position) < minDistance) return;

        if(Vector3.Distance(transform.position, target.position) < maxDistance) {

            agent.destination = target.position;
        }
        
    }
}
