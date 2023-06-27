using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowDameg : MonoBehaviour
{
    // Start is called before the first frame update
    public int damageAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        CharacterMovement playerHealth = other.GetComponent<CharacterMovement>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }
}
