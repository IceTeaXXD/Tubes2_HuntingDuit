namespace NodeSpace;
class Node {
    /* ATTRIBUTES */
    public int val;
    public bool isStart;
    public bool isTreasure;
    public bool visited;
    
    /* CONSTRUCTOR */
    public Node(int val, bool isStart=false, bool isTreasure=false) {
        this.val = val;
        this.isStart = isStart;
        this.isTreasure = isTreasure;
        this.visited = false;
    }
}