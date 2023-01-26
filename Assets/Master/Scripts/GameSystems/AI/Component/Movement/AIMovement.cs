using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class AIMovement : MonoBehaviour
{
    [Header("Movement:")] [SerializeField] private float m_walkMoveSpeed = 2.5f;
    [SerializeField] private float m_runMoveSpeed = 5.5f;
    [SerializeField] private float m_stopAtDistance = 0.7f;

    [Space] [Header("Debug:")] [SerializeField]
    protected bool m_isDebug = false;

    [SerializeField] private Transform m_testTargetMoveTo;

    #region Private Properties

    private Transform _targetMoveTo;

    private IAstarAI _astarAI;
    private Path _currentPath;
    private Rigidbody2D _rigidbody;
    private Collider2D _collider;

    #endregion

    #region Public Properties

    public IAstarAI AstarAI => _astarAI;

    public float WalkSpeed => m_walkMoveSpeed;
    public float RunSpeed => m_runMoveSpeed;

    public bool IsMoving => _astarAI.velocity != Vector3.zero;

    public Vector3 GetDestination => _astarAI.destination;

    public bool HasDestination { get; private set; }
    public bool ReachedEndOfPath { get; private set; }
    public bool ReachedDestination { get; private set; }

    #endregion

    private void Awake()
    {
        _astarAI ??= GetComponent<IAstarAI>();
        _collider ??= GetComponent<Collider2D>();
        _rigidbody ??= GetComponent<Rigidbody2D>();

        if (_astarAI == null)
            Debug.LogError($"No IAstarAI Component Found use either AIPath, AILerp, or RichAI");

    }

    private void Update()
    {

        if (!_astarAI.reachedDestination || !_astarAI.reachedEndOfPath)
        {
            if (Vector2.Distance(transform.position, GetDestination) <= m_stopAtDistance)
            {
                Stop();
                SetReachDestinationState(true);
            }
        }

        if (_targetMoveTo)
        {
            _astarAI.destination = _targetMoveTo.position;

            if (Vector2.Distance(transform.position, GetDestination) <= m_stopAtDistance)
            {
                Stop();
                SetReachDestinationState(true);
            }
        }

        if (m_isDebug)
        {
            if (m_testTargetMoveTo)
            {
                MoveToFollow(m_testTargetMoveTo, EMovementState.Walk);
            }
        }
    }

    public void MoveToOnce(Vector3 destination, EMovementState eMovementState = EMovementState.Walk)
    {
        if (_astarAI == null)
        {
            Debug.LogError($"No IAstarAI Component Found use either AIPath, AILerp, or RichAI");
            return;
        }


        ChangeMoveSpeedState(eMovementState);
        _astarAI.destination = destination;

        SetReachDestinationState(false);

        _astarAI.isStopped = false;
    }

    public void MoveToFollow(Transform destinationTarget, EMovementState eMovementState = EMovementState.Walk)
    {
        if (_astarAI == null)
        {
            Debug.LogError($"No IAstarAI Component Found use either AIPath, AILerp, or RichAI");
            return;
        }


        ChangeMoveSpeedState(eMovementState);
        _targetMoveTo = destinationTarget;

        SetReachDestinationState(false);

        _astarAI.isStopped = false;
    }

    public void Stop()
    {
        _targetMoveTo = null;
        _astarAI.isStopped = true;
    }

    public void SetReachDestinationState(bool reachedDestination)
    {
        HasDestination = !reachedDestination;
        ReachedDestination = reachedDestination;
        ReachedEndOfPath = reachedDestination;
    }

    public void ChangeMoveSpeedState(EMovementState eMovementState)
    {
        _astarAI.maxSpeed = eMovementState switch
        {
            EMovementState.Walk => m_walkMoveSpeed,
            EMovementState.Run => m_runMoveSpeed,
            _ => m_walkMoveSpeed
        };
    }

}