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
        this.GetComponent<Renderer>().material.color = new Color(0.3f, 0.3f, 0.3f);
        this.transform.Find("Wheel (1)").gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
        this.transform.Find("Wheel (2)").gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
        this.transform.Find("Wheel (3)").gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
        this.transform.Find("Wheel (4)").gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
        this.transform.Find("Base").gameObject.GetComponent<Renderer>().material.color = new Color(0.2f, 0.2f, 0.2f);
        this.transform.Find("Sholder").gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0);
        this.transform.Find("Left Arm").gameObject.GetComponent<Renderer>().material.color = new Color(1, 0.5f, 0);
        this.transform.Find("Right Arm").gameObject.GetComponent<Renderer>().material.color = new Color(1, 0.5f, 0);
        this.transform.Find("Left Eye").gameObject.GetComponentInChildren<Renderer>().material.color = new Color(1, 1, 0);
        this.transform.Find("Right Eye").gameObject.GetComponentInChildren<Renderer>().material.color = new Color(1, 1, 0);
    }

    void Update()
    {
        if (aiState == AIState.Patrol)
        {
            navMeshAgent.speed = 2.5f;
            if (target != null)
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
                            aiState = AIState.InterceptTarget;
                            followTarget();
                        }
                    }
                }
            }
            if (navMeshAgent.remainingDistance < 0.2f)
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
            aiState = AIState.Patrol;
            this.transform.Find("Left Eye").gameObject.GetComponentInChildren<Renderer>().material.color = new Color(1, 1, 0);
            this.transform.Find("Right Eye").gameObject.GetComponentInChildren<Renderer>().material.color = new Color(1, 1, 0);
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
            if (currWaypoint >= waypoints.Length)
            {
                currWaypoint = 0;
                //After one patrol session we can now allow the agent to go to enemy target location
            }
            navMeshAgent.SetDestination(waypoints[currWaypoint].transform.position);
            return;
        }
        if (navMeshAgent.remainingDistance < target.GetComponent<CapsuleCollider>().radius * 1.5f)
        {
            Vector3 deltaV = target.transform.position - this.transform.position;
            float angle = Vector3.Angle(deltaV, this.transform.forward);
            if (angle >= -fov && angle <= fov)
            {
                RaycastHit hit;
                if (Physics.Raycast(this.transform.position, deltaV, out hit, target.GetComponent<CapsuleCollider>().radius * 1.5f))
                {
                    // Future edits such that event trigger happens to state player has been captured and he looses health/losses game
                    if (hit.transform.tag == "Player")
                    {
                        Debug.LogWarning("player captured");
                        hit.transform.position = new Vector3(2.2f, 0.7f, 22.5f);
                    }
                    else
                    {
                        Debug.LogWarning("player not found");
                    }
                }
            }
            aiState = AIState.Reset;
            if (currWaypoint >= waypoints.Length)
            {
                currWaypoint = 0;
                //After one patrol session we can now allow the agent to go to enemy target location
            }
            navMeshAgent.SetDestination(waypoints[currWaypoint].transform.position);
            return;
        }
        else
        {
            navMeshAgent.speed = 5.0f;
            this.transform.Find("Left Eye").gameObject.GetComponentInChildren<Renderer>().material.color = new Color(1, 0, 0);
            this.transform.Find("Right Eye").gameObject.GetComponentInChildren<Renderer>().material.color = new Color(1, 0, 0);
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