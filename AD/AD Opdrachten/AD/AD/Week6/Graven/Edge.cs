﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Week6.Graven {
    public class Edge {
        public Vertex destination;
        public double cost;

        public Edge(Vertex dest, double cost) {
            destination = dest;
            this.cost = cost;
        }
    }
}
