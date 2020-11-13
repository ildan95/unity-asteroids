using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInBorderBehavior : BorderCollisionBehavior
{
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected override void OnCollision(){
        Vector2 clampedPos = transform.position;
        Vector2 velocity = Vector2.zero;
        var size = GetComponent<Collider2D>().bounds.size;

        clampedPos.x = Mathf.Clamp(clampedPos.x, leftBottom.x + size.x/2, rightTop.x - size.x/2);
        clampedPos.y = Mathf.Clamp(clampedPos.y, leftBottom.y + size.y/2, rightTop.y - size.y/2);
        velocity.x = transform.position.x != clampedPos.x ? 0 : rb.velocity.x;
        velocity.y = transform.position.y != clampedPos.y ? 0 : rb.velocity.y;
        
        rb.velocity = velocity;
        transform.position = clampedPos;
    }

    protected override void OnOut(){}
}
