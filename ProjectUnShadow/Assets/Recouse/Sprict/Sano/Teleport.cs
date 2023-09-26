using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] GameObject TeleportTargetObj;
    [SerializeField] float Tpduration;
    Vector3 targetPos;

    void Start()
    {
        // TeleportTargetObj �̈ʒu�� targetPos �ɐݒ�
        targetPos = TeleportTargetObj.transform.position;
        targetPos.y += 1; // �����𒲐�
    }

    public Vector3 GetTpPos()
    {
        return targetPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ���������I�u�W�F�N�g�̃^�O�� "player" �̏ꍇ
        if (collision.gameObject.CompareTag("Player"))
        {
            // �R���[�`�����J�n���đҋ@
            StartCoroutine(TeleportPlayer(collision.gameObject.GetComponent<Transform>()));
        }
    }

    private IEnumerator TeleportPlayer(Transform playerTransform)
    {
        // TPduration �b�ԑҋ@
        yield return new WaitForSeconds(Tpduration);

        // �v���C���[�̈ʒu�� targetPos �ɐݒ�
        playerTransform.position = targetPos;
    }
}