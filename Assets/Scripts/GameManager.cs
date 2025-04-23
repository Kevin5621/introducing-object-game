using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        // Ensure camera can see the full background
        AdjustCamera();
    }
    
    void AdjustCamera()
    {
        // Find background
        GameObject background = GameObject.Find("Background");
        if (background == null)
            return;
            
        SpriteRenderer backgroundSprite = background.GetComponent<SpriteRenderer>();
        if (backgroundSprite == null)
            return;
            
        // Adjust camera to fit background
        Camera cam = Camera.main;
        if (cam == null)
            return;
            
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = backgroundSprite.bounds.size.x / backgroundSprite.bounds.size.y;
        
        if (screenRatio >= targetRatio)
        {
            // Pillar box
            cam.orthographicSize = backgroundSprite.bounds.size.y / 2;
        }
        else
        {
            // Letter box
            float differenceInSize = targetRatio / screenRatio;
            cam.orthographicSize = backgroundSprite.bounds.size.y / 2 * differenceInSize;
        }
    }
}