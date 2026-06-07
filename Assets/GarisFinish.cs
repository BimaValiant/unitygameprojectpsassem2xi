using UnityEngine;
using UnityEngine.SceneManagement;

public class GarisFinish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kalau objek yang menembus sensor finish ber-Tag Player
        if (collision.CompareTag("Player"))
        {
            // Otomatis pindah halaman ke Level 2
            SceneManager.LoadScene("Level2");
        }
    }
}