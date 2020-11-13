using UnityEngine;

public interface IBullet {
    void OnEnemyCollision(IEnemy enemy);
    void OnAnotherCollision(Collision2D other);
}
