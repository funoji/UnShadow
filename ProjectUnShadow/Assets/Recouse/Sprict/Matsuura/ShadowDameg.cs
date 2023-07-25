using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowDameg : MonoBehaviour
{
    [SerializeField] GameObject damageEffect;
    private GameObject playerTransform; // プレイヤーオブジェクト
    private Quaternion effectRotation;
    // Start is called before the first frame update
    public int damageAmount = 10;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player");
        effectRotation = damageEffect.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterMovement playerHealth = other.GetComponent<CharacterMovement>();
        Vector3 playerPosition = playerTransform.transform.position;
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }
}
