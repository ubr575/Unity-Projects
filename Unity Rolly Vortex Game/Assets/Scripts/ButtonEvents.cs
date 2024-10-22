using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonEvents : MonoBehaviour
{
    AudioManager audio;
    public Button buttonsound;
    private void Start()
    {
        audio = FindObjectOfType<AudioManager>();
        buttonsound.onClick.AddListener(buttonOnClick);
    }
    public void buttonOnClick()
    {
        audio.Play("button");
    }
    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
}
