using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBorderBehavior : BorderCollisionBehavior
{
    protected override void OnCollision(){}

    protected override void OnOut(){

        var pos = transform.position;
        var size = GetComponent<Collider2D>().bounds.size;

        if (pos.x < leftBottom.x - size.x/2)
            pos.x = rightTop.x + size.x/2;
        else if (pos.x > rightTop.x + size.x/2)
            pos.x = leftBottom.x - size.x/2;
        if (pos.y < leftBottom.y - size.y/2)
            pos.y = rightTop.y + size.y/2;
        else if (pos.y > rightTop.y + size.y/2)
            pos.y = leftBottom.y - size.y/2;

        transform.position = pos;
    }
}
