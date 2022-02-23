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
                },
                {
                    ""name"": ""Saltar"",
                    ""type"": ""Button"",
                    ""id"": ""d5a1e490-1376-4bc1-9314-bbf286d2ffa5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""6ad347e5-eeb6-4eb3-9ccd-0dfe00528e08"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""10813b6b-7361-41af-ba40-c2fd669259fe"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Saltar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""621a5fe3-0129-456c-9bb9-14011052e1ea"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
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
        },
        {
            ""name"": ""Ataques"",
            ""id"": ""e580b26b-e0f3-4898-b8d2-28b1425073c6"",
            ""actions"": [
                {
                    ""name"": ""L2"",
                    ""type"": ""Button"",
                    ""id"": ""8e23c6e6-a546-4afc-9378-b007740f6f8d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""R2"",
                    ""type"": ""Button"",
                    ""id"": ""f3e4ca2b-f5b1-4057-a712-24df50e8d9f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""L1"",
                    ""type"": ""Button"",
                    ""id"": ""e6442a79-be02-436e-b260-4a9f8a142a7e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""859a3213-d679-4fbc-9e6a-15ce192bbbec"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""L2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0647a49-02b4-4963-ac35-d3c5e13521fd"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""R2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92d71d93-0e82-41ad-9216-55c53c97f913"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""L1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""adbcf254-189a-4441-be0c-0a364836c2b4"",
            ""actions"": [
                {
                    ""name"": ""Pausa"",
                    ""type"": ""Button"",
                    ""id"": ""b311b3e9-329f-497a-bc1d-80bf28da8b20"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""96a07b76-a0cf-4129-800e-155447d5cb0f"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pausa"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""80a24c76-e791-430f-a127-d97a00c1ba1f"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""57d3ae80-3eaf-4d45-bd92-60fbbb200af5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0717e502-c0c3-4930-9395-64b12a20957b"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ChangeKit"",
            ""id"": ""133b1a33-8496-4eaa-b7c2-eb9e63ebf670"",
            ""actions"": [
                {
                    ""name"": ""Water"",
                    ""type"": ""Button"",
                    ""id"": ""38d0e4cf-27e5-4bf3-a676-9d8a39eb292e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Normal"",
                    ""type"": ""Button"",
                    ""id"": ""ee563ebd-6942-4bf0-90fb-22622a38a53e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ef276e98-b17e-4df4-a0b8-cf976b7c9975"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Water"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23716441-24c8-4041-8c9f-22a439b7c616"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Normal"",
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
        m_Moverse_Saltar = m_Moverse.FindAction("Saltar", throwIfNotFound: true);
        m_Moverse_Roll = m_Moverse.FindAction("Roll", throwIfNotFound: true);
        // Camara
        m_Camara = asset.FindActionMap("Camara", throwIfNotFound: true);
        m_Camara_MoverCamara = m_Camara.FindAction("MoverCamara", throwIfNotFound: true);
        // Ataques
        m_Ataques = asset.FindActionMap("Ataques", throwIfNotFound: true);
        m_Ataques_L2 = m_Ataques.FindAction("L2", throwIfNotFound: true);
        m_Ataques_R2 = m_Ataques.FindAction("R2", throwIfNotFound: true);
        m_Ataques_L1 = m_Ataques.FindAction("L1", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Pausa = m_Menu.FindAction("Pausa", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Navigate = m_UI.FindAction("Navigate", throwIfNotFound: true);
        // ChangeKit
        m_ChangeKit = asset.FindActionMap("ChangeKit", throwIfNotFound: true);
        m_ChangeKit_Water = m_ChangeKit.FindAction("Water", throwIfNotFound: true);
        m_ChangeKit_Normal = m_ChangeKit.FindAction("Normal", throwIfNotFound: true);
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
    private readonly InputAction m_Moverse_Saltar;
    private readonly InputAction m_Moverse_Roll;
    public struct MoverseActions
    {
        private @InputControl m_Wrapper;
        public MoverseActions(@InputControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Moverse_Move;
        public InputAction @Run => m_Wrapper.m_Moverse_Run;
        public InputAction @Saltar => m_Wrapper.m_Moverse_Saltar;
        public InputAction @Roll => m_Wrapper.m_Moverse_Roll;
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
                @Saltar.started -= m_Wrapper.m_MoverseActionsCallbackInterface.OnSaltar;
                @Saltar.performed -= m_Wrapper.m_MoverseActionsCallbackInterface.OnSaltar;
                @Saltar.canceled -= m_Wrapper.m_MoverseActionsCallbackInterface.OnSaltar;
                @Roll.started -= m_Wrapper.m_MoverseActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_MoverseActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_MoverseActionsCallbackInterface.OnRoll;
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
                @Saltar.started += instance.OnSaltar;
                @Saltar.performed += instance.OnSaltar;
                @Saltar.canceled += instance.OnSaltar;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
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

    // Ataques
    private readonly InputActionMap m_Ataques;
    private IAtaquesActions m_AtaquesActionsCallbackInterface;
    private readonly InputAction m_Ataques_L2;
    private readonly InputAction m_Ataques_R2;
    private readonly InputAction m_Ataques_L1;
    public struct AtaquesActions
    {
        private @InputControl m_Wrapper;
        public AtaquesActions(@InputControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @L2 => m_Wrapper.m_Ataques_L2;
        public InputAction @R2 => m_Wrapper.m_Ataques_R2;
        public InputAction @L1 => m_Wrapper.m_Ataques_L1;
        public InputActionMap Get() { return m_Wrapper.m_Ataques; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AtaquesActions set) { return set.Get(); }
        public void SetCallbacks(IAtaquesActions instance)
        {
            if (m_Wrapper.m_AtaquesActionsCallbackInterface != null)
            {
                @L2.started -= m_Wrapper.m_AtaquesActionsCallbackInterface.OnL2;
                @L2.performed -= m_Wrapper.m_AtaquesActionsCallbackInterface.OnL2;
                @L2.canceled -= m_Wrapper.m_AtaquesActionsCallbackInterface.OnL2;
                @R2.started -= m_Wrapper.m_AtaquesActionsCallbackInterface.OnR2;
                @R2.performed -= m_Wrapper.m_AtaquesActionsCallbackInterface.OnR2;
                @R2.canceled -= m_Wrapper.m_AtaquesActionsCallbackInterface.OnR2;
                @L1.started -= m_Wrapper.m_AtaquesActionsCallbackInterface.OnL1;
                @L1.performed -= m_Wrapper.m_AtaquesActionsCallbackInterface.OnL1;
                @L1.canceled -= m_Wrapper.m_AtaquesActionsCallbackInterface.OnL1;
            }
            m_Wrapper.m_AtaquesActionsCallbackInterface = instance;
            if (instance != null)
            {
                @L2.started += instance.OnL2;
                @L2.performed += instance.OnL2;
                @L2.canceled += instance.OnL2;
                @R2.started += instance.OnR2;
                @R2.performed += instance.OnR2;
                @R2.canceled += instance.OnR2;
                @L1.started += instance.OnL1;
                @L1.performed += instance.OnL1;
                @L1.canceled += instance.OnL1;
            }
        }
    }
    public AtaquesActions @Ataques => new AtaquesActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Pausa;
    public struct MenuActions
    {
        private @InputControl m_Wrapper;
        public MenuActions(@InputControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pausa => m_Wrapper.m_Menu_Pausa;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Pausa.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnPausa;
                @Pausa.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnPausa;
                @Pausa.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnPausa;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pausa.started += instance.OnPausa;
                @Pausa.performed += instance.OnPausa;
                @Pausa.canceled += instance.OnPausa;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Navigate;
    public struct UIActions
    {
        private @InputControl m_Wrapper;
        public UIActions(@InputControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_UI_Navigate;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Navigate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
            }
        }
    }
    public UIActions @UI => new UIActions(this);

    // ChangeKit
    private readonly InputActionMap m_ChangeKit;
    private IChangeKitActions m_ChangeKitActionsCallbackInterface;
    private readonly InputAction m_ChangeKit_Water;
    private readonly InputAction m_ChangeKit_Normal;
    public struct ChangeKitActions
    {
        private @InputControl m_Wrapper;
        public ChangeKitActions(@InputControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Water => m_Wrapper.m_ChangeKit_Water;
        public InputAction @Normal => m_Wrapper.m_ChangeKit_Normal;
        public InputActionMap Get() { return m_Wrapper.m_ChangeKit; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ChangeKitActions set) { return set.Get(); }
        public void SetCallbacks(IChangeKitActions instance)
        {
            if (m_Wrapper.m_ChangeKitActionsCallbackInterface != null)
            {
                @Water.started -= m_Wrapper.m_ChangeKitActionsCallbackInterface.OnWater;
                @Water.performed -= m_Wrapper.m_ChangeKitActionsCallbackInterface.OnWater;
                @Water.canceled -= m_Wrapper.m_ChangeKitActionsCallbackInterface.OnWater;
                @Normal.started -= m_Wrapper.m_ChangeKitActionsCallbackInterface.OnNormal;
                @Normal.performed -= m_Wrapper.m_ChangeKitActionsCallbackInterface.OnNormal;
                @Normal.canceled -= m_Wrapper.m_ChangeKitActionsCallbackInterface.OnNormal;
            }
            m_Wrapper.m_ChangeKitActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Water.started += instance.OnWater;
                @Water.performed += instance.OnWater;
                @Water.canceled += instance.OnWater;
                @Normal.started += instance.OnNormal;
                @Normal.performed += instance.OnNormal;
                @Normal.canceled += instance.OnNormal;
            }
        }
    }
    public ChangeKitActions @ChangeKit => new ChangeKitActions(this);
    public interface IMoverseActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnSaltar(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
    }
    public interface ICamaraActions
    {
        void OnMoverCamara(InputAction.CallbackContext context);
    }
    public interface IAtaquesActions
    {
        void OnL2(InputAction.CallbackContext context);
        void OnR2(InputAction.CallbackContext context);
        void OnL1(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnPausa(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnNavigate(InputAction.CallbackContext context);
    }
    public interface IChangeKitActions
    {
        void OnWater(InputAction.CallbackContext context);
        void OnNormal(InputAction.CallbackContext context);
    }
}
