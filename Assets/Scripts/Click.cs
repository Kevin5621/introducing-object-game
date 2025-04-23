using UnityEngine;

public class ClickSoundPlayer : MonoBehaviour
{
    [Tooltip("Suara yang akan diputar saat objek diklik")]
    public AudioClip soundToPlay;
    
    [Tooltip("Volume suara (0.0 sampai 1.0)")]
    [Range(0, 1)]
    public float volume = 1.0f;
    
    private AudioSource audioSource;

    void Start()
    {
        // Mendapatkan atau menambahkan komponen AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }
    
    void Update()
    {
        // Cek jika mouse diklik
        if (Input.GetMouseButtonDown(0))
        {
            // Mengubah posisi mouse ke world position
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            // Cek apakah mouse berada di dalam collider
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);
            
            // Jika collider yang diklik adalah collider objek ini
            if (hitCollider != null && hitCollider.gameObject == gameObject)
            {
                PlaySound();
            }
        }
    }
    
    public void PlaySound()
    {
        if (soundToPlay != null)
        {
            audioSource.PlayOneShot(soundToPlay, volume);
        }
        else
        {
            Debug.LogWarning("Audio clip belum diassign pada " + gameObject.name);
        }
    }
}