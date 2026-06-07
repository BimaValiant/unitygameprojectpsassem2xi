using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PengaturanMusik : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] daftarLagu;
    public TextMeshProUGUI teksJudulLagu;
    public Slider sliderVolume;

    private int indeksLaguSekarang = 0;

    void Start()
    {
        // Ambil data volume terakhir dari memori (Default 1f / Full)
        float volumeTerakhir = PlayerPrefs.GetFloat("VolumeMusik", 1f);

        if (audioSource != null)
        {
            audioSource.volume = volumeTerakhir;
        }

        PlayLagu();
    }

    // FUNGSI UTAMA: Dipanggil pas tombol gear diklik di Home
    public void BukaPanelSettings()
    {
        float volumeTerakhir = PlayerPrefs.GetFloat("VolumeMusik", 1f);

        if (sliderVolume != null)
        {
            // Putus hubungan lama biar gak auto trigger
            sliderVolume.onValueChanged.RemoveAllListeners();

            // Paksa penunjuk slider di layar melompat sesuai volume asli
            sliderVolume.value = volumeTerakhir;

            // Pasang pendengarnya
            sliderVolume.onValueChanged.AddListener(SetVolume);
        }
    }

    public void SetVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = volume;
            PlayerPrefs.SetFloat("VolumeMusik", volume);
            PlayerPrefs.Save();
        }
    }

    public void GantiLaguNext()
    {
        if (daftarLagu == null || daftarLagu.Length == 0) return;

        indeksLaguSekarang++;
        if (indeksLaguSekarang >= daftarLagu.Length)
        {
            indeksLaguSekarang = 0;
        }
        PlayLagu();
    }

    void PlayLagu()
    {
        if (audioSource == null || daftarLagu == null || daftarLagu.Length == 0) return;

        audioSource.clip = daftarLagu[indeksLaguSekarang];
        audioSource.Play();

        if (teksJudulLagu != null)
        {
            teksJudulLagu.text = "Lagu: " + daftarLagu[indeksLaguSekarang].name;
        }
    }
}