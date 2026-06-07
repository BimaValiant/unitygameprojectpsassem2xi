using UnityEngine;

public class MusuhPatroli : MonoBehaviour
{
    public float kecepatan = 2f;
    public float jarakPatroli = 3f; // Seberapa jauh dia bakal jalan sebelum balik arah

    private Vector2 posisiAwal;
    private bool gerakKeKanan = true;

    void Start()
    {
        // Nyimpen posisi awal musuh pas game dimulai
        posisiAwal = transform.position;
    }

    void Update()
    {
        // Hitung batas kanan dan kiri berdasarkan posisi awal
        float batasKanan = posisiAwal.x + jarakPatroli;
        float batasKiri = posisiAwal.x - jarakPatroli;

        if (gerakKeKanan)
        {
            // Jalan ke kanan
            transform.Translate(Vector2.right * kecepatan * Time.deltaTime);
            if (transform.position.x >= batasKanan)
            {
                gerakKeKanan = false; // Balik arah kalau udah mentok batas kanan
            }
        }
        else
        {
            // Jalan ke kiri
            transform.Translate(Vector2.left * kecepatan * Time.deltaTime);
            if (transform.position.x <= batasKiri)
            {
                gerakKeKanan = true; // Balik arah kalau udah mentok batas kiri
            }
        }
    }
}