using UnityEngine;

public class ItemKoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Jika yang menyentuh koin adalah Player
        if (collision.CompareTag("Player"))
        {
            // Cari objek GameManager dan panggil fungsi TambahKoin
            ManajerGame mg = GameObject.Find("GameManager").GetComponent<ManajerGame>();
            if (mg != null)
            {
                mg.TambahKoin(1); // Nambah 1 koin
            }

            // Hancurkan/hilangkan objek koin dari layar
            Destroy(gameObject);
        }
    }
}