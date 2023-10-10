using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Titl : MonoBehaviour
{
    // ƒV[ƒ“‚ğØ‚è‘Ö‚¦‚é‚½‚ß‚ÌŠÖ”
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
