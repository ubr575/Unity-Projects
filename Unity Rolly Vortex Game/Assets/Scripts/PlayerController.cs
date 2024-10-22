using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public float speed;
    
    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.LevelStarted) return;

        if (PlayerManager.IsGameOver) return;

        transform.Translate(0, 0, speed * Time.deltaTime);
        if (Touchscreen.current != null)
        {
            Vector2 value=Touchscreen.current.primaryTouch.delta.ReadValue();
            transform.Rotate(0, 0, value.x * 0.7f);
        }
    }
}
