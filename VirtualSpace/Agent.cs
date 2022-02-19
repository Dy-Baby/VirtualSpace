﻿/* Copyright (C) 2021 Dylan Cheng (https://github.com/newlooper)

This file is part of VirtualSpace.

VirtualSpace is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

VirtualSpace is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with VirtualSpace. If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Security.Principal;
using VirtualSpace.Config;

namespace VirtualSpace
{
    internal static class Agent
    {
        public static readonly Dictionary<string, string> ValidLangs = new()
        {
            {"en", "English"},
            {"zh-Hans", "中文(简体)"}
        };

        public static ResourceManager Langs = new(
            Assembly.GetExecutingAssembly().GetName().Name + ".Resources.Langs.WinFormStrings",
            typeof( Agent ).Assembly );

        public static float[] Dpi => GetDpi();

        public static bool IsAdministrator()
        {
            var current          = WindowsIdentity.GetCurrent();
            var windowsPrincipal = new WindowsPrincipal( current );
            return windowsPrincipal.IsInRole( WindowsBuiltInRole.Administrator );
        }

        private static float[] GetDpi()
        {
            using var g      = Graphics.FromHwnd( IntPtr.Zero );
            var       scaleX = g.DpiX / Const.DefaultDpi;
            var       scaleY = g.DpiY / Const.DefaultDpi;
            return new[] {scaleX, scaleY};
        }
    }
}