using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D trigger;
    public TrailRenderer trail;
    public float health = 100;
    public float maxHealth = 100;
    public bool inAir = false;
    public float jumpForce = 10f;
    public float minMoveSpeed = 5f;
    public float moveSpeed = 5f;
    public float horizontalMoveSpeed = 5f;
    public float maxMoveSpeed = 20f;
    public float acceleration = 0.1f;//recovery rate
    public float airTime = 0f;//count up when in air


    public void MouseTick()
    {
        Vector2 mousePos = GameMaster.Instance.mainCamera.ScreenToWorldPoint(Input.mousePosition);
        bool left = mousePos.x < transform.position.x;
        if (Input.GetMouseButton(0))
        {
            rb.MovePosition(rb.position + new Vector2(left ? -1 : 1, 0) * (horizontalMoveSpeed * Time.deltaTime));
        }
    }

    public void Update()
    {
        MouseTick();
        
    }

    public void FixedUpdate()
    {
        
    }
}
