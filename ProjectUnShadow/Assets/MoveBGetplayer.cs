using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBGetplayer : MonoBehaviour
{
    [SerializeField] MovebleBlock m_Move;
    [SerializeField] MovebleBlock.PushTo pushTo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_Move.GetPlayerTouch(pushTo);
        }
    }
}
