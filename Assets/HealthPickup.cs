using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] float healAmount;
    [SerializeField] Object effect;
    void OnTriggerEnter2D(Collider2D other){
        RubyHealthManager healthManager = other.gameObject.GetComponent<RubyHealthManager>();
        if(!healthManager){
            return;
        }
        if(healthManager.isFullyHealed()){
            return;
        }
        healthManager.Heal(healAmount);
        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
    
    }
}
