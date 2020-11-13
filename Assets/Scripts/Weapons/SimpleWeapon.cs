using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] private float shootSpeed = 3f;
    private float shootCooldown = 0f;

    public GameObject bulletPrefab;

    public bool CanShoot(){
        return IsCooldownEnd();
    }
    public void Shoot(){
        if (CanShoot()){
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            shootCooldown = 1 / shootSpeed;
        }
    }

    private bool IsCooldownEnd(){
        return shootCooldown <= 0;
    }
    private void Update() {
        if (!IsCooldownEnd()){
            shootCooldown -= Time.deltaTime;
        }
    }
}
