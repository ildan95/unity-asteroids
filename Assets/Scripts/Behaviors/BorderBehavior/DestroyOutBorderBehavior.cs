using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutBorderBehavior : BorderCollisionBehavior
{
    protected override void OnCollision(){
        Destroy(gameObject);
    }

    protected override void OnOut(){
        Destroy(gameObject);
    }
}
