using UnityEngine;

public class ForwardOnStartBehaviour : MonoBehaviour {
    [SerializeField] private float speed = 10f;
    private Rigidbody2D rb;

    private void Awake() {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Start() {
        rb.velocity = (Vector2)transform.up * speed;
    }
}