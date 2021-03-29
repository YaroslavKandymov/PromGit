// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/UI/UIInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @UIInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @UIInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""UIInput"",
    ""maps"": [
        {
            ""name"": ""UIMap"",
            ""id"": ""f14c32fc-7397-49fd-a13c-ad078a0d6154"",
            ""actions"": [
                {
                    ""name"": ""OpenPanel"",
                    ""type"": ""Button"",
                    ""id"": ""ed4402e5-6441-4d30-9eeb-4a7a5b5ae616"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6d33f8c9-dd78-4603-8f25-389bf91dfb37"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenPanel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""UI"",
            ""bindingGroup"": ""UI"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // UIMap
        m_UIMap = asset.FindActionMap("UIMap", throwIfNotFound: true);
        m_UIMap_OpenPanel = m_UIMap.FindAction("OpenPanel", throwIfNotFound: true);
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

    // UIMap
    private readonly InputActionMap m_UIMap;
    private IUIMapActions m_UIMapActionsCallbackInterface;
    private readonly InputAction m_UIMap_OpenPanel;
    public struct UIMapActions
    {
        private @UIInput m_Wrapper;
        public UIMapActions(@UIInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @OpenPanel => m_Wrapper.m_UIMap_OpenPanel;
        public InputActionMap Get() { return m_Wrapper.m_UIMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIMapActions set) { return set.Get(); }
        public void SetCallbacks(IUIMapActions instance)
        {
            if (m_Wrapper.m_UIMapActionsCallbackInterface != null)
            {
                @OpenPanel.started -= m_Wrapper.m_UIMapActionsCallbackInterface.OnOpenPanel;
                @OpenPanel.performed -= m_Wrapper.m_UIMapActionsCallbackInterface.OnOpenPanel;
                @OpenPanel.canceled -= m_Wrapper.m_UIMapActionsCallbackInterface.OnOpenPanel;
            }
            m_Wrapper.m_UIMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @OpenPanel.started += instance.OnOpenPanel;
                @OpenPanel.performed += instance.OnOpenPanel;
                @OpenPanel.canceled += instance.OnOpenPanel;
            }
        }
    }
    public UIMapActions @UIMap => new UIMapActions(this);
    private int m_UISchemeIndex = -1;
    public InputControlScheme UIScheme
    {
        get
        {
            if (m_UISchemeIndex == -1) m_UISchemeIndex = asset.FindControlSchemeIndex("UI");
            return asset.controlSchemes[m_UISchemeIndex];
        }
    }
    public interface IUIMapActions
    {
        void OnOpenPanel(InputAction.CallbackContext context);
    }
}
