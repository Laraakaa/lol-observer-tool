using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using SharpDX.DirectInput;

namespace LoL_Observer_Tool.Controller
{
    internal class ControllerManager
    {
        private static ControllerManager _instance;

        public static ControllerManager GetInstance()
        {
            return _instance ?? (_instance = new ControllerManager());
        }

        private DirectInput _directInput = new DirectInput();
        private Joystick _currentJoystick;
        private JoystickState _state = new JoystickState();
        private GamepadDevice _currentDevice;

        private bool isConnected = false;
        public Poller Poller = new Poller();

        private ControllerManager()
        {

        }

        public virtual IList<GamepadDevice> AvailableDevices()
        {
            IList<GamepadDevice> result = new List<GamepadDevice>();

            foreach (var deviceInstance in _directInput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AttachedOnly))
            {
                GamepadDevice device = new GamepadDevice
                {
                    Guid = deviceInstance.InstanceGuid, Name = deviceInstance.InstanceName
                };

                result.Add(device);
            }

            return result;
        }

        public void Select(GamepadDevice device)
        {
            _currentDevice = device;
        }

        public void Acquire()
        {
            if (_currentDevice == null)
            {
                return;
            }

            _currentJoystick = new Joystick(_directInput, _currentDevice.Guid);

            foreach (DeviceObjectInstance doi in _currentJoystick.GetObjects(DeviceObjectTypeFlags.Axis))
            {
                _currentJoystick.GetObjectPropertiesById(doi.ObjectId).Range = new InputRange(-5000, 5000);
            }

            _currentJoystick.Properties.AxisMode = DeviceAxisMode.Absolute;
            //.SetCooperativeLevel(GCHandle.Alloc(this).AddrOfPinnedObject(), (CooperativeLevel.NonExclusive | CooperativeLevel.Background));
            _currentJoystick.Acquire();

            Poller.SetTarget(ref _state, _currentJoystick);
            Poller.PollBackground();

            isConnected = true;
        }
    }
}
