using System;
using System.Collections;
using AGENT.Contrib.Hardware;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Media;
using System.Threading;

namespace Snake
{
    public class Program
    {
        private static Bitmap display;
        private static StateManager stateManager;
        public static StateManager StateManager { get { return stateManager; } }
        public static Bitmap Display { get { return display; } }
        public static Timer GameTick { get; set; }
        public static Hashtable ButtonStates { get; set; }

        public static Font fontNinaB = Resources.GetFont(Resources.FontResources.NinaB);

        public static void Main()
        {
            Initialise();

            stateManager.Init();

            // go to sleep; all further code should be timer-driven or event-driven
            Thread.Sleep(Timeout.Infinite);
        }

        static void Initialise()
        {
            ButtonStates = new Hashtable();
            ButtonStates.Add(Buttons.TopRight, ButtonDirection.Up);
            ButtonStates.Add(Buttons.MiddleRight, ButtonDirection.Up);
            ButtonStates.Add(Buttons.BottomRight, ButtonDirection.Up);
            ButtonHelper.ButtonSetup = new Buttons[] { Buttons.TopRight, Buttons.MiddleRight, Buttons.BottomRight };

            stateManager = new Snake.StateManager();

            // initialize display buffer
            display = new Bitmap(Bitmap.MaxWidth, Bitmap.MaxHeight);
        }
    }
}
