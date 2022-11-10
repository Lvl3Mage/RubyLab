using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyHealthManager : MonoBehaviour
{
	[SerializeField] float maxHealth;
	[SerializeField] Object DamageEffect;
	bool isInvincible = false;
	[SerializeField] float invincibilityTime = 1.0f;
	float currentHealth;
	public float health {
		get{
			return currentHealth;
		}
	}
	void Start()
	{
		currentHealth = maxHealth;
	}
	public bool isFullyHealed(){
		return currentHealth == maxHealth;
	}
	public void Heal(float amount){
		currentHealth += amount;
		currentHealth = Mathf.Clamp(currentHealth,0,maxHealth);
	}
	public void Damage(float amount){
		if(isInvincible){
			return;
		}
		Instantiate(DamageEffect, transform.position, transform.rotation);
		currentHealth -= amount;
		currentHealth = Mathf.Clamp(currentHealth,0,maxHealth);
		StartCoroutine(InvincibilityTimer());
		
	}
	IEnumerator InvincibilityTimer(){
		if(isInvincible){
			yield return null;
		}
		else{
			isInvincible = true;
			yield return new WaitForSeconds(invincibilityTime);
			isInvincible = false;	
		}
		
	}
}
