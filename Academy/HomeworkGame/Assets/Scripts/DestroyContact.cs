using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyContact : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            Destroy(collider.gameObject);
        }
    }
}
