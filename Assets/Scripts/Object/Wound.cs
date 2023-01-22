using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wound : MonoBehaviour
{
    SpriteRenderer sr;

    private void Start() {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Fix(Interactable interactable) {
        StartCoroutine(FixProcess(interactable));
    }

    IEnumerator FixProcess(Interactable interactable) {
        Color currentColor = sr.color;
        float alpha = sr.color.a;

        while (sr.color.a < 1) {
            currentColor = sr.color;
            alpha += 0.05f;
            Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            sr.color = newColor;
            yield return new WaitForSeconds(0.1f);
        }
        interactable.IsUsed = true;
        Debug.Log("Wound Healed");
    }
}
