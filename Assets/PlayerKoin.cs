using UnityEngine;
using TMPro; // Baris ini WAJIB ada biar bisa manggil TextMeshPro

public class PlayerKoin : MonoBehaviour
{
    public int jumlahKoin = 0; // Memori nyimpen angka
    public TextMeshProUGUI teksKoin; // Wadah buat narik UI Teks dari Canvas

    private void Start()
    {
        // Pas game mulai, pastikan layarnya nampilin angka 0
        UpdateTeksKoin();
    }

    // Fungsi ini otomatis jalan kalau Player nabrak sesuatu yang "Is Trigger"-nya nyala
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Mengecek apakah yang ditabrak itu punya Tag "Koin"
        if (collision.gameObject.CompareTag("Koin"))
        {
            jumlahKoin++; // Tambahin poinnya 1
            UpdateTeksKoin(); // Perbarui tulisan di layar

            Destroy(collision.gameObject); // Hancurkan (hilangkan) koinnya dari map biar seolah-olah keambil
        }
    }

    // Fungsi khusus buat ngatur tulisannya
    void UpdateTeksKoin()
    {
        if (teksKoin != null)
        {
            teksKoin.text = "Koin: " + jumlahKoin.ToString();
        }
    }
}