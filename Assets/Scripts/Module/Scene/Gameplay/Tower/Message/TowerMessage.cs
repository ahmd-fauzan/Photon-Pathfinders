using UnityEngine;

public struct TowerMessage{
    public int countLine;
    public int indexLine;
    public Vector3 positionLine;

    public TowerMessage(int countLine, int indexLine, Vector3 positionLine) {
        this.countLine = countLine;
        this.indexLine = indexLine;
        this.positionLine = positionLine;
    }
}