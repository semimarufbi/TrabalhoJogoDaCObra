using System.Collections;
using System.Collections.Generic;
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
        float horizontal = Input.GetAxisRaw("horizontal");
        float vertical = Input.GetAxisRaw("vertical");
        moveDirection = new Vector2(horizontal, vertical);
    }

}
