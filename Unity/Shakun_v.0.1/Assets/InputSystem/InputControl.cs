// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/InputControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControl"",
    ""maps"": [
        {
            ""name"": ""Moverse"",
            ""id"": ""e3fb22ed-c4f2-4277-8d97-5a68b7ee1394"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""40bd94f1-e23e-4c9e-9879-6d64511e80e5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""9a4a2d05-743c-4475-bc83-271989fba83f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""12074c53-0142-4001-bb54-101fe44de81f"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33a53965-733e-4e94-864a-c9e17a833d86"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb4b7ff7-d886-4ad0-8447-b4a525ef9309"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Camara"",
            ""id"": ""521a41ac-b6bb-4e30-8370-e6fed0ee745e"",
            ""actions"": [
                {
                    ""name"": ""MoverCamara"",
                    ""type"": ""Value"",
                    ""id"": ""c9ca11ae-7de7-49d0-9eb6-a2b7b3501bb5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3bed6083-50b0-410c-9558-c631e1b5324a"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoverCamara"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Moverse
        m_Moverse = asset.FindActionMap("Moverse", throwIfNotFound: true);
        m_Moverse_Move = m_Moverse.FindAction("Move", throwIfNotFound: true);
        m_Moverse_Run = m_Moverse.FindAction("Run", throwIfNotFound: true);
        // Camara
        m_Camara = asset.FindActionMap("Camara", throwIfNotFound: true);
        m_Camara_MoverCamara = m_Camara.FindAction("MoverCamara", throwIfNotFound: true);
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

    // Moverse
    private readonly InputActionMap m_Moverse;
    private IMoverseActions m_MoverseActionsCallbackInterface;
    private readonly InputAction m_Moverse_Move;
    private readonly InputAction m_Moverse_Run;
    public struct MoverseActions
    {
        private @InputControl m_Wrapper;
        public MoverseActions(@InputControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Moverse_Move;
        public InputAction @Run => m_Wrapper.m_Moverse_Run;
        public InputActionMap Get() { return m_Wrapper.m_Moverse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MoverseActions set) { return set.Get(); }
        public void SetCallbacks(IMoverseActions instance)
        {
            if (m_Wrapper.m_MoverseActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MoverseActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MoverseActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MoverseActionsCallbackInterface.OnMove;
                @Run.started -= m_Wrapper.m_MoverseActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_MoverseActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_MoverseActionsCallbackInterface.OnRun;
            }
            m_Wrapper.m_MoverseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
            }
        }
    }
    public MoverseActions @Moverse => new MoverseActions(this);

    // Camara
    private readonly InputActionMap m_Camara;
    private ICamaraActions m_CamaraActionsCallbackInterface;
    private readonly InputAction m_Camara_MoverCamara;
    public struct CamaraActions
    {
        private @InputControl m_Wrapper;
        public CamaraActions(@InputControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoverCamara => m_Wrapper.m_Camara_MoverCamara;
        public InputActionMap Get() { return m_Wrapper.m_Camara; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CamaraActions set) { return set.Get(); }
        public void SetCallbacks(ICamaraActions instance)
        {
            if (m_Wrapper.m_CamaraActionsCallbackInterface != null)
            {
                @MoverCamara.started -= m_Wrapper.m_CamaraActionsCallbackInterface.OnMoverCamara;
                @MoverCamara.performed -= m_Wrapper.m_CamaraActionsCallbackInterface.OnMoverCamara;
                @MoverCamara.canceled -= m_Wrapper.m_CamaraActionsCallbackInterface.OnMoverCamara;
            }
            m_Wrapper.m_CamaraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoverCamara.started += instance.OnMoverCamara;
                @MoverCamara.performed += instance.OnMoverCamara;
                @MoverCamara.canceled += instance.OnMoverCamara;
            }
        }
    }
    public CamaraActions @Camara => new CamaraActions(this);
    public interface IMoverseActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
    }
    public interface ICamaraActions
    {
        void OnMoverCamara(InputAction.CallbackContext context);
    }
}
