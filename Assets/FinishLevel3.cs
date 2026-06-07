using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Langsung paksa pindah scene ke MainMenu tanpa babibu
            SceneManager.LoadScene("MainMenu");
        }
    }
}