using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScore : DisplayText
{
    private void AddScore(IEnemy enemy){
        Add();
    }

    private void OnEnable() {
        GameManager.enemyKilled += AddScore;
    }
    private void OnDisable() {
        GameManager.enemyKilled -= AddScore;
    }
}
