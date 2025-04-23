using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // Reference ke HewanController
    public HewanController hewanController;
    
    void Start()
    {
        // Jika hewanController belum diset, coba cari otomatis
        if (hewanController == null)
        {
            hewanController = FindFirstObjectByType<HewanController>();
            if (hewanController == null)
            {
                Debug.LogError("ButtonController: HewanController tidak ditemukan!");
            }
        }
    }
    
    void OnMouseDown()
    {
        // Panggil ShowNextAnimal ketika button diklik
        if (hewanController != null)
        {
            hewanController.ShowNextAnimal();
            Debug.Log("ButtonController: Tombol diklik, menampilkan hewan berikutnya");
        }
    }
}