using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayMusic() {
        audioSource.Play();
    }

    public void StopMusic() {
        audioSource.Stop();
    }

}
