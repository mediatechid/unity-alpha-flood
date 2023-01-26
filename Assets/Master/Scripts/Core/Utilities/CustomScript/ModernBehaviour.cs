using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModernBehaviour : MonoBehaviour
{
    [Header("Update:")] 
    [SerializeField] private float m_intervalUpdate = 0.1f;

    private float _updateTimer;

    protected virtual void Update()
    {
        if (_updateTimer >= m_intervalUpdate)
        {
            IntervalUpdate();
            _updateTimer = 0;
        }
        else
            _updateTimer = m_intervalUpdate;
    }

    protected virtual void IntervalUpdate()
    {

    }
}