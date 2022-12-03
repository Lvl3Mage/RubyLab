using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float LaunchVelocity;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right*LaunchVelocity;
    }
    void Update(){
        if(transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        DestructableEnemy enemy = other.gameObject.GetComponent<DestructableEnemy>();
        if(!enemy){
            return;
        }
        enemy.Damage();
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D col){
        // DestructableEnemy enemy = other.gameObject.GetComponent<DestructableEnemy>();
        // if(!enemy){
        //     return;
        // }
        // enemy.Damage();
        Destroy(gameObject);
    }
}
