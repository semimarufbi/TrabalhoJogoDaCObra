using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] Vector2 direction;
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
    }
    public void MoverCobra()
    {
        float arrendondarX = Mathf.Round(transform.position.x);
        float arrendondarY = Mathf.Round(transform.position.y);
        transform.position = new Vector2(arrendondarX + direction.x, arrendondarY + direction.y);
    }
  
}
