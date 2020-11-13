using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelData", menuName = "Data/LevelData", order = 0)]
public class LevelData : ScriptableObject {
    public BaseEnemy asteroidPrefab;
    public int asteroidsCount;
    public float asteroidSpeed;
}

