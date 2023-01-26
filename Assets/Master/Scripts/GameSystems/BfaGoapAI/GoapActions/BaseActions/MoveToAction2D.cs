using System.Collections;
using System.Collections.Generic;
using SGoap;
using UnityEngine;

/// <summary>
/// Move To base Action that will move based on the Agent Data Target
/// So it will move to the target that has been set on AgentData.Target
/// </summary>
public class MoveToAction2D : CoroutineAction
{
    [Header("Performance:")] [SerializeField]
    protected bool m_isDebug = false;

    [Space, Header("Config:")] [SerializeField]
    protected AIMovement m_movementComponent;

    [SerializeField] private Vector2 m_delayAfterExecutionRange;

    public Vector3 GetDestination => m_movementComponent.GetDestination;

    public override bool PrePerform()
    {
        m_movementComponent.SetReachDestinationState(false);
        return base.PrePerform();
    }

    public override IEnumerator PerformRoutine()
    {
        if (!AgentData.Target)
            yield break;

        m_movementComponent.MoveToOnce(AgentData.Target.position, EMovementState.Run);

        while (!m_movementComponent.ReachedDestination || !m_movementComponent.ReachedEndOfPath)
        {
            if (!AgentData.Target)
                yield break;

            yield return null;
        }

        m_movementComponent.Stop();

        if (m_isDebug) Log("Executing");
        yield return ExecuteRoutine();
        if (m_isDebug) Log("Executed");

        if (m_delayAfterExecutionRange != Vector2.zero)
            yield return new WaitForSeconds(Random.Range(m_delayAfterExecutionRange.x, m_delayAfterExecutionRange.y));

        m_movementComponent.SetReachDestinationState(false);

    }

    protected virtual IEnumerator ExecuteRoutine()
    {
        yield break;
    }
}