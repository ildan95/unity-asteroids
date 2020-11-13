using UnityEngine;
using System;

public interface IEnemyCreator {
    event Action<IEnemy> newEnemyCreated;  
}
