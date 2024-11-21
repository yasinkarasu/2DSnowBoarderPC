using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] ParticleSystem CrashEffect;
    [SerializeField] AudioClip crashSFX;

    bool hasCrashed = false;
    private int whatever = 10;

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Ground") && !hasCrashed)
        {
            hasCrashed = true;
            FindAnyObjectByType<PlayerController>().DisableContorls();
            CrashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", loadDelay);
        }    
    }

    public void ReloadScene()
    {
        // Mevcut sahneyi yeniden yükler
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
