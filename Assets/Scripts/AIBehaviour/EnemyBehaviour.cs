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
    private float fov = 60f;
    private Vector3 last_seen_target_pos;
    private Vector3 last_seen_target_vel;

    public enum AIState
    {
        Patrol,
        InterceptTarget,
        //Reset State for now allows the AI to go back to patrolling after reaching the target
        //Or the last seen location of the target.
        Reset
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
    }

    void Update()
    {
        if (aiState == AIState.Patrol)
        {
            if (target != null)
            {
                Vector3 deltaV = target.transform.position - this.transform.position;
                float angle = Vector3.Angle(deltaV, this.transform.forward);
                if (angle >= - fov && angle <= fov)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(this.transform.position, deltaV, out hit))
                    {
                        if (hit.transform.tag == "Player")
                        {
                            aiState = AIState.InterceptTarget;
                            followTarget();
                        }
                    }
                }
            }
            if (navMeshAgent.remainingDistance == 0f)
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
        else if (aiState == AIState.Reset)
        {
            Vector3 deltaV = target.transform.position - this.transform.position;
            float angle = Vector3.Angle(deltaV, this.transform.forward);
            if (angle <= -fov || angle >= fov)
            {
                aiState = AIState.Patrol;
            }
            else
            {
                transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * 40f, Space.World);
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
            //After one patrol session we can now allow the agent to go to enemy target location
        }
        navMeshAgent.SetDestination(waypoints[currWaypoint].transform.position);
        currWaypoint += 1;
    }

    private void followTarget()
    {
        if (navMeshAgent.remainingDistance > 10f)
        {
            aiState = AIState.Reset;
            currWaypoint = 0;
            navMeshAgent.SetDestination(this.transform.position);
            return;
        }
        if (navMeshAgent.remainingDistance < target.GetComponent<CapsuleCollider>().radius * 2f)
        {
            Vector3 deltaV = target.transform.position - this.transform.position;
            float angle = Vector3.Angle(deltaV, this.transform.forward);
            if (angle >= -fov && angle <= fov)
            {
                RaycastHit hit;
                if (Physics.Raycast(this.transform.position, deltaV, out hit, target.GetComponent<CapsuleCollider>().radius * 2f))
                {
                    // Future edits such that event trigger happens to state player has been captured and he looses health/losses game
                    if (hit.transform.tag == "Player")
                    {
                        Debug.LogWarning("player captured");
                    }
                    else
                    {
                        Debug.LogWarning("player not found");
                    }
                }
            }
            aiState = AIState.Reset;
            currWaypoint = 0;
            navMeshAgent.SetDestination(this.transform.position);
            return;
        }
        else
        {
            Vector3 deltaV = target.transform.position - this.transform.position;
            float angle = Vector3.Angle(deltaV, this.transform.forward);
            if (angle >= -fov && angle <= fov)
            {
                RaycastHit hit;
                if (Physics.Raycast(this.transform.position, deltaV, out hit))
                {
                    if (hit.transform.tag == "Player")
                    {
                        last_seen_target_pos = target.transform.position;
                        navMeshAgent.SetDestination(last_seen_target_pos);
                    }
                }
            }
            Vector3 last_seen_pos = last_seen_target_pos;
            navMeshAgent.SetDestination(last_seen_pos);
        }
        // assume acceleration is zero due to the time difference in time between frames is small
    }
}

