using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject Gameover;
    AudioManager AudioM;
    private void Start()
    {
        AudioM = FindObjectOfType<AudioManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Gameover.gameObject.SetActive(true);
            AudioM.Play("gameOver");
            PlayerManager.IsGameOver = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gem"))
        {
            PlayerManager.gems++;
            PlayerManager.score++;
            AudioM.Play("coin");
            Destroy(other.gameObject);
        }
    }
}
