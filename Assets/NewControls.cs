// GENERATED AUTOMATICALLY FROM 'Assets/NewControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @NewControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @NewControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""NewControls"",
    ""maps"": [
        {
            ""name"": ""CarControls"",
            ""id"": ""091ff389-d9da-486d-80fe-ee4d4644cd63"",
            ""actions"": [
                {
                    ""name"": ""Throttle"",
                    ""type"": ""Value"",
                    ""id"": ""86a4693e-2844-4297-bae0-615866081ab0"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Brake"",
                    ""type"": ""Button"",
                    ""id"": ""c63a1ed5-cd24-4ed6-95c8-530bcfbeafd0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Steering"",
                    ""type"": ""Value"",
                    ""id"": ""95ad8fb0-1ccf-410b-9eb6-2ab912f2f1de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Handbrake"",
                    ""type"": ""Button"",
                    ""id"": ""a607857c-7f77-430c-a644-820e7da86ffc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PauseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""118d4ea7-05de-4f29-8d83-5cf1d7742893"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShiftUp"",
                    ""type"": ""Value"",
                    ""id"": ""a3ed29df-e68f-4621-8481-8d97a8327c27"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""ShiftDown"",
                    ""type"": ""Value"",
                    ""id"": ""ae9f9f78-e01a-4ba9-ade2-2dbdbbbe6c42"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cc8a35cd-17aa-49f4-b990-7aaca1f5f812"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fee4515e-6b70-4537-8c01-477286e348ae"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65400dc4-ab62-40cb-80b8-ae3dc01d3771"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""486ec82d-859a-42ca-8bd7-5d00a81903f7"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80e692c6-f014-40e5-865d-bff97eae0d1a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Handbrake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ee62b8b-8a27-476d-b247-81612e885770"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Handbrake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f780717-84d7-4df9-85f9-99acdf0ae75f"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1103442-6c91-4764-9210-506c2088dc93"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1af1df7b-0937-4bef-94c6-277dc68ddda9"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShiftUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b38ee367-353d-4e81-bd21-24b9a5488dda"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShiftUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7388452f-3549-4901-9173-fecf4f02afdf"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShiftDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e9c5d01-9a41-4dc5-8e66-7219d7fd4b9f"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShiftDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""SteeringAxisKeyboard"",
                    ""id"": ""5cd5dd1d-514b-4463-9f3e-ed2654cc6deb"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""615c4c7e-b5f6-47a7-87fa-dc7f558172bf"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ba25da32-cd4e-427d-95a4-b4760635b1ae"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""SteeringAxisController"",
                    ""id"": ""56668b1a-588f-491e-9de3-59c07a3fe3e3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""47d45c32-8a6f-4f62-a855-ce13c52c8693"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""5b21802c-7239-4438-a8bb-85466167462d"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CarControls
        m_CarControls = asset.FindActionMap("CarControls", throwIfNotFound: true);
        m_CarControls_Throttle = m_CarControls.FindAction("Throttle", throwIfNotFound: true);
        m_CarControls_Brake = m_CarControls.FindAction("Brake", throwIfNotFound: true);
        m_CarControls_Steering = m_CarControls.FindAction("Steering", throwIfNotFound: true);
        m_CarControls_Handbrake = m_CarControls.FindAction("Handbrake", throwIfNotFound: true);
        m_CarControls_PauseMenu = m_CarControls.FindAction("PauseMenu", throwIfNotFound: true);
        m_CarControls_ShiftUp = m_CarControls.FindAction("ShiftUp", throwIfNotFound: true);
        m_CarControls_ShiftDown = m_CarControls.FindAction("ShiftDown", throwIfNotFound: true);
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

    // CarControls
    private readonly InputActionMap m_CarControls;
    private ICarControlsActions m_CarControlsActionsCallbackInterface;
    private readonly InputAction m_CarControls_Throttle;
    private readonly InputAction m_CarControls_Brake;
    private readonly InputAction m_CarControls_Steering;
    private readonly InputAction m_CarControls_Handbrake;
    private readonly InputAction m_CarControls_PauseMenu;
    private readonly InputAction m_CarControls_ShiftUp;
    private readonly InputAction m_CarControls_ShiftDown;
    public struct CarControlsActions
    {
        private @NewControls m_Wrapper;
        public CarControlsActions(@NewControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Throttle => m_Wrapper.m_CarControls_Throttle;
        public InputAction @Brake => m_Wrapper.m_CarControls_Brake;
        public InputAction @Steering => m_Wrapper.m_CarControls_Steering;
        public InputAction @Handbrake => m_Wrapper.m_CarControls_Handbrake;
        public InputAction @PauseMenu => m_Wrapper.m_CarControls_PauseMenu;
        public InputAction @ShiftUp => m_Wrapper.m_CarControls_ShiftUp;
        public InputAction @ShiftDown => m_Wrapper.m_CarControls_ShiftDown;
        public InputActionMap Get() { return m_Wrapper.m_CarControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CarControlsActions set) { return set.Get(); }
        public void SetCallbacks(ICarControlsActions instance)
        {
            if (m_Wrapper.m_CarControlsActionsCallbackInterface != null)
            {
                @Throttle.started -= m_Wrapper.m_CarControlsActionsCallbackInterface.OnThrottle;
                @Throttle.performed -= m_Wrapper.m_CarControlsActionsCallbackInterface.OnThrottle;
                @Throttle.canceled -= m_Wrapper.m_CarControlsActionsCallbackInterface.OnThrottle;
                @Brake.started -= m_Wrapper.m_CarControlsActionsCallbackInterface.OnBrake;
                @Brake.performed -= m_Wrapper.m_CarControlsActionsCallbackInterface.OnBrake;
                @Brake.canceled -= m_Wrapper.m_CarControlsActionsCallbackInterface.OnBrake;
                @Steering.started -= m_Wrapper.m_CarControlsActionsCallbackInterface.OnSteering;
                @Steering.performed -= m_Wrapper.m_CarControlsActionsCallbackInterface.OnSteering;
                @Steering.canceled -= m_Wrapper.m_CarControlsActionsCallbackInterface.OnSteering;
                @Handbrake.started -= m_Wrapper.m_CarControlsActionsCallbackInterface.OnHandbrake;
                @Handbrake.performed -= m_Wrapper.m_CarControlsActionsCallbackInterface.OnHandbrake;
                @Handbrake.canceled -= m_Wrapper.m_CarControlsActionsCallbackInterface.OnHandbrake;
                @PauseMenu.started -= m_Wrapper.m_CarControlsActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.performed -= m_Wrapper.m_CarControlsActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.canceled -= m_Wrapper.m_CarControlsActionsCallbackInterface.OnPauseMenu;
                @ShiftUp.started -= m_Wrapper.m_CarControlsActionsCallbackInterface.OnShiftUp;
                @ShiftUp.performed -= m_Wrapper.m_CarControlsActionsCallbackInterface.OnShiftUp;
                @ShiftUp.canceled -= m_Wrapper.m_CarControlsActionsCallbackInterface.OnShiftUp;
                @ShiftDown.started -= m_Wrapper.m_CarControlsActionsCallbackInterface.OnShiftDown;
                @ShiftDown.performed -= m_Wrapper.m_CarControlsActionsCallbackInterface.OnShiftDown;
                @ShiftDown.canceled -= m_Wrapper.m_CarControlsActionsCallbackInterface.OnShiftDown;
            }
            m_Wrapper.m_CarControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Throttle.started += instance.OnThrottle;
                @Throttle.performed += instance.OnThrottle;
                @Throttle.canceled += instance.OnThrottle;
                @Brake.started += instance.OnBrake;
                @Brake.performed += instance.OnBrake;
                @Brake.canceled += instance.OnBrake;
                @Steering.started += instance.OnSteering;
                @Steering.performed += instance.OnSteering;
                @Steering.canceled += instance.OnSteering;
                @Handbrake.started += instance.OnHandbrake;
                @Handbrake.performed += instance.OnHandbrake;
                @Handbrake.canceled += instance.OnHandbrake;
                @PauseMenu.started += instance.OnPauseMenu;
                @PauseMenu.performed += instance.OnPauseMenu;
                @PauseMenu.canceled += instance.OnPauseMenu;
                @ShiftUp.started += instance.OnShiftUp;
                @ShiftUp.performed += instance.OnShiftUp;
                @ShiftUp.canceled += instance.OnShiftUp;
                @ShiftDown.started += instance.OnShiftDown;
                @ShiftDown.performed += instance.OnShiftDown;
                @ShiftDown.canceled += instance.OnShiftDown;
            }
        }
    }
    public CarControlsActions @CarControls => new CarControlsActions(this);
    public interface ICarControlsActions
    {
        void OnThrottle(InputAction.CallbackContext context);
        void OnBrake(InputAction.CallbackContext context);
        void OnSteering(InputAction.CallbackContext context);
        void OnHandbrake(InputAction.CallbackContext context);
        void OnPauseMenu(InputAction.CallbackContext context);
        void OnShiftUp(InputAction.CallbackContext context);
        void OnShiftDown(InputAction.CallbackContext context);
    }
}
