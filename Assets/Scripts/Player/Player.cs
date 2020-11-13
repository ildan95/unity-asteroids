using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{   
    public event Action damaged;  
    [SerializeField] private int life = 3;
    [SerializeField] private bool isInvulnerable = false;
    public int Life => life;
    public bool IsAlive => life > 0;

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        var enemy = other.gameObject.GetComponent<IEnemy>();
        if (enemy != null){
            ApplyDamage();
        }
    }    

    public void ApplyDamage(){
        if (isInvulnerable)
            return;
        life -= 1;
        damaged?.Invoke();
        if (life > 0){
            Reestablish();
        }
    }

    private void Reestablish(){
        transform.position = new Vector3(0,0,0);
        rb.velocity = Vector2.zero;
        StartCoroutine(SetInvulnerable());
    }

    IEnumerator SetInvulnerable(){
        isInvulnerable = true;
        yield return new WaitForSeconds(2f);
        isInvulnerable = false;
    }
}
