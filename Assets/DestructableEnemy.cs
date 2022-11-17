using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableEnemy : MonoBehaviour
{
    [SerializeField] Object destructionEffect;
    [SerializeField] EnemyController controller;
    [ContextMenu("DestroyEnemy")]
    public void Damage(){
        Instantiate(destructionEffect, transform.position, transform.rotation);
        controller.Stop();
        // gameObject.SetActive(false);
    }
}
