using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1000000000)]
public sealed class GameplayInputManager : InputManagerBase
{

    public InputSystem.GameplayInputActions CharacterInput { get; private set; }

    public static GameplayInputManager Instance { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        CharacterInput = InputSystemInstance.GameplayInput;

        if (!Instance)
            Instance = this;
        else
            Destroy(gameObject);
    }

}