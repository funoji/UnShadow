using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoolScript : MonoBehaviour
{
    private GameObject player;
    public float ascendSpeed = 5f;  // �㏸���x

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�G��Ă܂�");
            AscendPlayer();
            // �S�[���ɐG�ꂽ��̏����i��: �V�[���̐؂�ւ��j
            StartCoroutine(LoadNextSceneAfterDelay(2f));
        }
    }

    // �v���C���[�̏㏸����
    void AscendPlayer()
    {
        // �v���C���[��Rigidbody�������Ă���Ɖ���
        Rigidbody playerRb = player.GetComponent<Rigidbody>();
        if (playerRb != null)
        {
            // ������ɏ㏸
            playerRb.velocity = new Vector3(0f, ascendSpeed, 0f);
        }
        else
        {
            // Rigidbody���Ȃ��ꍇ�ATransform.Translate���g�p���Ĉʒu��ύX����Ȃ�
            player.transform.Translate(Vector3.up * ascendSpeed * Time.deltaTime);
        }
    }

    // �V�[���̐؂�ւ����f�B���C�t���ōs���R���[�`��
    IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Matsutake_Gool");
    }
}
