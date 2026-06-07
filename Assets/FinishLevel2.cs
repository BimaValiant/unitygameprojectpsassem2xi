using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level3"); // Pindah ke Level 3
        }
    }
}