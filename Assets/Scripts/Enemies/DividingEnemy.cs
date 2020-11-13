using UnityEngine;
using System;
using Random=UnityEngine.Random;

public class DividingEnemy : BaseEnemy, IEnemyCreator {
    public event Action<IEnemy> newEnemyCreated;  
    protected float _speed;
    [SerializeField] private int divideCount = 2;
    [SerializeField] private BaseEnemy newEnemy; 


    protected override void Die(){
        CreateParts();
        base.Die();
    }
    
    protected void CreateParts(){
        float dAngle = 180f / (divideCount+1);
        float angle = UnityEngine.Random.Range(0, 360f);
        for (var i=0; i < divideCount; i++){
            BaseEnemy part = Instantiate(newEnemy, transform.position, Quaternion.Euler(0,0,angle));
            part.transform.position = part.ShiftedPositionToSize(angle);
            part.AddForwardForse(_speed);
            angle += Random.Range(dAngle*0.5f, dAngle*1.5f);
            newEnemyCreated?.Invoke(part);
        }
    }

    public override void AddForwardForse(float speed)
    {
        base.AddForwardForse(speed);
        _speed = speed;
    }


}
