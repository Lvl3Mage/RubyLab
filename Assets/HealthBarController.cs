using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
	[SerializeField] Slider healthSlider;
	[SerializeField] float lerpSpeed;
	float currentHealth = 0;
	public void SetHealthRange(float min, float max){
		healthSlider.minValue = min;
		healthSlider.maxValue = max;
	}
	public void SetHealth(float val){
		currentHealth = val;
	}
	void Update(){
		healthSlider.value = Mathf.Lerp(healthSlider.value, currentHealth, lerpSpeed*Time.deltaTime);
	}
}
