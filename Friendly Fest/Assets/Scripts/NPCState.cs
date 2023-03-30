using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCState : MonoBehaviour
{
    public enum State
    {
        Idle, Looking, Talking
    }

    public float speed = 5;
    public float rotationSpeed = 10;
    public float lookDistance = 3;
    public float wanderPointDistance = 1;
    public Vector3[] wanderPoints = { new Vector3(0,0,0) };

    Animator anim;
    GameObject player;

    State currentState;
    float distanceToPlayer;
    int curWanderPointIdx = 0;
    Vector3 curWanderPoint;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        currentState = State.Idle;
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
            case State.Looking:
                UpdateLooking();
                break;
            case State.Talking:
                UpdateTalking();
                break;
        }
    }

    void UpdateIdle()
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

        // there will be an animation
        FaceTarget(curWanderPoint);
        transform.position = Vector3.MoveTowards(transform.position, curWanderPoint, speed * Time.deltaTime);
    }

    void UpdateLooking()
    {
        if (distanceToPlayer > lookDistance)
        {
            currentState = State.Idle;
        }
        FaceTarget(player.transform.position);
    }

    void UpdateTalking()
    {
        // there will be an animation
    }

    void FaceTarget(Vector3 target)
    {
        Vector3 directionToTarget = (target - transform.position).normalized;
        directionToTarget.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }
}
