using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Moving => Input.GetAxis("Vertical");
    public float Rotation => Input.GetAxis("Horizontal");
    public bool IsShooting => Input.GetKey(KeyCode.Space);
}
