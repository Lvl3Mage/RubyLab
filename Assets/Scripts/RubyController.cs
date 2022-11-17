using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    Rigidbody2D RB;
    [SerializeField] float speed;
    [SerializeField] float acceleration;
    [SerializeField] Projectile projectile;
    [SerializeField] Transform projectileLaunchPoint;
    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);
    
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        Vector2 targetVel = new Vector2(hAxis, vAxis) * speed;
        RB.velocity = Vector2.Lerp(RB.velocity, targetVel, acceleration * Time.deltaTime);
        animator.SetFloat("Look X", RB.velocity.x);
        animator.SetFloat("Look Y", RB.velocity.y);
        animator.SetFloat("Speed", RB.velocity.magnitude);
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(projectile, projectileLaunchPoint.position, Quaternion.EulerAngles(0,0,Mathf.Atan2(RB.velocity.y, RB.velocity.x)));
        }
    }
}