using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Turret : MonoBehaviour {
    private Transform target;
    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountDown = 0f;
    private int hit = 0;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    
    public GameObject bulletPrefab;
    public Transform firePoint;
    
    
    
    void Start () {
        InvokeRepeating("UpdateTarget",0f,0.5f);
        Debug.Log("start fn");

    }

    void UpdateTarget (){
        GameObject Enemy = GameObject.FindGameObjectWithTag(enemyTag);
        GameObject nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        float distanceToEnemy = Vector3.Distance(transform.position, Enemy.transform.position); 
        
        if(distanceToEnemy < shortestDistance)
        {   Debug.Log("UpdateTarget");
            shortestDistance = distanceToEnemy;
            nearestEnemy = Enemy;

        }
        if(shortestDistance<=range)
        {
            target = nearestEnemy.transform;
        }
        else target = null;
        if (hit == 15)
         {
             Debug.Log("15hits done");
             Destroy(nearestEnemy);
             SceneManager.LoadScene(3);
         }
        
    }

    void Update () {
        if(target==null)
        return;            

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

       if(fireCountDown <= 0f)
        {Debug.Log("working");
        Debug.Log(hit);
        hit++;
            Shoot();
            fireCountDown = 1f/fireRate;
        }
        fireCountDown -= Time.deltaTime;       

    }

    void Shoot()
    {
       GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
       Bullet bullet = bulletGO.GetComponent<Bullet>();
       //if(bullet != null)
          Debug.Log("bullet found");
           bullet.Seek(target);       
    }

    void OnDrawGizmosSelected()
    {   Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }
}