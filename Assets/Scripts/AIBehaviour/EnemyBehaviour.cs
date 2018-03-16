using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class EnemyBehaviour : MonoBehaviour
{

    public GameObject[] waypoints;
    public AIState aiState;
    public GameObject target;

    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private int currWaypoint;
    //private float threshHold;
    private bool lastWaypointReached;

    public enum AIState
    {
        Patrol,
        InterceptTarget
    };

    void Awake()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Start()
    {
        //threshHold = 0.5f;
        currWaypoint = 0;
        aiState = AIState.Patrol;
        setNextWaypoint();
    }

    void Update()
    {
        
        if (aiState == AIState.Patrol)
        {
            if (navMeshAgent.remainingDistance == 0)
            {
                setNextWaypoint();
            }
        }
        else if (aiState == AIState.InterceptTarget)
        {
            if (target != null)
            {
                followTarget();
            }
        }
    }

    private void setNextWaypoint()
    {
        if (waypoints.Length <= 0)
        {
            Debug.LogError("array of waypoints has length zero.");
            return;
        }
        /*if (lastWaypointReached)
        {
            aiState = AIState.InterceptTarget;
        }*/
        if (currWaypoint >= waypoints.Length)
        {
            currWaypoint = 0;
            lastWaypointReached = true;
            //After one patrol session we can now allow the agent to go to enemy target location
        }

        navMeshAgent.SetDestination(waypoints[currWaypoint].transform.position);
        currWaypoint += 1;
    }

    private void followTarget()
    {
        if (navMeshAgent.remainingDistance < target.GetComponent<CapsuleCollider>().radius * 3)
        {
            aiState = AIState.Patrol;
            lastWaypointReached = false;
            currWaypoint = 0;
            navMeshAgent.SetDestination(this.transform.position);
            return;
        }
        // assume acceleration is zero due to the time difference in time between frames is small
        Vector3 target_pos = target.transform.position;
        Vector3 curr_pos = this.transform.position;
        Vector3 target_vel = target.GetComponent<UnityEngine.AI.NavMeshAgent>().velocity;
        Vector3 prediction_pos = target_pos + target_vel;
        navMeshAgent.SetDestination(prediction_pos);
    }
}

