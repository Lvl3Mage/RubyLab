using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableEnemy : MonoBehaviour
{
    [SerializeField] Object destructionEffect;
    [SerializeField] EnemyController controller;
    [SerializeField] Transform target;
    bool destroyed = false;
    [ContextMenu("DestroyEnemy")]
    public void Damage(){
        if(destroyed){
            return;
        }
        destroyed = true;
        Instantiate(destructionEffect, target.position, target.rotation);
        controller.Stop();
        // gameObject.SetActive(false);
    }
}
