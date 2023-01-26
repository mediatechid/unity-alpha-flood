using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), DefaultExecutionOrder(-1)]
public class PlayerController : Controller<PlayerComponentBase>
{
    [Header("Config:")] [SerializeField] private Transform m_controllerCenterPoint;

    public Transform BodyCenterPoint => m_controllerCenterPoint;
    public Rigidbody2D Rigidbody { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        Rigidbody = GetComponent<Rigidbody2D>();

        foreach (var component in ControllerComponents)
        {
            component.OwnerController = this;
            component.ComponentInit();
        }

    }

    protected override void Update()
    {
        base.Update();

        foreach (var component in ControllerComponents)
        {
            var deltaTime = component.GetUpdateType switch
            {
                UpdateType.Update => Time.deltaTime,
                UpdateType.FixedUpdate => Time.fixedDeltaTime,
                _ => throw new ArgumentOutOfRangeException()
            };

            component.ComponentUpdate(deltaTime);
        }

    }

    protected override void LateUpdate()
    {
        base.LateUpdate();

        foreach (var component in ControllerComponents) component.ComponentLateUpdate();

    }
}