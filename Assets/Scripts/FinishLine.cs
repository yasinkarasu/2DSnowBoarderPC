/*
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;     
    [SerializeField] ParticleSystem finishEffect; 
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("LoadNextLevel", loadDelay); 
        }
    }
    void LoadNextLevel()
    {
        if (gameObject.name == "FinishLine1") 
        {
            // Eğer bu birinci Finish Line ise Level2'yi yükle
            SceneManager.LoadScene("Level2");
        }
        else if (gameObject.name == "FinishLine2")
        {
            // Eğer bu ikinci Finish Line ise MainMenu'ye dön
            SceneManager.LoadScene("MainMenu");
        }
    }
}
*/
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // UI bileşenleri için gerekli

public class FinishLine : MonoBehaviour
{
    [SerializeField] float loadDelay = 1.5f;     // Yazı ve geçiş için bekleme süresi
    [SerializeField] ParticleSystem finishEffect; 
    [SerializeField] Text levelText; // Canvas'taki yazı bileşeni
    [SerializeField] string levelCompleteMessage = "2. Level'e Geçtin!"; // Gösterilecek mesaj

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            finishEffect.Play(); // Efekti başlat
            GetComponent<AudioSource>().Play(); // Ses çal
            StartCoroutine(ShowLevelMessageAndLoadNextLevel()); // Coroutine başlat
        }
    }

    IEnumerator ShowLevelMessageAndLoadNextLevel()
    {
        // Yazıyı göster
        levelText.text = levelCompleteMessage;
        levelText.gameObject.SetActive(true); // Yazının görünür olduğundan emin ol

        yield return new WaitForSeconds(loadDelay); // Bekle

        // Sonraki seviyeyi yükle
        if (gameObject.name == "FinishLine1") 
        {
            SceneManager.LoadScene("Level2");
        }
        else if (gameObject.name == "FinishLine2")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
