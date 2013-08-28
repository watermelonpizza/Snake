using AGENT.Contrib.Hardware;
using System;
using System.Collections;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Threading;

namespace Snake
{
    public class StateManager : State
    {
        private State currentState;

        public override void Init()
        {
            currentState = MainMenuScreen.Instance;

            // Event setup
            ButtonHelper.Current.OnButtonPress += ButtonEvent;
            Program.GameTick = new Timer(TickEvent, null, new TimeSpan(0, 0, 1), new TimeSpan(0, 0, 0, 0, 500));

            currentState.Init();
            base.Init();
        }

        public void ChangeState(State toState)
        {
            if (currentState != toState)
                currentState = toState;

            currentState.Init();
        }

        public override void ButtonEvent(Buttons button, InterruptPort port, ButtonDirection direction, DateTime time)
        {
            Program.ButtonStates[button] = direction;
            currentState.ButtonEvent(button, port, direction, time);
            base.ButtonEvent(button, port, direction, time);
        }

        public override void TickEvent(object state)
        {
            Program.Display.Clear();

            currentState.TickEvent(state);
            base.TickEvent(state);

            Program.Display.Flush();
        }
    }
}
