using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement; // Pastikan menggunakan namespace ini

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;
    private int totalCherries; // Menyimpan jumlah total ceri di level

    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void Start()
    {
        // Menghitung jumlah objek dengan tag "Cherry" pada saat game dimulai
        totalCherries = GameObject.FindGameObjectsWithTag("Cherry").Length;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "Cherries: " + cherries;

            // Memeriksa apakah jumlah ceri yang dikumpulkan sama dengan jumlah total
            if (cherries >= totalCherries)
            {
                // Memuat scene berikutnya. Ganti "NextLevelSceneName" dengan nama scene yang sebenarnya
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
