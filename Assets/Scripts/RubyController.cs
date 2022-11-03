using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    Rigidbody2D RB;
    [SerializeField] float speed;
    [SerializeField] float acceleration;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        Vector2 targetVel = new Vector2(hAxis, vAxis) * speed;
        RB.velocity = Vector2.Lerp(RB.velocity, targetVel, acceleration * Time.deltaTime);
    }
}