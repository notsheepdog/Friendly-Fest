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
    public float lookDistance = 8;
    public float wanderPointDistance = 1;
    public float fov = 135;
    // wander points are added in the inspector.
    // if no wander points are added in inspector, the NPC's starting position will be added as a wander point.
    public Vector3[] wanderPoints;

    // game objects and components
    Animator anim;
    GameObject player;

    // internal variables
    public State currentState;
    float distanceToPlayer;
    int curWanderPointIdx = 0;
    protected Vector3 curWanderPoint;
    float idleTimeElapsed = 0;

    protected virtual void Start()
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

    protected virtual void MoveToTarget(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    // idle NPCs are waiting until they go to their next wander point
    void UpdateIdle()
    {
        idleTimeElapsed += Time.deltaTime;

        if (distanceToPlayer <= lookDistance && CanSeePlayer())
        {
            LookingEnter();
        }
        else if (idleTimeElapsed >= idleTime)
        {
            WalkingEnter();
        }
        else
        {
            anim.SetInteger("animState", 1);
        }
    }

    // walking NPCs are moving towards their next wander point
    void UpdateWalking()
    {
        if (distanceToPlayer <= lookDistance && CanSeePlayer())
        {
            LookingEnter();
        }
        else if (Vector3.Distance(transform.position, curWanderPoint) <= wanderPointDistance)
        {
            IdleEnter();
        }
        else
        {
            // walking animation
            FaceTarget(curWanderPoint);
            MoveToTarget(curWanderPoint);
        }
    }

    // looking NPCs are looking at the player and stopped
    void UpdateLooking()
    {
        if (distanceToPlayer > lookDistance)
        {
            IdleEnter();
        }
        FaceTarget(player.transform.position);
        anim.SetInteger("animState", 1);
    }

    // talking NPCs are engaged in dialogue
    void UpdateTalking()
    {
        anim.SetInteger("animState", 2);
    }

    public void DialogueEnter()
    {
        currentState = State.Talking;
    }

    public void DialogueExit()
    {
        currentState = State.Looking;
    }

    protected virtual void IdleEnter()
    {
        currentState = State.Idle;
        idleTimeElapsed = 0f;
    }

    protected virtual void WalkingEnter()
    {
        currentState = State.Walking;
        curWanderPointIdx = (curWanderPointIdx + 1) % wanderPoints.Length;
        curWanderPoint = wanderPoints[curWanderPointIdx];
    }

    protected virtual void LookingEnter()
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

    bool CanSeePlayer()
    {
        Vector3 directionToPlayer = player.transform.position - (transform.position + new Vector3(0, 1, 0));
        float angle = Vector3.Angle(directionToPlayer, transform.forward);
        if (angle <= fov / 2)
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Vector3 sightLine = transform.position + (transform.forward * lookDistance);
        Vector3 rightLine = transform.position + ((Quaternion.Euler(0, 0.5f * fov, 0) * transform.forward) * lookDistance);
        Vector3 leftLine = transform.position + ((Quaternion.Euler(0, -0.5f * fov, 0) * transform.forward) * lookDistance);
        Debug.DrawLine(transform.position, sightLine, Color.red);
        Debug.DrawLine(transform.position, rightLine, Color.red);
        Debug.DrawLine(transform.position, leftLine, Color.red);
        foreach (Vector3 wanderPoint in wanderPoints)
        {
            Debug.DrawLine(transform.position, wanderPoint, Color.cyan);
        }
    }
}
