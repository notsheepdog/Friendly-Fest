using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCNavState : NPCState
{
    NavMeshAgent agent;

    protected override void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    protected override void MoveToTarget(Vector3 target)
    {
        // movement is handled by NavMesh
    }

    protected override void IdleEnter()
    {
        base.IdleEnter();
    }

    protected override void WalkingEnter()
    {
        base.WalkingEnter();
        agent.SetDestination(curWanderPoint);
    }

    protected override void LookingEnter()
    {
        base.LookingEnter();
        agent.SetDestination(transform.position);
    }
}
