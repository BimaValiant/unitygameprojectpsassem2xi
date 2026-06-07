using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Kotak buat nyimpen folder UI menu ijo lu (levels)
    public GameObject panelSetting;

    // Fungsi buat tombol PLAY segitiga putih
    public void KlikPlay()
    {
        // 1. Bikin objek baru khusus di latar belakang bernama "ManajerMusik"
        GameObject objekMusikBaru = new GameObject("ManajerMusik");

        // 2. Pindahkan komponen AudioSource dari GameManager Home ke objek baru ini
        AudioSource audioHome = GameObject.Find("GameManager").GetComponent<AudioSource>();
        if (audioHome != null)
        {
            AudioSource audioBaru = objekMusikBaru.AddComponent<AudioSource>();
            audioBaru.clip = audioHome.clip;
            audioBaru.volume = audioHome.volume;
            audioBaru.loop = audioHome.loop;
            audioBaru.playOnAwake = audioHome.playOnAwake;
            audioBaru.Play(); // Jalankan musiknya
        }

        // 3. Kunci objek musik baru ini agar TIDAK HANCUR saat pindah level
        DontDestroyOnLoad(objekMusikBaru);

        // 4. Pindah ke Level 1 dengan selamat
        SceneManager.LoadScene("Level1");
    }

    // Fungsi buat tombol SETTING gerigi
    public void BukaSetting()
    {
        panelSetting.SetActive(true);
    }

    // Fungsi buat tombol CANCEL silang (cancelbtn)
    public void TutupSetting()
    {
        panelSetting.SetActive(false);
    }
}