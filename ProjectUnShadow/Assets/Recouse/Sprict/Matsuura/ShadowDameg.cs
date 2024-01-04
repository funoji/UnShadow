using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowDameg : MonoBehaviour
{
    [SerializeField] GameObject damageEffect;
    private GameObject damageEffectInst;
    private GameObject playerTransform; // プレイヤーオブジェクト
    private Quaternion effectRotation;
    AudioSource audioSource;
    // Start is called before the first frame update
    public int damageAmount = 10;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player");
        effectRotation = damageEffect.transform.rotation;
        audioSource =GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (damageEffectInst != null)
            damageEffectInst.transform.position = playerTransform.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            testmove playerHealth = other.GetComponent<testmove>();
            Vector3 playerPosition = playerTransform.transform.position;
            damageEffectInst = Instantiate(damageEffect, playerPosition, effectRotation);
            
            Destroy(damageEffectInst, 3.0f);
            if (playerHealth != null)
            {
               
                StartCoroutine(playerHealth.TakeDamage(damageAmount));
                audioSource.Play();
                Collider playerCollider = other.GetComponent<Collider>();
                if (playerCollider != null)
                {
                    playerCollider.enabled = false;
                }
            }
        }
    }
}
