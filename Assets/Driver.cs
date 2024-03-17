using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 150f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float boostspeed = 20f;

    void Update()
    {
        float steerAmount =  -Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount =  Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, steerAmount);
        transform.Translate(0, moveAmount, 0);
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Speed Up Coin")
        {
            Debug.Log("Sped up 2x");
            moveSpeed = boostspeed;
            Destroy(collision.gameObject, 0);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Bumped into obstacle {collision}");
        moveSpeed = slowSpeed;
    }
}
