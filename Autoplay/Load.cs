﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BehaviorSharp;
using BehaviorSharp.Components.Conditionals;
using LeagueSharp;
using LeagueSharp.Common;

namespace AIM.Autoplay
{
    internal class Load
    {
        public Load()
        {
            Game.OnWndProc += OnWndProc;
            CustomEvents.Game.OnGameLoad += OnGameLoad;
            Game.OnGameUpdate += OnGameUpdate;
        }

        private static int _loadTickCount;
        public static bool ModeLoaded = false;

        public static void OnWndProc(EventArgs args)
        {
            //Draw AIMLoading.jpg
        }

        public static void OnGameLoad(EventArgs args)
        {
            _loadTickCount = Environment.TickCount;

        }

        public static void OnGameUpdate(EventArgs args)
        {
            if (Utility.Map.GetMap().Type == Utility.Map.MapType.HowlingAbyss)
            {
                try
                {
                    if (!ModeLoaded &&
                        (Environment.TickCount - _loadTickCount > 60000 || ObjectManager.Player.Level > 3))
                    {
                        var carryMode = new Modes.Carry();
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
            else
            {
                Console.WriteLine("Map not yet supported, use AutoSharpporting ;)");
            }
        }
    }
}
