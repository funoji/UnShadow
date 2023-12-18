using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBGetplayer : MonoBehaviour
{
    [SerializeField] MovebleBlock m_Move;
    [SerializeField] MovebleBlock.PushTo pushTo;
    private bool hasBeenCalled = false;
    testmove testmove;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !hasBeenCalled)
        {
            // �g���K�[���Ƀv���C���[���������Ƃ��Ƀt���O�𗧂Ă�
            hasBeenCalled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        hasBeenCalled = false;
    }
    private void Update()
    {
        // �t���O�������Ă���Ƃ���W�L�[�������ꂽ��֐����Ă�
        if (hasBeenCalled && Input.GetKeyDown(KeyCode.W)&&testmove.isMoving==false)
        {
            m_Move.GetPlayerTouch(pushTo);
            hasBeenCalled = false; // �t���O�����Z�b�g����
        }
    }
    private void Start()
    {
        testmove = GameObject.Find("player_rig3").GetComponent<testmove>();
    }
}
