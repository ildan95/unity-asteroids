using UnityEngine;
using System;

public class BaseEnemy : MonoBehaviour, IEnemy {
    
    public event Action<IEnemy> killed;  
    private Rigidbody2D rb;
    // public static event Action<IEnemy> newEnemyCreated;  


    private void Awake() {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // protected void OnNewEnemyCreated(IEnemy enemy){
    //     newEnemyCreated?.Invoke(enemy);
    // }

    protected virtual void Die(){
        Destroy(gameObject);
    }

    private void OnDestroy() {
        killed?.Invoke(this);
    }

    public Vector3 ShiftedPositionToSize(float angle){
        var size = GetComponent<Collider2D>().bounds.size;
        var pos = transform.position;
        pos.x += size.x * Mathf.Cos(angle * Mathf.Deg2Rad);
        pos.y += size.y * Mathf.Sin(angle * Mathf.Deg2Rad);
        return pos;
    }

    public virtual void AddForwardForse(float speed){
        rb.AddForce((Vector2)transform.up * speed);
    }

    public void ApplyDamage(float amount){
        Die();
    }
}


