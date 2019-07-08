using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistroyinBoundary : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }//객체 삭제해주는 함수 

}
