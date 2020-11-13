using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{   
    public static event Action<IEnemy> enemyKilled;  
    [SerializeField] private Player player;

    [SerializeField] private LevelManager levelManager;
    [SerializeField] private Text gameOverText;


    private List<IEnemy> enemies = new List<IEnemy>();
    private void Start() {
        if (!levelManager.StartNextLevel()){
            throw new UnityException("Levels not set to LevelManager");
        }
        gameOverText.gameObject.SetActive(false);
    }

    private void InvokeEnemyKilled(IEnemy enemy){
        enemyKilled?.Invoke(enemy);
    }
    
    public void AddEnemy(IEnemy enemy){
        enemies.Add(enemy);
        tryAddEventToEnemyCreator(enemy);
        enemy.killed += RemoveEnemy;
        enemy.killed += InvokeEnemyKilled;
    }

    public void RemoveEnemy(IEnemy enemy){
        enemies.Remove(enemy);
        tryRemoveEventFromEnemyCreator(enemy);
        enemy.killed -= InvokeEnemyKilled;
        enemy.killed -= RemoveEnemy;
        CheckEndLevel();
    }

    private void CheckEndLevel(){
        if (enemies.Count == 0){
            if (!levelManager.StartNextLevel()){
                // ToDo: Show win congratulations
            }
        }
    }

    private void tryAddEventToEnemyCreator(IEnemy enemy){
        if (enemy is IEnemyCreator){
            (enemy as IEnemyCreator).newEnemyCreated += AddEnemy;
        }
    }

    private void OnPlayerDamaged(){
        if (player.IsAlive){
            player.gameObject.transform.position = new Vector3(0,0,0);
        }
        else{
            player.gameObject.SetActive(false);
            ShowGameOver();
        }
    }

    private void ShowGameOver(){
        gameOverText.gameObject.SetActive(true);
    }

    

    private void tryRemoveEventFromEnemyCreator(IEnemy enemy){
        if (enemy is IEnemyCreator){
            (enemy as IEnemyCreator).newEnemyCreated -= AddEnemy;
        }
    }

    private void OnEnable() {
        for (int i=0; i <enemies.Count; i++){
            tryAddEventToEnemyCreator(enemies[i]);
        }  
        player.damaged += OnPlayerDamaged;
    }
    private void OnDisable() {
        for (int i=0; i <enemies.Count; i++){
            tryRemoveEventFromEnemyCreator(enemies[i]);
        }  
        player.damaged -= OnPlayerDamaged;
    }
}
