using UnityEngine;
using System;

public interface IEnemy {
    event Action<IEnemy> killed;  
    void ApplyDamage(float amount);
}
