using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPointAction : MoveToAction2D
{
    [Header("Required Data:")]
    [SerializeField] private Transform m_targetPoint;

    public override bool PrePerform()
    {
        AgentData.Target = m_targetPoint;
        return base.PrePerform();
    }

    protected override IEnumerator ExecuteRoutine()
    {
        AgentData.Target = null;
        return base.ExecuteRoutine();
    }
}
