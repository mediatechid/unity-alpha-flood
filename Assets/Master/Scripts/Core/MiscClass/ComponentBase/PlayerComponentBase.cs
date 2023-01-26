using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PlayerComponentBase : MonoBehaviour
{

    [Header("Update:")] [SerializeField] private UpdateType m_updateType;

    public PlayerController OwnerController { get; set; }

    public UpdateType GetUpdateType => m_updateType;

    #region Prevents From Child Class using this

    protected void Awake()
    {
    }

    protected void Update()
    {
    }

    protected void LateUpdate()
    {
    }

    #endregion

    public virtual void ComponentInit()
    {
    }

    public virtual void ComponentUpdate(float deltaTime)
    {
    }

    public virtual void ComponentLateUpdate()
    {
    }

}

public enum UpdateType
{
    Update,
    FixedUpdate
}
