using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public LayerMask collisionMask;
    float speed = 10;
    float damage = 1;
    float lifetime = 3;
    float skinWidth = .1f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;

        Collider[] InitialCollisions = Physics.OverlapSphere(transform.position, .1f, collisionMask);
        if (InitialCollisions.Length >0)
        {
            OnHItObject(InitialCollisions[0]);
        }
    }

    void Update()
    {
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);
    }


    void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, moveDistance+skinWidth, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);
        }
    }

    void OnHItObject(Collider c)
    {
        IDamageable damageableObject = c.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            damageableObject.TakeDamage(damage);

        }
        GameObject.Destroy(gameObject);
    }
    void OnHitObject(RaycastHit hit)
    {
        IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();
        if(damageableObject != null)
        {
            damageableObject.TakeHit(damage, hit);

        }
        GameObject.Destroy(gameObject);
    }

}
