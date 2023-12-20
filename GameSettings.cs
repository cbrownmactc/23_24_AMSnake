﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSnake
{
    public static class GameSettings
    {
        public static int ShakeDuration { get; set; } = 2000;
        public static int BoostSpeed { get; set; } = 40;
        public static bool EnableBGMusic { get; set; } = false;
    }
}
