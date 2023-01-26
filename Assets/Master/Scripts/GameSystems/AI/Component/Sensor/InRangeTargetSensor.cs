using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using SGoap;
using UnityEngine.Events;


public class InRangeTargetSensor : ModernBehaviour //, IDataBind<AgentBasicData>
{

    [Header("Config:")] [SerializeField] private float m_maxRange = 5;
    [SerializeField] private Transform m_agentCenterPoint;

    [Space] [Header("Performance:")] [SerializeField]
    private LayerMask m_layerTarget;

    [SerializeField] private int m_maxTargetDetection = 10;
    [Space] [SerializeField] private Color m_gizmoColor = Color.red;

    private Collider2D[] _detectedCollider;
    private readonly List<ITargetable> _targetInRange = new();
    private AgentBasicData _agentData;

    protected UnityAction<ITargetable> OnSeeTarget;
    protected UnityAction EndSeeTarget;

    public ITargetable Target { get; private set; }

    public bool HasTargetInRange => _targetInRange.Count > 0;

    public bool HasTarget => Target != null;

    private void Awake()
    {
        _detectedCollider = new Collider2D[m_maxTargetDetection];

    }

    protected override void IntervalUpdate()
    {

        if (FindSurroundingTarget())
        {
            Target = GetClosestTarget();
            OnSeeTarget?.Invoke(Target);
            //_agentData.Target = Target.transform;
        }
        else
        {
            Target = null;
            EndSeeTarget?.Invoke();
        }
    }

    public bool FindSurroundingTarget()
    {
        //Clearing the cached target and collider in the array below
        Array.Clear(_detectedCollider, 0, _detectedCollider.Length);
        _targetInRange.Clear();

        //Detect surrounding colliders 
        var size =
            Physics2D.OverlapCircleNonAlloc(
                m_agentCenterPoint.position, m_maxRange, _detectedCollider, m_layerTarget);

        //Return if the size is 0
        if (!(size > 0))
            return false;

        //Adding the ITargetable collider in the List
        foreach (var colliderEntity in _detectedCollider)
        {
            if (!colliderEntity)
                continue;

            if (colliderEntity.gameObject == _agentData.Agent.gameObject)
                continue;


            if (colliderEntity.TryGetComponent(out ITargetable cacheTargetEntity))
                _targetInRange.Add(cacheTargetEntity);

        }

        return HasTargetInRange;
    }

    public ITargetable GetClosestTarget()
    {
        if (_targetInRange.Count <= 0)
            return null;

        ITargetable cacheTarget = _targetInRange[0];

        foreach (var cEntityTarget in _targetInRange)
        {
            var selfPos = _agentData.CenterPosition;
            var distanceEntity1 =
                Vector2.Distance(selfPos, cacheTarget.transform.position);
            var distanceEntity2 =
                Vector2.Distance(selfPos, cEntityTarget.transform.position);

            if (distanceEntity1 >= distanceEntity2)
                cacheTarget = cEntityTarget;

        }

        return cacheTarget;
    }
    //
    //public void Bind(AgentBasicData context)
    //{
    //    _agentData = context;
    //}

#if UNITY_EDITOR

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = m_gizmoColor;
            if (_agentData != null)
                Gizmos.DrawWireSphere(_agentData.CenterPosition, m_maxRange);
        }

#endif
}
