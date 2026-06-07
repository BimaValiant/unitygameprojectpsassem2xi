using UnityEngine;
using TMPro; // Wajib untuk ngatur teks UI versi Unity baru
using UnityEngine.EventSystems; // Ditambahkan untuk bersihin bentrok UI

public class ManajerGame : MonoBehaviour
{
    public int jumlahKoin = 0;

    // Tempat naruh teks UI di Inspector nanti
    public TextMeshProUGUI teksKoin;
    public TextMeshProUGUI teksNyawa;

    // Komponen NyawaPlayer yang udah kita bikin kemarin
    private NyawaPlayer scriptNyawa;

    void Start()
    {
        // TRICK AMPUH: Bersihin EventSystem duplikat yang kebawa dari Home biar UI gak nge-freeze
        EventSystem[] semuaEvent = FindObjectsOfType<EventSystem>();
        if (semuaEvent.Length > 1)
        {
            for (int i = 1; i < semuaEvent.Length; i++)
            {
                Destroy(semuaEvent[i].gameObject);
            }
        }

        // PENGAMAN: Cari objek Player dulu, pastikan objeknya emang ada di scene ini
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            scriptNyawa = playerObj.GetComponent<NyawaPlayer>();
        }

        // Tetap jalankan update UI awal biar teks koin muncul
        UpdateUI();
    }

    void Update()
    {
        // Terus-terusan update tampilan nyawa secara realtime (Hanya jika scriptNyawa ketemu)
        if (scriptNyawa != null && teksNyawa != null)
        {
            teksNyawa.text = "Nyawa: " + scriptNyawa.nyawa;
        }
    }

    // Fungsi untuk nambahin koin pas diambil
    public void TambahKoin(int nilai)
    {
        jumlahKoin += nilai;
        UpdateUI();
    }

    // Fungsi untuk memperbarui teks koin di layar
    void UpdateUI()
    {
        if (teksKoin != null)
        {
            teksKoin.text = "Koin: " + jumlahKoin;
        }
    }
}