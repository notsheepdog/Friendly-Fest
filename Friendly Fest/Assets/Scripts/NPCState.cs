using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCState : MonoBehaviour
{
    public enum State
    {
        Idle, Walking, Looking, Talking
    }

    // parameters
    public float speed = 5;
    public float rotationSpeed = 10;
    public float idleTime = 3;
    public float lookDistance = 5;
    public float wanderPointDistance = 1;
    // wander points are added in the inspector.
    // if no wander points are added in inspector, the NPC's starting position will be added as a wander point.
    public Vector3[] wanderPoints;

    // game objects and components
    Animator anim;
    GameObject player;

    // internal variables
    State currentState;
    float distanceToPlayer;
    int curWanderPointIdx = 0;
    Vector3 curWanderPoint;
    float idleTimeElapsed = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        currentState = State.Idle;
        if (wanderPoints.Length == 0)
        {
            wanderPoints = new Vector3[] { transform.position };
        }
        curWanderPoint = wanderPoints[curWanderPointIdx];
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        switch (currentState)
        {
            case State.Idle:
                UpdateIdle();
                break;
            case State.Walking:
                UpdateWalking();
                break;
            case State.Looking:
                UpdateLooking();
                break;
            case State.Talking:
                UpdateTalking();
                break;
        }
    }

    // idle NPCs are waiting until they go to their next wander point
    void UpdateIdle()
    {
        idleTimeElapsed += Time.deltaTime;

        if (distanceToPlayer <= lookDistance)
        {
            currentState = State.Looking;
        }
        else if (idleTimeElapsed >= idleTime)
        {
            currentState = State.Walking;
        }
        else
        {
            // idle animation
        }
    }

    // walking NPCs are moving towards their next wander point
    void UpdateWalking()
    {
        if (distanceToPlayer <= lookDistance)
        {
            currentState = State.Looking;
            return;
        }

        if (Vector3.Distance(transform.position, curWanderPoint) >= wanderPointDistance)
        {
            curWanderPointIdx = (curWanderPointIdx + 1) % wanderPoints.Length;
            curWanderPoint = wanderPoints[curWanderPointIdx];
        }

        // walking animation
        FaceTarget(curWanderPoint);
        transform.position = Vector3.MoveTowards(transform.position, curWanderPoint, speed * Time.deltaTime);
    }

    // looking NPCs are looking at the player and stopped
    void UpdateLooking()
    {
        if (distanceToPlayer > lookDistance)
        {
            currentState = State.Idle;
        }
        FaceTarget(player.transform.position);
    }

    // talking NPCs are engaged in dialogue
    void UpdateTalking()
    {
        // dialogue animation
    }

    public void DialogueEnter()
    {
        currentState = State.Talking;
    }

    public void DialogueExit()
    {
        currentState = State.Looking;
    }

    void FaceTarget(Vector3 target)
    {
        Vector3 directionToTarget = (target - transform.position).normalized;
        directionToTarget.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }
}