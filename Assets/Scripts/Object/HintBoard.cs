using UnityEngine;

public class HintBoard : MonoBehaviour
{
    public GameObject hintPanel;

    private void Start() {
        hintPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            ShowHint();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            CloseHint();
        }
    }

    private void ShowHint()
    {
        hintPanel.SetActive(true);
    }

    private void CloseHint()
    {
        hintPanel.SetActive(false);
    }
}
