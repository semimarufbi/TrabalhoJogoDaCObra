using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] Vector2 direction;
    [SerializeField] List<Transform> snakeBodies;
    [SerializeField] Transform body;
    private void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        if (xAxis != 0)
        {
            direction = Vector2.right * xAxis;
        }
        if (yAxis != 0)
        {
            direction = Vector2.up * yAxis;
        }
    }
    private void FixedUpdate()
    {
        MoverCobra();
        for (int i = snakeBodies.Count - 1; i > 0; i--)
        {
            snakeBodies[i].position = snakeBodies[i - 1].position;
        }
    }
    public void MoverCobra()
    {
        float arrendondarX = Mathf.Round(transform.position.x);
        float arrendondarY = Mathf.Round(transform.position.y);
        transform.position = new Vector2(arrendondarX + direction.x, arrendondarY + direction.y);
    }
    public void Grow()
    {
        Transform SpawnBOdy = Instantiate(body, snakeBodies[snakeBodies.Count - 1].position, quaternion.identity);
        snakeBodies.Add(SpawnBOdy);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Grow();
        }

    }

}
