using System.Collections;
using System.Collections.Generic;
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
    public void MoverCobra()
    {

    }
}
