using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

      
    private LevelData currentLevel;
    private int levelIndex = -1;
    [SerializeField] private List<LevelData> levels;

    [SerializeField] public GameManager gameManager;

    public bool StartNextLevel(){
        levelIndex++;
        if (levelIndex >= levels.Count){
            return false;
        }
        currentLevel = levels[levelIndex];
        StartLevel();
        return true;
    }
    private void StartLevel(){
        for (var i=0; i < currentLevel.asteroidsCount; i++){
            var pos = BorderDetector.GetRandomPosOnPerimeter();
            BaseEnemy enemy = Instantiate(currentLevel.asteroidPrefab, pos, Quaternion.Euler(0,0, Random.Range(0f, 360f)));
            enemy.AddForwardForse(currentLevel.asteroidSpeed);
            gameManager.AddEnemy(enemy);
        }
    }
}
