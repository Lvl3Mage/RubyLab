using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{   
    [SerializeField] ParticleSystem smokeEffect;
    [SerializeField] float speed;
    [SerializeField] bool vertical;
    [SerializeField] float changeTime = 3.0f;

    bool running = true;
    Rigidbody2D RB;
    float timer;
    int direction = 1;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
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
    public void Stop(){
        running = false;
        smokeEffect.Stop();
        Destroy(smokeEffect.gameObject);
    }
    void FixedUpdate()
    {
        if(!running){
            animator.SetFloat("mvmY", 0);
            animator.SetFloat("mvmX", 0);
            animator.SetBool("fixed", true);
            RB.constraints = RigidbodyConstraints2D.FreezeAll;
            Destroy(GetComponent<DamageZone>());
            return;
        }
        Vector2 position = transform.position;
        
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetFloat("mvmX", 0);
            animator.SetFloat("mvmY", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetFloat("mvmY", 0);
            animator.SetFloat("mvmX", direction);
        }
        
        RB.MovePosition(position);
    }
}
