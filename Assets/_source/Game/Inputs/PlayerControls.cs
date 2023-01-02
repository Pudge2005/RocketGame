//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/_source/Game/Inputs/PlayerControls.inputactions
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

namespace Game.Inputs
{
    public partial class @PlayerControls : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""SpaceShip"",
            ""id"": ""a272e42d-871e-444c-9fcf-1dd9518c3b42"",
            ""actions"": [
                {
                    ""name"": ""MoveInDirection"",
                    ""type"": ""PassThrough"",
                    ""id"": ""95e118fa-cda8-43c4-a923-c2c4f721a727"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveToDestinationPoint"",
                    ""type"": ""PassThrough"",
                    ""id"": ""613f9cdf-d090-41cb-8388-c9635af8752f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SetDestinationPoint"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2d499943-4ef6-4c54-b2dc-302180ee7d41"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WSAD"",
                    ""id"": ""3bbc0ed7-da2d-4708-9673-f6dd92e0a7e8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInDirection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1e0a1a35-99d8-4be5-bb49-ab966fc76fe4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MoveInDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2fc495b3-f30b-4e5c-b5be-f728fb062024"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MoveInDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bf3907bc-c035-407c-bb53-52dfd7a590db"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MoveInDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""69307296-3978-424f-bce3-d3bfe3f66847"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MoveInDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""KeyBoard Arrows"",
                    ""id"": ""c71f1954-bbcf-44ab-81a3-f9fb384ecaa8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInDirection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5c581e9d-8fbe-4d9f-afcf-53800c8df450"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MoveInDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""25552283-bb5c-4cdb-94a7-eb9de438a33d"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MoveInDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""103aff87-1029-4afb-be2c-ece558be618e"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MoveInDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9e044e70-b822-4581-8f08-e882bf92fe9c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MoveInDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""611194a6-c224-487f-a9ad-2ea30910429d"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Pointer;Keyboard and Mouse"",
                    ""action"": ""MoveToDestinationPoint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""241cdb22-d507-4919-98c1-9440e08637d1"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Pointer;Keyboard and Mouse"",
                    ""action"": ""SetDestinationPoint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Pointer"",
            ""bindingGroup"": ""Pointer"",
            ""devices"": [
                {
                    ""devicePath"": ""<Pointer>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // SpaceShip
            m_SpaceShip = asset.FindActionMap("SpaceShip", throwIfNotFound: true);
            m_SpaceShip_MoveInDirection = m_SpaceShip.FindAction("MoveInDirection", throwIfNotFound: true);
            m_SpaceShip_MoveToDestinationPoint = m_SpaceShip.FindAction("MoveToDestinationPoint", throwIfNotFound: true);
            m_SpaceShip_SetDestinationPoint = m_SpaceShip.FindAction("SetDestinationPoint", throwIfNotFound: true);
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

        // SpaceShip
        private readonly InputActionMap m_SpaceShip;
        private ISpaceShipActions m_SpaceShipActionsCallbackInterface;
        private readonly InputAction m_SpaceShip_MoveInDirection;
        private readonly InputAction m_SpaceShip_MoveToDestinationPoint;
        private readonly InputAction m_SpaceShip_SetDestinationPoint;
        public struct SpaceShipActions
        {
            private @PlayerControls m_Wrapper;
            public SpaceShipActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @MoveInDirection => m_Wrapper.m_SpaceShip_MoveInDirection;
            public InputAction @MoveToDestinationPoint => m_Wrapper.m_SpaceShip_MoveToDestinationPoint;
            public InputAction @SetDestinationPoint => m_Wrapper.m_SpaceShip_SetDestinationPoint;
            public InputActionMap Get() { return m_Wrapper.m_SpaceShip; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(SpaceShipActions set) { return set.Get(); }
            public void SetCallbacks(ISpaceShipActions instance)
            {
                if (m_Wrapper.m_SpaceShipActionsCallbackInterface != null)
                {
                    @MoveInDirection.started -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnMoveInDirection;
                    @MoveInDirection.performed -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnMoveInDirection;
                    @MoveInDirection.canceled -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnMoveInDirection;
                    @MoveToDestinationPoint.started -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnMoveToDestinationPoint;
                    @MoveToDestinationPoint.performed -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnMoveToDestinationPoint;
                    @MoveToDestinationPoint.canceled -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnMoveToDestinationPoint;
                    @SetDestinationPoint.started -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnSetDestinationPoint;
                    @SetDestinationPoint.performed -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnSetDestinationPoint;
                    @SetDestinationPoint.canceled -= m_Wrapper.m_SpaceShipActionsCallbackInterface.OnSetDestinationPoint;
                }
                m_Wrapper.m_SpaceShipActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @MoveInDirection.started += instance.OnMoveInDirection;
                    @MoveInDirection.performed += instance.OnMoveInDirection;
                    @MoveInDirection.canceled += instance.OnMoveInDirection;
                    @MoveToDestinationPoint.started += instance.OnMoveToDestinationPoint;
                    @MoveToDestinationPoint.performed += instance.OnMoveToDestinationPoint;
                    @MoveToDestinationPoint.canceled += instance.OnMoveToDestinationPoint;
                    @SetDestinationPoint.started += instance.OnSetDestinationPoint;
                    @SetDestinationPoint.performed += instance.OnSetDestinationPoint;
                    @SetDestinationPoint.canceled += instance.OnSetDestinationPoint;
                }
            }
        }
        public SpaceShipActions @SpaceShip => new SpaceShipActions(this);
        private int m_KeyboardandMouseSchemeIndex = -1;
        public InputControlScheme KeyboardandMouseScheme
        {
            get
            {
                if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
                return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
            }
        }
        private int m_PointerSchemeIndex = -1;
        public InputControlScheme PointerScheme
        {
            get
            {
                if (m_PointerSchemeIndex == -1) m_PointerSchemeIndex = asset.FindControlSchemeIndex("Pointer");
                return asset.controlSchemes[m_PointerSchemeIndex];
            }
        }
        public interface ISpaceShipActions
        {
            void OnMoveInDirection(InputAction.CallbackContext context);
            void OnMoveToDestinationPoint(InputAction.CallbackContext context);
            void OnSetDestinationPoint(InputAction.CallbackContext context);
        }
    }
}
