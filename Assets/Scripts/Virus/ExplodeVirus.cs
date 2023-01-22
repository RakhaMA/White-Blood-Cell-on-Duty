using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeVirus : BasicVirus
{
    public GameObject SpikeParticle;
    public float delayBeforeExplode;
    
    private float explodeTimer;
    private bool isCountdown;
    
    // SpriteRenderer sr;

    private void Update() {
        if (isCountdown) {
            explodeTimer -= Time.deltaTime;
        }
    }

    public void Explode() {
        StartCoroutine(StartExplode());
    }

    IEnumerator StartExplode() {
        explodeTimer = delayBeforeExplode;
        isCountdown = true;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Color defaultColor = sr.color;
        Vector3 defaultScale = transform.localScale;
        Vector3 animateScale = defaultScale * 1.75f;
        float blinkDelay = 0.3f;
        

        while (explodeTimer > 1f) {
            sr.color = Color.red;
            transform.localScale = animateScale;
            yield return new WaitForSeconds(blinkDelay);
            sr.color = defaultColor;
            transform.localScale = defaultScale;
            yield return new WaitForSeconds(blinkDelay);
            // blinkDelay /= 2;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z);
        transform.localScale = 2 * defaultScale;
        sr.color = Color.red;
        yield return new WaitForSeconds(1f);
        Instantiate(SpikeParticle, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
