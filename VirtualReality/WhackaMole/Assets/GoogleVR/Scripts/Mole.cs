using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    public float visibleHeight = 5.11f;
    public float hiddenHeight = 4.68f;
    public float speed ;

    private Vector3 targetPosition;

    void Awake()
    {
        targetPosition = new Vector3(transform.localPosition.x, hiddenHeight, transform.localPosition.z);

        transform.localPosition = targetPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition=Vector3.Lerp(transform.localPosition,targetPosition,Time.deltaTime*speed);
    }

    public void OnHit()
    {
        targetPosition = new Vector3(transform.localPosition.x, hiddenHeight, transform.localPosition.z);

    }
    public  void Rise()
    {
        targetPosition = new Vector3(transform.localPosition.x, visibleHeight, transform.localPosition.z);
    }
}
