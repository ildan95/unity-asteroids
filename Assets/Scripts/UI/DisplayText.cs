using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    protected Text text;
    [SerializeField] protected int value;
    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void UpdateText(){
        text.text = value.ToString();
    }

    protected void Add(int amount=1){
        value += amount;
        UpdateText();
    }
    
    protected void Set(int amount){
        value = amount;
        UpdateText();
    }
}
