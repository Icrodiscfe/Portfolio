using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseAiControler : MonoBehaviour
{
    public float AttackDistance, AttackRate;
    public int state;

    private float nextAttack;

    public bool isWalking;
    public bool isAttacking;
    public bool abortAttack;

    public Transform Target = null;
    public NavMeshAgent navMeshAgent;
    public Animator anim;
    public Transform canon = null;
    public ParticleSystem burstParticle;
   

    public virtual void Update()
    {
        CheckForTarget();
        StateMachine();
        AnimControler();
        
        var vel = burstParticle.velocityOverLifetime;
        vel.speedModifierMultiplier = navMeshAgent.velocity.magnitude;
    }

    public virtual void CheckForTarget()
    {
        ;
    }

    void StateMachine()
    {
        switch (state)
        {
            case 0: // Move to target
                Move();
                break;

            case 1: // Attack target
                Attack();
                break;
        }
    }

    void AnimControler()
    {
        if (anim == null)
            return;

        anim.SetBool("IsAttacking", isAttacking);
        anim.SetBool("AbortAttack", abortAttack);
        navMeshAgent.isStopped = !isWalking;
        anim.SetBool("IsWalking", isWalking);
    }

    float remainingDistance = 0f;
    private void Move()
    {
        isWalking = true;

        if (navMeshAgent.remainingDistance > remainingDistance)
            navMeshAgent.stoppingDistance += Time.deltaTime;

        remainingDistance = navMeshAgent.remainingDistance;

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            if (!navMeshAgent.hasPath || Mathf.Abs(navMeshAgent.velocity.sqrMagnitude) < float.Epsilon)
                isWalking = false;
        }

        if ((navMeshAgent.remainingDistance <= AttackDistance) & (Target != null))
        {
            state = 1;
            isWalking = false;
        }
    }

    private void Attack()
    {
        if (Target == null)
        {
            state = 0;
            return;
        }

        if (navMeshAgent.remainingDistance <= AttackDistance)
        {
            if (Time.time > nextAttack)
            {
                nextAttack = Time.time + AttackRate;
                isAttacking = true;
                abortAttack = false;
            }
        }

        if (navMeshAgent.remainingDistance >= AttackDistance)
            if (!isAttacking)
                state = 0;
    }

    public void AttackEnd()
    {
        isAttacking = false;
    }

    public  GameObject FindClosestEnemy(float _distance, string _tag)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(_tag);
        GameObject closest = null;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            if (go != this.gameObject)
            {
                Vector3 diff = go.transform.position - transform.position;
                float curDistance = diff.magnitude;
                if (curDistance < _distance)
                {
                    closest = go;
                    _distance = curDistance;
                }
            }
        }
        return closest;
    }
}
