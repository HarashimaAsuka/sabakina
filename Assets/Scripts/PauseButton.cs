using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    string sceneName;

    public GameObject pauseCanvas;

    [SerializeField] private AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    public void OnClickRetryButton(){
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1.0f;
    }
    
    public void OnClickStopButton(){
        Time.timeScale = 0.0f;
        AudioSource.Pause();
        pauseCanvas.gameObject.SetActive(true);
    }

    public void OnClickRestartButton(){
        pauseCanvas.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        AudioSource.UnPause();
    }
}
