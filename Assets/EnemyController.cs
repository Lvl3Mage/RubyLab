using System.Collections;
using System.Collections.Generic;
using UnityEngine;

﻿public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;

    Rigidbody2D RB;
    float timer;
    int direction = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }
    
    void FixedUpdate()
    {
        Vector2 position = transform.position;
        
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;;
        }
        
        RB.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyHealthManager player = other.gameObject.GetComponent<RubyHealthManager>();

        if (player != null)
        {
            player.Damage(-1);
        }
    }
}
