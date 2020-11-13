using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : ForwardOnStartBehaviour, IBullet
{
    public void OnEnemyCollision(IEnemy enemy){
        enemy.ApplyDamage(1f);
        Destroy(gameObject);
    }

    public void OnAnotherCollision(Collision2D other){
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player")
            return;
    
        var enemy = other.gameObject.GetComponent<IEnemy>();
        if (enemy != null){
            OnEnemyCollision(enemy);
        }
        else{
            OnAnotherCollision(other);
        }
    }    
}
