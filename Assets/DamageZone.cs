using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] float damage;
    
    void OnTriggerStay2D(Collider2D other){
        RubyHealthManager healthManager = other.gameObject.GetComponent<RubyHealthManager>(); // bad (Every frame)
        if(!healthManager){
            return;
        }
        healthManager.Damage(damage);
    }
    void OnCollisionEnter2D(Collision2D other){
        RubyHealthManager healthManager = other.gameObject.GetComponent<RubyHealthManager>(); // bad (Every frame)
        if(!healthManager){
            return;
        }
        healthManager.Damage(damage);
    }
}
