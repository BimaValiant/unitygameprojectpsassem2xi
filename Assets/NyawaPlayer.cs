using UnityEngine;
using UnityEngine.SceneManagement;

public class NyawaPlayer : MonoBehaviour
{
    public int nyawa = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kalau koordinat fisik Player menabrak objek ber-Tag Enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            nyawa -= 1; // Kurangi nyawa 1
            Debug.Log("Aduh kena musuh! Sisa Nyawa: " + nyawa);

            if (nyawa <= 0)
            {
                // Kalau nyawa habis, otomatis mental balik ke MainMenu
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}