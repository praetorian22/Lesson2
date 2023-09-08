//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Scripts/Controls.inputactions
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

public partial class @Controls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""KeyAndMouse"",
            ""id"": ""7dda95ae-90c6-4a9a-a77c-7aba9dc43020"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""124be155-15c7-4a20-b586-ab9eafbf1702"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shot"",
                    ""type"": ""Button"",
                    ""id"": ""9c314ee2-6445-4746-86d8-a46077a69de8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""688835a3-b473-40ac-8674-13de009f3a6b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""6c4cebb6-f579-458b-8619-3c1cc15fd28c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""68d3a2ed-9068-4a60-af80-f97a37443902"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e4f5fd7a-6ea4-4286-a9b4-87e8d8ae20fd"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""22a94fdc-b004-4aa4-b49f-7eb6c1ccbbf9"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e29a2372-2aa0-430f-b55f-64b158f2836d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // KeyAndMouse
        m_KeyAndMouse = asset.FindActionMap("KeyAndMouse", throwIfNotFound: true);
        m_KeyAndMouse_Move = m_KeyAndMouse.FindAction("Move", throwIfNotFound: true);
        m_KeyAndMouse_Shot = m_KeyAndMouse.FindAction("Shot", throwIfNotFound: true);
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

    // KeyAndMouse
    private readonly InputActionMap m_KeyAndMouse;
    private List<IKeyAndMouseActions> m_KeyAndMouseActionsCallbackInterfaces = new List<IKeyAndMouseActions>();
    private readonly InputAction m_KeyAndMouse_Move;
    private readonly InputAction m_KeyAndMouse_Shot;
    public struct KeyAndMouseActions
    {
        private @Controls m_Wrapper;
        public KeyAndMouseActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_KeyAndMouse_Move;
        public InputAction @Shot => m_Wrapper.m_KeyAndMouse_Shot;
        public InputActionMap Get() { return m_Wrapper.m_KeyAndMouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyAndMouseActions set) { return set.Get(); }
        public void AddCallbacks(IKeyAndMouseActions instance)
        {
            if (instance == null || m_Wrapper.m_KeyAndMouseActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_KeyAndMouseActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Shot.started += instance.OnShot;
            @Shot.performed += instance.OnShot;
            @Shot.canceled += instance.OnShot;
        }

        private void UnregisterCallbacks(IKeyAndMouseActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Shot.started -= instance.OnShot;
            @Shot.performed -= instance.OnShot;
            @Shot.canceled -= instance.OnShot;
        }

        public void RemoveCallbacks(IKeyAndMouseActions instance)
        {
            if (m_Wrapper.m_KeyAndMouseActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IKeyAndMouseActions instance)
        {
            foreach (var item in m_Wrapper.m_KeyAndMouseActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_KeyAndMouseActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public KeyAndMouseActions @KeyAndMouse => new KeyAndMouseActions(this);
    public interface IKeyAndMouseActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnShot(InputAction.CallbackContext context);
    }
}