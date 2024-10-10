using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField]
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(horizontal, vertical);
    }
    private void FixedUpdate()
    {
        Vector3 moveposition = (speed * Time.fixedDeltaTime * moveDirection.normalized) + rb.position;
        rb.MovePosition(moveposition);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Food"))
        {
            GameManager.instance.OnFoodCollected();
        }
    }
}
