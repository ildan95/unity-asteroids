using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayLife : DisplayText
{
    [SerializeField] private Player player;
    private void AddScore(IEnemy enemy){
        Add();
    }

    private void Start() {
        UpdateValue();
    }
    private void UpdateValue(){
        Set(player.Life);
    }

    private void OnEnable() {
        player.damaged += UpdateValue;
    }
    private void OnDisable() {
        player.damaged -= UpdateValue;
    }
}
