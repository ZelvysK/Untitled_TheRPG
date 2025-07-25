//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""7186ed01-85e1-4211-a975-355fd52bc73c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""8d57b8eb-8d20-49c9-97d4-f311e795a389"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Value"",
                    ""id"": ""c7be826d-228b-4ad9-a047-b2d3707aceb1"",
                    ""expectedControlType"": ""Key"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Value"",
                    ""id"": ""5acb51ec-fe74-4270-ae45-7ff56e71f95e"",
                    ""expectedControlType"": ""Key"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""e8ce33e1-f042-4e8d-bc30-53955396457c"",
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
                    ""id"": ""07f7b545-4cc9-4716-bd70-6e600ea5c550"",
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
                    ""id"": ""bcd6bbc8-363c-4862-bf6f-6afd22895f88"",
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
                    ""id"": ""1612bbe2-bbd6-4722-9c08-a4489b8815a4"",
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
                    ""id"": ""fa66c683-14cf-4bc3-87b0-59c4cc79995a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7744bf74-a38c-48e7-b0d5-caa751d1aae2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6842ca33-7c3d-4f19-9242-7c8769eac47d"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UIElements"",
            ""id"": ""189e2880-483e-48bf-87a3-d8b7d63ff590"",
            ""actions"": [
                {
                    ""name"": ""ExperienceTest"",
                    ""type"": ""Button"",
                    ""id"": ""05f39b39-4b6c-45a3-8dbb-dacff07bbd9c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CharacterTab"",
                    ""type"": ""Button"",
                    ""id"": ""59a7530d-181d-4e53-8dde-24b8ebfe6f99"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""InventoryTab"",
                    ""type"": ""Button"",
                    ""id"": ""bb850b28-d5bf-41d5-92a5-c2264bdaec3b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MapTab"",
                    ""type"": ""Button"",
                    ""id"": ""5803fd64-32ca-4514-bab3-d14ce88345ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SkillsTab"",
                    ""type"": ""Button"",
                    ""id"": ""6e321a21-32b8-4873-997c-4e467e0f69f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""QuestsTab"",
                    ""type"": ""Button"",
                    ""id"": ""6b38aae3-8f77-454d-9cd4-d4991e2d929e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SettingsTab"",
                    ""type"": ""Button"",
                    ""id"": ""5284ab36-83e6-46ad-9cc6-d683cf191c21"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""828e1fe6-3c00-4b59-b599-598380ea1112"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ExperienceTest"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49f4c7ca-4268-4767-a603-0b81ad22ce6f"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CharacterTab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d2f4307-b79f-4cc0-972c-c3677baaa1f4"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InventoryTab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f431b83-37a4-48f8-a117-604ef58ddb84"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InventoryTab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca055fc0-72f6-452b-a3a0-ce59b2b3a8e4"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MapTab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9414300d-3c25-439f-9d10-eb765261337b"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SkillsTab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44097c96-b9aa-41b4-89ba-18bf53429199"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QuestsTab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bf84542-4e91-4726-bfc9-6b6334e7e225"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SettingsTab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Sprint = m_Player.FindAction("Sprint", throwIfNotFound: true);
        // UIElements
        m_UIElements = asset.FindActionMap("UIElements", throwIfNotFound: true);
        m_UIElements_ExperienceTest = m_UIElements.FindAction("ExperienceTest", throwIfNotFound: true);
        m_UIElements_CharacterTab = m_UIElements.FindAction("CharacterTab", throwIfNotFound: true);
        m_UIElements_InventoryTab = m_UIElements.FindAction("InventoryTab", throwIfNotFound: true);
        m_UIElements_MapTab = m_UIElements.FindAction("MapTab", throwIfNotFound: true);
        m_UIElements_SkillsTab = m_UIElements.FindAction("SkillsTab", throwIfNotFound: true);
        m_UIElements_QuestsTab = m_UIElements.FindAction("QuestsTab", throwIfNotFound: true);
        m_UIElements_SettingsTab = m_UIElements.FindAction("SettingsTab", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Sprint;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Sprint => m_Wrapper.m_Player_Sprint;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Sprint.started += instance.OnSprint;
            @Sprint.performed += instance.OnSprint;
            @Sprint.canceled += instance.OnSprint;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Sprint.started -= instance.OnSprint;
            @Sprint.performed -= instance.OnSprint;
            @Sprint.canceled -= instance.OnSprint;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // UIElements
    private readonly InputActionMap m_UIElements;
    private List<IUIElementsActions> m_UIElementsActionsCallbackInterfaces = new List<IUIElementsActions>();
    private readonly InputAction m_UIElements_ExperienceTest;
    private readonly InputAction m_UIElements_CharacterTab;
    private readonly InputAction m_UIElements_InventoryTab;
    private readonly InputAction m_UIElements_MapTab;
    private readonly InputAction m_UIElements_SkillsTab;
    private readonly InputAction m_UIElements_QuestsTab;
    private readonly InputAction m_UIElements_SettingsTab;
    public struct UIElementsActions
    {
        private @PlayerInputActions m_Wrapper;
        public UIElementsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @ExperienceTest => m_Wrapper.m_UIElements_ExperienceTest;
        public InputAction @CharacterTab => m_Wrapper.m_UIElements_CharacterTab;
        public InputAction @InventoryTab => m_Wrapper.m_UIElements_InventoryTab;
        public InputAction @MapTab => m_Wrapper.m_UIElements_MapTab;
        public InputAction @SkillsTab => m_Wrapper.m_UIElements_SkillsTab;
        public InputAction @QuestsTab => m_Wrapper.m_UIElements_QuestsTab;
        public InputAction @SettingsTab => m_Wrapper.m_UIElements_SettingsTab;
        public InputActionMap Get() { return m_Wrapper.m_UIElements; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIElementsActions set) { return set.Get(); }
        public void AddCallbacks(IUIElementsActions instance)
        {
            if (instance == null || m_Wrapper.m_UIElementsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIElementsActionsCallbackInterfaces.Add(instance);
            @ExperienceTest.started += instance.OnExperienceTest;
            @ExperienceTest.performed += instance.OnExperienceTest;
            @ExperienceTest.canceled += instance.OnExperienceTest;
            @CharacterTab.started += instance.OnCharacterTab;
            @CharacterTab.performed += instance.OnCharacterTab;
            @CharacterTab.canceled += instance.OnCharacterTab;
            @InventoryTab.started += instance.OnInventoryTab;
            @InventoryTab.performed += instance.OnInventoryTab;
            @InventoryTab.canceled += instance.OnInventoryTab;
            @MapTab.started += instance.OnMapTab;
            @MapTab.performed += instance.OnMapTab;
            @MapTab.canceled += instance.OnMapTab;
            @SkillsTab.started += instance.OnSkillsTab;
            @SkillsTab.performed += instance.OnSkillsTab;
            @SkillsTab.canceled += instance.OnSkillsTab;
            @QuestsTab.started += instance.OnQuestsTab;
            @QuestsTab.performed += instance.OnQuestsTab;
            @QuestsTab.canceled += instance.OnQuestsTab;
            @SettingsTab.started += instance.OnSettingsTab;
            @SettingsTab.performed += instance.OnSettingsTab;
            @SettingsTab.canceled += instance.OnSettingsTab;
        }

        private void UnregisterCallbacks(IUIElementsActions instance)
        {
            @ExperienceTest.started -= instance.OnExperienceTest;
            @ExperienceTest.performed -= instance.OnExperienceTest;
            @ExperienceTest.canceled -= instance.OnExperienceTest;
            @CharacterTab.started -= instance.OnCharacterTab;
            @CharacterTab.performed -= instance.OnCharacterTab;
            @CharacterTab.canceled -= instance.OnCharacterTab;
            @InventoryTab.started -= instance.OnInventoryTab;
            @InventoryTab.performed -= instance.OnInventoryTab;
            @InventoryTab.canceled -= instance.OnInventoryTab;
            @MapTab.started -= instance.OnMapTab;
            @MapTab.performed -= instance.OnMapTab;
            @MapTab.canceled -= instance.OnMapTab;
            @SkillsTab.started -= instance.OnSkillsTab;
            @SkillsTab.performed -= instance.OnSkillsTab;
            @SkillsTab.canceled -= instance.OnSkillsTab;
            @QuestsTab.started -= instance.OnQuestsTab;
            @QuestsTab.performed -= instance.OnQuestsTab;
            @QuestsTab.canceled -= instance.OnQuestsTab;
            @SettingsTab.started -= instance.OnSettingsTab;
            @SettingsTab.performed -= instance.OnSettingsTab;
            @SettingsTab.canceled -= instance.OnSettingsTab;
        }

        public void RemoveCallbacks(IUIElementsActions instance)
        {
            if (m_Wrapper.m_UIElementsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIElementsActions instance)
        {
            foreach (var item in m_Wrapper.m_UIElementsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIElementsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIElementsActions @UIElements => new UIElementsActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
    }
    public interface IUIElementsActions
    {
        void OnExperienceTest(InputAction.CallbackContext context);
        void OnCharacterTab(InputAction.CallbackContext context);
        void OnInventoryTab(InputAction.CallbackContext context);
        void OnMapTab(InputAction.CallbackContext context);
        void OnSkillsTab(InputAction.CallbackContext context);
        void OnQuestsTab(InputAction.CallbackContext context);
        void OnSettingsTab(InputAction.CallbackContext context);
    }
}
