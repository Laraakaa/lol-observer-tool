using System;
using System.Collections.Generic;
using System.Windows;
using LoL_Observer_Tool.Controller;
using SharpDX.DirectInput;

namespace LoL_Observer_Tool.UI.Controller
{
    /// <summary>
    /// Interaktionslogik für Controller.xaml
    /// </summary>
    public partial class Controller
    {
        private readonly ControllerManager _manager = ControllerManager.GetInstance();
        private IList<GamepadDevice> _devices;

        public JoystickState State;

        public Controller()
        {
            InitializeComponent();

            _devices = _manager.AvailableDevices();

            ComboDevices.ItemsSource = _devices;


            _manager.Poller.OnPollReceive(Poller_Receive);
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ComboDevices_Selected(object sender, RoutedEventArgs e)
        {
            _manager.Select(ComboDevices.SelectedItem as GamepadDevice);
            _manager.Acquire();
        }

        private void Poller_Receive(JoystickState state)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                State = state;
                SliderCamHorizontal.Value = state.Y;
            }));
        }
    }
}
