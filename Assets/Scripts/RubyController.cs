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
    [SerializeField] Camera cam;
    [SerializeField] AudioSource stepsAudioSource;
    [SerializeField] float stepSoundThreshold;
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
        UpdateAudioSource();
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dir = mousePos - new Vector2(transform.position.x, transform.position.y);
            Instantiate(projectile, projectileLaunchPoint.position, Quaternion.EulerAngles(0,0,Mathf.Atan2(dir.y, dir.x)));
        }
    }
    void UpdateAudioSource(){
        if(RB.velocity.magnitude >= stepSoundThreshold){
            stepsAudioSource.volume = 1;
        }
        else{
            stepsAudioSource.volume = 0;
        }
    }
}