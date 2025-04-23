using UnityEngine;
using TMPro;

public class HewanInfoConnector : MonoBehaviour
{
    // Reference ke HewanController
    public HewanController hewanController;
    
    // Reference ke TextMeshPro untuk nama dan deskripsi
    public TMP_Text namaText;
    public TMP_Text deskripsiText;
    
    // Informasi hewan yang tersedia
    [System.Serializable]
    public class InfoHewan
    {
        public string nama;
        [TextArea(2, 5)]
        public string deskripsi;
    }
    
    // Daftar informasi untuk setiap hewan
    public InfoHewan[] daftarHewan;
    
    void Start()
    {
        InitializeHewanInfo();
        
        // Cari HewanController jika belum ditetapkan
        if (hewanController == null)
        {
            hewanController = FindObjectOfType<HewanController>();
        }
        
        if (hewanController != null)
        {
            // Subscribe ke event onHewanChanged
            hewanController.onHewanChanged += UpdateInfoHewan;
            
            // Update informasi hewan saat ini
            UpdateInfoHewan(hewanController.GetCurrentIndex());
        }
        else
        {
            Debug.LogError("HewanInfoConnector: HewanController not found!");
        }
    }
    
    void OnDestroy()
    {
        // Unsubscribe dari event saat objek dihancurkan
        if (hewanController != null)
        {
            hewanController.onHewanChanged -= UpdateInfoHewan;
        }
    }
    
    void InitializeHewanInfo()
    {
        // Setup default hewan information jika belum ada
        if (daftarHewan == null || daftarHewan.Length == 0)
        {
            daftarHewan = new InfoHewan[7];
            
            // Gajah
            daftarHewan[0] = new InfoHewan();
            daftarHewan[0].nama = "Gajah";
            daftarHewan[0].deskripsi = "Gajah adalah mamalia terbesar di darat. Mereka memiliki ingatan yang sangat baik dan hidup dalam kelompok sosial yang kuat.";
            
            // Serigala
            daftarHewan[1] = new InfoHewan();
            daftarHewan[1].nama = "Serigala";
            daftarHewan[1].deskripsi = "Serigala hidup dalam kelompok yang disebut kawanan. Mereka sangat loyal dan berkomunikasi dengan berbagai jenis lolongan.";
            
            // Beruang
            daftarHewan[2] = new InfoHewan();
            daftarHewan[2].nama = "Beruang";
            daftarHewan[2].deskripsi = "Beruang dapat mencium makanan dari jarak 20 mil. Mereka tidur panjang (hibernasi) selama musim dingin untuk menghemat energi.";
            
            // Burung Beo
            daftarHewan[3] = new InfoHewan();
            daftarHewan[3].nama = "Beo";
            daftarHewan[3].deskripsi = "Burung Beo terkenal dengan kemampuannya meniru suara. Mereka dapat mengingat hingga 100 kata dan suara berbeda.";
            
            // Monyet
            daftarHewan[4] = new InfoHewan();
            daftarHewan[4].nama = "Monyet";
            daftarHewan[4].deskripsi = "Monyet adalah primata cerdas yang menggunakan alat sederhana. Mereka hidup dalam kelompok sosial dengan hierarki yang kompleks.";
            
            // Singa
            daftarHewan[5] = new InfoHewan();
            daftarHewan[5].nama = "Singa";
            daftarHewan[5].deskripsi = "Singa adalah kucing besar yang hidup dalam kelompok. Singa betina adalah pemburu utama, sementara jantan melindungi wilayah.";
            
            // Flamingo
            daftarHewan[6] = new InfoHewan();
            daftarHewan[6].nama = "Flamingo";
            daftarHewan[6].deskripsi = "Flamingo mendapatkan warna pink dari makanannya yang kaya karotenoid. Mereka sering berdiri dengan satu kaki untuk menghemat energi.";
        }
    }
    
    // Dipanggil ketika hewan berubah
    public void UpdateInfoHewan(int index)
    {
        if (index >= 0 && index < daftarHewan.Length)
        {
            if (namaText != null)
                namaText.text = daftarHewan[index].nama;
                
            if (deskripsiText != null)
                deskripsiText.text = daftarHewan[index].deskripsi;
                
            Debug.Log("HewanInfoConnector: Updated to " + daftarHewan[index].nama);
        }
        else
        {
            Debug.LogWarning("HewanInfoConnector: Invalid index " + index);
        }
    }
}
