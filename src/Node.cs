using System;
using System.Collections.Generic;
using System.IO;

namespace NodeSpace;
class Node {
    public int val;
    public bool isStart;
    public bool isTreasure;
    
    public Node(int val, bool isStart=false, bool isTreasure=false) {
        this.val = val;
        this.isStart = isStart;
        this.isTreasure = isTreasure;
    }
}