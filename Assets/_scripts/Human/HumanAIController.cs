using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanAIController : MonoBehaviour
{
    public Transform TargetTransform;

    private Vector3 _destination;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;

    private int _isWalking;
    private int _isAttacking;

    private enum HumanState
    {
        Idle,
        Patrolling,
        Chasing,
        Attacking
    }

    private HumanState CurrentState;


    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        _isWalking = Animator.StringToHash("isWalking");
        _isAttacking = Animator.StringToHash("isAttacking");
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        HandleState();
        
    }

    private void ChangeState(HumanState newState)
    {
        CurrentState = newState;
    }

    public void HandleState()
    {
        if(TargetTransform != null)
        {
            ChangeState(HumanState.Chasing);
        }

        switch (CurrentState)
        {
            case HumanState.Idle:
                IdleActions();

                break;

            case HumanState.Patrolling:

                break;

            case HumanState.Chasing:
                ChasingActions();
                break;

            case HumanState.Attacking:

                break;

            default:
                break;
        }
    }

    private void IdleActions()
    {
        _animator.SetBool(_isWalking, false);
        _animator.SetBool(_isAttacking, false);
    }

    private void PatrollingActions()
    {

    }

    private void ChasingActions()
    {
        _animator.SetBool(_isWalking, true);
        _animator.SetBool(_isAttacking, false);

        _destination = TargetTransform.position;
        _destination.y = transform.position.y;

        _navMeshAgent.SetDestination(_destination);
        //print(_navMeshAgent.destination);
    }

    private void AttackingActions()
    {

    }

}
