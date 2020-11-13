using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BorderCollisionBehavior : MonoBehaviour
{
    protected Vector2 leftBottom, rightTop;

    public bool IsCollisedDebug;
    public bool IsOutDebug;
    public Vector2 posDebug;
    public Vector2 sizeDebug;
    public Vector2 topRightDebug;
    public Vector2 leftBottomDebug;


    private void Start() {
        leftBottom  = BorderDetector.LeftBottom;
        rightTop = BorderDetector.RightTop;
        if (IsCollised()){
            OnCollision();
        }
        if (IsOut()){
            OnOut();
        }
    }

    public bool IsCollised(){
        var pos = transform.position;
        var size = GetComponent<Collider2D>().bounds.size;
        var isCol = BorderDetector.IsCollised(pos, size);
        IsCollisedDebug = isCol;
        IsOutDebug = BorderDetector.IsOut(pos, size);
        posDebug = pos;
        sizeDebug = size;
        topRightDebug = BorderDetector.RightTop;
        leftBottomDebug = BorderDetector.LeftBottom;
        return isCol;
    }

    public bool IsOut(){
        var pos = transform.position;
        var size = GetComponent<Collider2D>().bounds.size;
        return BorderDetector.IsOut(pos, size);
    }

    protected abstract void OnCollision();
    protected abstract void OnOut();

    private void Update() {
        if (IsCollised()){
            OnCollision();
        }
        else if (IsOut()){
            OnOut();
        }
    }
}
