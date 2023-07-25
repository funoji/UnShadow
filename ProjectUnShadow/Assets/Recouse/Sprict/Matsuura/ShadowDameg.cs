using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowDameg : MonoBehaviour
{
    [SerializeField] GameObject damageEffect;
    private GameObject damageEffectInst;
    private GameObject playerTransform; // プレイヤーオブジェクト
    private Quaternion effectRotation;
    // Start is called before the first frame update
    public int damageAmount = 10;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player");
        effectRotation = damageEffect.transform.rotation;
    }
    private void Update()
    {
        if (damageEffectInst != null)
            damageEffectInst.transform.position = playerTransform.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        CharacterMovement playerHealth = other.GetComponent<CharacterMovement>();
        Vector3 playerPosition = playerTransform.transform.position;
        damageEffectInst = Instantiate(damageEffect, playerPosition, effectRotation);
        Destroy(damageEffectInst, 1.0f);
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }
}
