using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public BlockCollision collision = BlockCollision.Full;
    public int            toolboxpos;

    public void Awake() {
        switch(collision) {
            case BlockCollision.Full:
                gameObject.AddComponent<BoxCollider2D>();
                break;
            case BlockCollision.Platform:
                gameObject.AddComponent<PlatformEffector2D>();
                break;
        }
    }

    public enum BlockCollision {
        None,
        Full,
        Platform,
        Slope,
        SteepSlope,
        Slab
    }
}
