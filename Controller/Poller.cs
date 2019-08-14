using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharpDX.DirectInput;

namespace LoL_Observer_Tool.Controller
{
    class Poller
    {
        private JoystickState _state;
        private Joystick _joystick;

        private Thread _thread;
        private OnPollReceiveEvent _registeredHandler;

        public delegate void OnPollReceiveEvent(JoystickState currentState);

        public void SetTarget(ref JoystickState state, Joystick joystick)
        {
            _state = state;
            _joystick = joystick;
        }

        public void PollBackground()
        {
            if (_thread != null && _thread.IsAlive)
            {
                _thread.Abort();
            }

            _thread = new Thread(PollForever);

            _thread.Start();
        }

        private void PollForever()
        {
            while (true)
            {
                Poll();
                Thread.Sleep(10);
            }
            // ReSharper disable once FunctionNeverReturns
        }

        private void Poll()
        {
            _joystick.Poll();
            _joystick.GetCurrentState(ref _state);

            _registeredHandler?.Invoke(_state);
        }

        public void OnPollReceive(OnPollReceiveEvent receive)
        {
            _registeredHandler = receive;
        }
    }
}
