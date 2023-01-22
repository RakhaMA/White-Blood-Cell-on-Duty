using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]

public class HealthBar : MonoBehaviour
{
    private Health playerHealth;
    [SerializeField] private Image HealthBarTotal;
    [SerializeField] private Image HealthBarCurrent;

    public AnimationCurve healthUpdateSpeedCurve;
    public float healthUpdateDuration = 1f;

    private float elapsedTime;
    private float previousFillAmount;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<Health>();
        HealthBarTotal = GameObject.Find("HealthBarTotal").GetComponent<Image>();
        HealthBarCurrent = GameObject.Find("HealthBarCurrent").GetComponent<Image>();
        HealthBarTotal.fillAmount = playerHealth.StartingHealth / 10;
        HealthBarCurrent.fillAmount = HealthBarTotal.fillAmount;

    }

    // Update is called once per frame
    void Update()
    {
        // previousFillAmount = playerHealth.currentHealth / 10;

        HealthBarCurrent.fillAmount = playerHealth.currentHealth / 10;

        // if (playerHealth.currentHealth != playerHealth.previousHealth) {
            // HealthBarCurrent.fillAmount = Mathf.Lerp(playerHealth.previousHealth / 10, playerHealth.currentHealth / 10, Time.deltaTime);
        // }
        
        // if (previousFillAmount != playerHealth.currentHealth / 10) {

        //     UpdateHealthBar(previousFillAmount, playerHealth.currentHealth / 10);
        // }
    }

    public void UpdateHealthBar(float previousValue, float nextValue) {
        elapsedTime = elapsedTime + Time.deltaTime > healthUpdateDuration ? healthUpdateDuration : elapsedTime + Time.deltaTime;
        float percentageComplete = elapsedTime / healthUpdateDuration;

        HealthBarCurrent.fillAmount = Mathf.Lerp(previousValue, nextValue, healthUpdateSpeedCurve.Evaluate(percentageComplete));
    }
}
