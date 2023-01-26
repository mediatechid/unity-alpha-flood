using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementComponent : PlayerComponentBase
{
    [Header("Movement Config : ")] [SerializeField]
    private float m_movementSpeed = 7.5f;

    #region Public Property

    public bool EnableMovement { get; set; } = true;

    public Vector2 MoveDirection { get; private set; }

    public Vector2 LastDirection { get; private set; }

    public Rigidbody2D PhysicBody => OwnerController.Rigidbody;

    public bool IsMoving => MoveDirection != Vector2.zero;

    #endregion

    private Vector3 _deltaMovement;
    private InputAction _movementAction;

    public override void ComponentInit()
    {
        //Movement Input Init
        _movementAction = GameplayInputManager.Instance.CharacterInput.Movement;

    }

    public override void ComponentUpdate(float deltaTime)
    {


        var inputDirection = _movementAction.ReadValue<Vector2>();

        MoveDirection = inputDirection;
        if (inputDirection != Vector2.zero)
            Movement(inputDirection);
        else
            PhysicBody.freezeRotation = true;

    }

    /// <summary>
    /// Base Movement based on 2D Vector Direction
    /// </summary>
    /// <param name="direction"></param>
    public void Movement(Vector2 direction)
    {

        if (direction != Vector2.zero)
            LastDirection = direction;

        if (!EnableMovement)
            return;

        _deltaMovement = direction * (m_movementSpeed * Time.fixedDeltaTime);

        transform.Rotate2DGameObject(MoveDirection);
        PhysicBody.MovePosition(transform.position + _deltaMovement);

    }
}