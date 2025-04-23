using UnityEngine;
using System.Collections.Generic;

public class HewanController : MonoBehaviour
{
    // Event yang akan dipanggil saat hewan berubah
    public delegate void HewanChangedDelegate(int index);
    public event HewanChangedDelegate onHewanChanged;
    
    // Array untuk menyimpan semua objek hewan
    public GameObject[] hewanObjects;
    
    // Indeks hewan yang aktif saat ini
    private int currentIndex = 0;
    
    void Start()
    {
        // Jika array hewanObjects kosong, coba temukan semua hewan otomatis
        if (hewanObjects == null || hewanObjects.Length == 0)
        {
            // Mengambil semua child dari objek ini (Hewan)
            List<GameObject> hewanList = new List<GameObject>();
            foreach (Transform child in transform)
            {
                hewanList.Add(child.gameObject);
                Debug.Log("HewanController: Found child: " + child.name);
            }
            hewanObjects = hewanList.ToArray();
            
            Debug.Log("HewanController: Found " + hewanObjects.Length + " animals automatically");
        }
        
        // Nonaktifkan semua hewan saat awal
        for (int i = 0; i < hewanObjects.Length; i++)
        {
            hewanObjects[i].SetActive(false);
        }
        
        // Aktifkan hewan pertama
        if (hewanObjects.Length > 0)
        {
            hewanObjects[0].SetActive(true);
            Debug.Log("HewanController: Showing first animal: " + hewanObjects[0].name);
            
            // Panggil event onHewanChanged
            if (onHewanChanged != null)
            {
                onHewanChanged(0);
            }
        }
    }
    
    // Fungsi untuk menampilkan hewan berikutnya
    public void ShowNextAnimal()
    {
        if (hewanObjects == null || hewanObjects.Length == 0)
        {
            Debug.LogWarning("HewanController: No animal objects assigned!");
            return;
        }
        
        // Nonaktifkan hewan saat ini
        hewanObjects[currentIndex].SetActive(false);
        
        // Pindah ke hewan berikutnya (dengan loop kembali ke awal jika sudah di akhir)
        currentIndex = (currentIndex + 1) % hewanObjects.Length;
        
        // Aktifkan hewan berikutnya
        hewanObjects[currentIndex].SetActive(true);
        Debug.Log("HewanController: Now showing animal: " + hewanObjects[currentIndex].name);
        
        // Panggil event onHewanChanged
        if (onHewanChanged != null)
        {
            onHewanChanged(currentIndex);
        }
    }
    
    // Getter untuk mendapatkan indeks hewan saat ini
    public int GetCurrentIndex()
    {
        return currentIndex;
    }
}