using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float currentHealth { get; private set; }
    public float StartingHealth { get => startingHealth; private set => startingHealth = value; }
    public float previousHealth {get; private set;}

    [SerializeField] private float startingHealth;
    [SerializeField] private float invincibleTime = 2f;
    [SerializeField] GameObject dieParticle;

    public UnityEvent onDie;

    private float timer = 0f;

    void Awake()
    {
        currentHealth = StartingHealth;
    }

    
    void Update()
    {
        timer = timer - Time.deltaTime <= 0 ? 0 : timer - Time.deltaTime;
    }

    public void TakeDamage(float _damage)
    {
        if (timer == 0)
        {
            previousHealth = currentHealth;
            currentHealth = currentHealth - _damage < 0 ? 0 : currentHealth - _damage;

            CheckCurrentHealth();
        }

    }

    public void AddHealth(float _value)
    {
        currentHealth = currentHealth + _value > StartingHealth ? StartingHealth : currentHealth + _value;
    }

    private void Die() {
        if (dieParticle) {
            Instantiate(dieParticle, transform.position, Quaternion.identity);
        }
        onDie.Invoke();
    }

    private void OnParticleCollision(GameObject other) {
        Debug.Log("Particle hit");
        if (other.CompareTag("Spike")) {
            TakeDamage(1);
        }
    }

    public void SetHealthToZero() {
        currentHealth = 0;
        CheckCurrentHealth();
    }

    public void CheckCurrentHealth() {
        if (currentHealth > 0)
        {
            // Debug.Log(gameObject.name + " take damage " + _damage);
            timer = invincibleTime;
            StartCoroutine(StartBlinking());
        }
        else
        {
            Die();
        }
    }

    IEnumerator StartBlinking() {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Color defaultColor = sr.color;
        Color blinkColor = Color.red;

        if (invincibleTime == 0) 
        {
            blinkColor = new Color(defaultColor.r, defaultColor.g, defaultColor.b, 0.5f);
            for (int i = 0; i < 2; i++) {
                sr.color = blinkColor;
                yield return new WaitForSeconds(0.2f);
                sr.color = defaultColor;
                yield return new WaitForSeconds(0.2f);
            }
        } 
        else 
        {
            while (timer > 0) {
                sr.color = blinkColor;
                yield return new WaitForSeconds(0.3f);
                sr.color = defaultColor;
                yield return new WaitForSeconds(0.3f);
            }
        }
        sr.color = defaultColor;
        sr.color = Color.white;
    }

}
