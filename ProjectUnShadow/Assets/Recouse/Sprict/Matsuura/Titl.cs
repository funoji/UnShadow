using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Titl : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component at the start
        audioSource = GetComponent<AudioSource>();
    }

    // シーンを切り替えるための関数
    public void ChangeScene(string sceneName)
    {
        // Play the audio
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
        Time.timeScale = 1.0f;
        // Start a coroutine to add a delay before changing scenes
        StartCoroutine(ChangeSceneWithDelay(sceneName));
    }

    // Coroutine to add a delay before changing scenes
    IEnumerator ChangeSceneWithDelay(string sceneName)
    {
        // Wait for 2 seconds (you can adjust this duration)
        yield return new WaitForSeconds(0.5f);

        // Load the specified scene after the delay
        SceneManager.LoadScene(sceneName);
        Debug.Log("押された");
    }
}
