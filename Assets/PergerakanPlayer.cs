using UnityEngine;

public class PergerakanPlayer : MonoBehaviour
{
    public float kecepatan = 5f;
    public float kekuatanLompat = 12f;
    private Rigidbody2D rb;
    private bool bisaLompat;
    private Animator anim; // Variabel buat manggil Animator

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // Mengambil komponen Animator di Player
    }

    void Update()
    {
        // Jalan kiri kanan pake tombol A dan D atau Panah di Keyboard
        float jalan = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(jalan * kecepatan, rb.linearVelocity.y);

        // LOGIKA UNTUK MENYALAKAN ANIMASI JALAN / IDLE
        if (jalan != 0) // Jika tombol arah lagi dipencet
        {
            anim.SetBool("isWalking", true); // Nyalain animasi lari

            // DISINI FIX NYA! Angka 6 diganti 1.5 biar ukurannya gak meledak gede lagi
            if (jalan > 0)
                transform.localScale = new Vector3(1.5f, 1.5f, 1); // Hadap Kanan tetap imut
            else if (jalan < 0)
                transform.localScale = new Vector3(-1.5f, 1.5f, 1); // Hadap Kiri tetap imut
        }
        else // Jika tombol dilepas / diam
        {
            anim.SetBool("isWalking", false); // Balik ke animasi diem
        }

        // Lompat pake tombol Spasi
        if (Input.GetButtonDown("Jump") && bisaLompat)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, kekuatanLompat);
            bisaLompat = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tanah"))
        {
            bisaLompat = true;
        }
    }
}