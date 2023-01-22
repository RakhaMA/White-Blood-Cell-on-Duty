using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedPlatform : MonoBehaviour
{
    public GameObject[] platforms;

    private void Start() {
        // gos = GetComponentsInChildren<GameObject>();
        foreach (GameObject platform in platforms) {
            Color defaultColor = platform.GetComponent<SpriteRenderer>().color;
            Color transparent = new Color(defaultColor.r, defaultColor.g, defaultColor.b, 0f);
            platform.GetComponent<SpriteRenderer>().color = transparent;
            platform.GetComponent<Collider2D>().enabled = false;
        }
    }

    public void ActivatePlatform(Interactable interactable) {
        foreach (GameObject platform in platforms) {
            StartCoroutine(Activate(platform));
        }
        interactable.IsUsed = true;
    }

    IEnumerator Activate(GameObject go) {
        SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
        Collider2D col = go.GetComponent<Collider2D>();

        Color currentColor = sr.color;
        float alpha = currentColor.a;

        while (currentColor.a < 1) {
            alpha += 0.01f;
            Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            sr.color = newColor;
            currentColor = sr.color;
            yield return new WaitForSeconds(0.01f);
        }
        col.enabled = true;

    }


}
