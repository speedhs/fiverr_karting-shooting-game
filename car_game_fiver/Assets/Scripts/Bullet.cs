using UnityEngine;
 public class Bullet : MonoBehaviour
 {   private Transform target;
     public float speed = 70f;
     public GameObject impactEffect;
     
     public void Seek(Transform _target)
     {
         target = _target;
     }

     void Update () {
                          
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if(dir.magnitude <= distanceThisFrame ){
            Debug.Log("update fn");
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

     }
     void HitTarget(){
         Debug.Log("we hit something");
         GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
         Destroy(effectIns, 2f);
         Destroy(gameObject);
         
     }
     
 }