using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanAIController : MonoBehaviour
{
    public Transform TargetTransform;
    public Transform RoomBounds;

    private NavMeshAgent _navMeshAgent;
    private Animator _animator;

    public LayerMask GroundLayer;
    public LayerMask TargetLayer;

    public Vector3 _destination;
    private bool _destinationSet;
    public float WalkPointRange;

    public Transform SightCentre;
    public float SightRange;
    public bool TargetInSightRange;

    public float AttackRange;
    public bool TargetInAttackRange;
    public float AttackDelay;
    private bool _alreadyAttacked;

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
        ChangeState(HumanState.Idle);
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
        // if player out of range
        // patrol then idle (while player out of range, patrol for number of seconds, then idle)

        // if player within chase range
        // chase player

        // if player within attack range
        // attack player
        // if player alive and still within range
        // attack player

        TargetInSightRange = Physics.CheckSphere(SightCentre.position, SightRange, TargetLayer);
        TargetInAttackRange = Physics.CheckSphere(SightCentre.position, AttackRange, TargetLayer);

        // Update the current state based on the conditions
        if (!TargetInSightRange && !TargetInAttackRange) ChangeState(HumanState.Patrolling);
        else if (TargetInSightRange && !TargetInAttackRange) ChangeState(HumanState.Chasing);
        else if (TargetInSightRange && TargetInAttackRange) ChangeState(HumanState.Attacking);

        switch (CurrentState)
        {
            case HumanState.Idle:
                PerformIdleActions();
                break;
            case HumanState.Patrolling:
                PerformPatrollingActions();
                break;
            case HumanState.Chasing:
                PerformChasingActions();
                break;
            case HumanState.Attacking:
                PerformAttackingActions();
                break;
            default:
                PerformIdleActions();
                break;
        }
    }

    private void PerformIdleActions()
    {
        _animator.SetBool(_isWalking, false);
        _animator.SetBool(_isAttacking, false);

        _navMeshAgent.SetDestination(transform.position);
    }

    private void PerformPatrollingActions()
    {
        _animator.SetBool(_isWalking, true);
        _animator.SetBool(_isAttacking, false);

        if (!_destinationSet || (_destinationSet && _navMeshAgent.pathStatus != NavMeshPathStatus.PathComplete))
        {
            SearchRandomDestination();
        }
        else
        {
            _navMeshAgent.SetDestination(_destination);

            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance) // set stopping distance in inspector
            {
                _destinationSet = false;
            }
        }
    }

    private void PerformChasingActions()
    {
        _animator.SetBool(_isWalking, true);
        _animator.SetBool(_isAttacking, false);

        _destination = TargetTransform.position;
        _destination.y = transform.position.y;

        if (_navMeshAgent.isOnNavMesh)
        {
            FindAndSetPath(_destination);
        }
    }

    private void PerformAttackingActions()
    {
        _navMeshAgent.isStopped = true; // Stop the AI from moving

        Vector3 targetPosition = TargetTransform.position;
        targetPosition.y = transform.position.y; // Keep the same Y position
        transform.LookAt(targetPosition);

        if (!_alreadyAttacked)
        {
            _animator.SetBool(_isWalking, false);
            _animator.SetBool(_isAttacking, true);

            _alreadyAttacked = true;
            Invoke(nameof(ResetAttack), AttackDelay);
        }
    }

    private void FindAndSetPath(Vector3 destination)
    {
        if (!_navMeshAgent.hasPath || _navMeshAgent.isPathStale || _navMeshAgent.pathStatus != NavMeshPathStatus.PathComplete)
        {
            if (NavMesh.FindClosestEdge(destination, out NavMeshHit hit, NavMesh.AllAreas))
            {
                _navMeshAgent.SetDestination(hit.position);
            }
        }
        else
        {
            _navMeshAgent.SetDestination(destination);
        }
    }
    private void SearchRandomDestination()
    {
        Vector3 randomDirection;
        randomDirection.x = Random.Range(-RoomBounds.lossyScale.x, RoomBounds.lossyScale.x);
        randomDirection.y = 0;
        randomDirection.z = Random.Range(-RoomBounds.lossyScale.z, RoomBounds.lossyScale.z);

        randomDirection += transform.position;

        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, WalkPointRange, NavMesh.AllAreas))
        {
            _destination = hit.position;
            _destinationSet = true;
        }
    }

    private void ResetAttack()
    {
        _alreadyAttacked = false;
        _navMeshAgent.isStopped = false; // Enable AI movement again

        // Update destination to player's position
        _destination = TargetTransform.position;
        _destination.y = transform.position.y;
        _navMeshAgent.SetDestination(_destination);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(SightCentre.position, AttackRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(SightCentre.position, SightRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, WalkPointRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(Vector3.zero, RoomBounds.lossyScale);
    }
}
