using UnityEngine;

public static class BorderDetector {

    private static Vector2 leftBottom, rightTop;
    public static Vector2 Size => new Vector2(rightTop.x - leftBottom.x, rightTop.y - leftBottom.y);
    public static Vector2 LeftBottom {
        get{
            if (leftBottom == Vector2.zero)
                leftBottom = (Vector2)Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
            return leftBottom;
        }
        private set{}
    }

    public static Vector2 RightTop {
        get{
            if (rightTop == Vector2.zero)
                rightTop = (Vector2)Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
            return rightTop;
        }
        private set{}
    }

    public static bool IsCollised(Vector2 pos, Vector2 size){
        return pos.x + size.x/2 >= RightTop.x && pos.x - size.x/2 <= RightTop.x
            || pos.x - size.x/2 <= LeftBottom.x && pos.x + size.x/2 >= LeftBottom.x
            || pos.y + size.y/2 >= RightTop.y && pos.y - size.y/2 <= RightTop.y
            || pos.y - size.y/2 <= LeftBottom.y && pos.y + size.y/2 >= LeftBottom.y;
    }

    public static bool IsOut(Vector2 pos, Vector2 size){
        return pos.x - size.x/2 > RightTop.x 
            || pos.x + size.x/2 < LeftBottom.x
            || pos.y - size.y/2 > RightTop.y
            || pos.y + size.y/2 < LeftBottom.y;
    }

    public static Vector2 GetRandomPosOnPerimeter(){
        Vector2 pos = RightTop;
        int direction = -1;

        if (Random.Range(0, 2) == 0){
            pos = LeftBottom;
            direction = 1;
        }
        if (Random.Range(0, 2) == 0){
            pos.x += Random.Range(0, Size.x) * direction;
        }
        else{
            pos.y += Random.Range(0, Size.y) * direction;
        }
        return pos;
    }
}