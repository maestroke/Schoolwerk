﻿using ScrollingGame.Entity;
using ScrollingGame.Entity.Characters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Move {
    public interface IMoveStrategy {
        void Move(Character c);
    }
}
