using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;  // Except
public class ObjectTransparency : MonoBehaviour
{
    private void FixedUpdate()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward,Color.black);

        if (Physics.Raycast(transform.position,transform.forward,out hit))
        {
           
           // if(hit.collider.CompareTag("Walls"))hit.collider.gameObject.SetActive(false);
        }
    }
}