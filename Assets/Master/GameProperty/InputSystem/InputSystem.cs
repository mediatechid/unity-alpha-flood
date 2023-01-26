//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Master/GameProperty/InputSystem/InputSystem.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputSystem : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem"",
    ""maps"": [
        {
            ""name"": ""GameplayInput"",
            ""id"": ""e2b7bceb-3e51-4792-a0ac-41e3466f97cf"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""31b2f82e-fd1c-4866-aa68-35677545af07"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""CameraLook"",
                    ""type"": ""Value"",
                    ""id"": ""98bb39d3-227d-4c33-b1e6-1e73fb7fdfe1"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""CameraZoom"",
                    ""type"": ""Value"",
                    ""id"": ""a817ea6b-27bc-4701-9a38-306f76594645"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""Clamp(min=-1,max=1)"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""b2685a9d-7b01-4a68-bdb3-0d90f99be6fa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""5d10dbcf-57c4-43a1-b38e-9ab9c5e7d2d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""45b49b5b-e3a9-4e30-bb07-462fb5bdb8fd"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8bc12d25-b2c5-47f4-9d92-bc99ba48c13b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ba6bdebd-b0d2-48fd-9445-2a11fc6a0a43"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1de5194d-cc27-4708-be42-839e38b5f5e2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""376711b3-b05e-4fb6-9809-e119b7c512ba"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d1eef604-dc7a-45e2-8315-24be215176ec"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""1bf47814-3e0f-4e10-855d-4aa362e6bab0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraLook"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a3d3d3cb-0846-4aee-a4c9-44d23fc8a66d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6ab89f2a-1746-4651-bc07-7ed06f50674c"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ead7fa44-1bca-464a-9848-8e963bf44e35"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e3e80d52-2a32-4997-8475-f87f57917bfa"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2b4cfb50-1fa0-488e-8e5e-6c5bb1e5553f"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2baf0a3-2a2b-44f4-b5ae-a516c6951ce1"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GameplayInput
        m_GameplayInput = asset.FindActionMap("GameplayInput", throwIfNotFound: true);
        m_GameplayInput_Movement = m_GameplayInput.FindAction("Movement", throwIfNotFound: true);
        m_GameplayInput_CameraLook = m_GameplayInput.FindAction("CameraLook", throwIfNotFound: true);
        m_GameplayInput_CameraZoom = m_GameplayInput.FindAction("CameraZoom", throwIfNotFound: true);
        m_GameplayInput_Interact = m_GameplayInput.FindAction("Interact", throwIfNotFound: true);
        m_GameplayInput_Pause = m_GameplayInput.FindAction("Pause", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // GameplayInput
    private readonly InputActionMap m_GameplayInput;
    private IGameplayInputActions m_GameplayInputActionsCallbackInterface;
    private readonly InputAction m_GameplayInput_Movement;
    private readonly InputAction m_GameplayInput_CameraLook;
    private readonly InputAction m_GameplayInput_CameraZoom;
    private readonly InputAction m_GameplayInput_Interact;
    private readonly InputAction m_GameplayInput_Pause;
    public struct GameplayInputActions
    {
        private @InputSystem m_Wrapper;
        public GameplayInputActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_GameplayInput_Movement;
        public InputAction @CameraLook => m_Wrapper.m_GameplayInput_CameraLook;
        public InputAction @CameraZoom => m_Wrapper.m_GameplayInput_CameraZoom;
        public InputAction @Interact => m_Wrapper.m_GameplayInput_Interact;
        public InputAction @Pause => m_Wrapper.m_GameplayInput_Pause;
        public InputActionMap Get() { return m_Wrapper.m_GameplayInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayInputActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayInputActions instance)
        {
            if (m_Wrapper.m_GameplayInputActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GameplayInputActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayInputActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayInputActionsCallbackInterface.OnMovement;
                @CameraLook.started -= m_Wrapper.m_GameplayInputActionsCallbackInterface.OnCameraLook;
                @CameraLook.performed -= m_Wrapper.m_GameplayInputActionsCallbackInterface.OnCameraLook;
                @CameraLook.canceled -= m_Wrapper.m_GameplayInputActionsCallbackInterface.OnCameraLook;
                @CameraZoom.started -= m_Wrapper.m_GameplayInputActionsCallbackInterface.OnCameraZoom;
                @CameraZoom.performed -= m_Wrapper.m_GameplayInputActionsCallbackInterface.OnCameraZoom;
                @CameraZoom.canceled -= m_Wrapper.m_GameplayInputActionsCallbackInterface.OnCameraZoom;
                @Interact.started -= m_Wrapper.m_GameplayInputActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GameplayInputActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GameplayInputActionsCallbackInterface.OnInteract;
                @Pause.started -= m_Wrapper.m_GameplayInputActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameplayInputActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameplayInputActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_GameplayInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @CameraLook.started += instance.OnCameraLook;
                @CameraLook.performed += instance.OnCameraLook;
                @CameraLook.canceled += instance.OnCameraLook;
                @CameraZoom.started += instance.OnCameraZoom;
                @CameraZoom.performed += instance.OnCameraZoom;
                @CameraZoom.canceled += instance.OnCameraZoom;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public GameplayInputActions @GameplayInput => new GameplayInputActions(this);
    public interface IGameplayInputActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCameraLook(InputAction.CallbackContext context);
        void OnCameraZoom(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}