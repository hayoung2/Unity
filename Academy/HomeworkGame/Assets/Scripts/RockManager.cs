using UnityEngine;
using System.Collections;

public class RockManager : MonoBehaviour
{

    public GameObject prefab;
    public Vector2 boundary;
    public float createTime = 2f;

    private void Start()
    {
        StartCoroutine(CreateRockObject());
    }

    IEnumerator CreateRockObject()
    {
        while (GameManager.Get.isStart)
        {
            Vector3 pos = new Vector3(Random.Range(boundary.x, boundary.y), 0f, transform.position.z);

            Instantiate(prefab, pos, Quaternion.identity, transform);
            yield return new WaitForSeconds(createTime);
        }
        yield break; 
    }
}
