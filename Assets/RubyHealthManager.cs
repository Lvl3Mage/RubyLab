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
	HealthBarController healthbar;
	void Start()
	{
		currentHealth = maxHealth;
		healthbar = GameObject.FindWithTag("Healthbar").GetComponent<HealthBarController>();
		healthbar.SetHealthRange(0, maxHealth);
		healthbar.SetHealth(currentHealth);
	}
	public bool isFullyHealed(){
		return currentHealth == maxHealth;
	}
	public void Heal(float amount){
		currentHealth += amount;
		currentHealth = Mathf.Clamp(currentHealth,0,maxHealth);
		healthbar.SetHealth(currentHealth);
	}
	public void Damage(float amount){
		if(isInvincible){
			return;
		}
		Instantiate(DamageEffect, transform.position, transform.rotation);
		currentHealth -= amount;
		currentHealth = Mathf.Clamp(currentHealth,0,maxHealth);
		healthbar.SetHealth(currentHealth);
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
