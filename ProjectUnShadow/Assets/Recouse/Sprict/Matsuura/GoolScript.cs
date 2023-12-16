using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoolScript : MonoBehaviour
{
    private GameObject player;
    public float ascendSpeed = 5f;  // 上昇速度

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("触れてます");
            AscendPlayer();
            // ゴールに触れた後の処理（例: シーンの切り替え）
            StartCoroutine(LoadNextSceneAfterDelay(2f));
        }
    }

    // プレイヤーの上昇処理
    void AscendPlayer()
    {
        // プレイヤーがRigidbodyを持っていると仮定
        Rigidbody playerRb = player.GetComponent<Rigidbody>();
        if (playerRb != null)
        {
            // 上方向に上昇
            playerRb.velocity = new Vector3(0f, ascendSpeed, 0f);
        }
        else
        {
            // Rigidbodyがない場合、Transform.Translateを使用して位置を変更するなど
            player.transform.Translate(Vector3.up * ascendSpeed * Time.deltaTime);
        }
    }

    // シーンの切り替えをディレイ付きで行うコルーチン
    IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Matsutake_Gool");
    }
}
