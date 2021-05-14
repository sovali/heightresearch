using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobEnemyController : MonoBehaviour
{

     public float radius;
    //private Shoot gun;
    //public Transform player;
    private float dist;
    private Animator anim; //Static should only be used to create a single instance of something. 
    //public float enemySpeed;
    private GameObject player;
    private GameObject gunPrefab;
    public GameObject bulletPrefab;
    public Transform firePoint;
    private float bulletSpeed = 5f;
    public ParticleSystem muzzleFlash;
    
    public float lastBulletTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;
        
        EnemyRotateToPlayer();

        if ((Time.time - lastBulletTime) >= 1.5f) {
            lastBulletTime = Time.time; 
            EnemySensePlayer();
        }
            
    }

      void EnemySensePlayer()
    {
        dist = Vector3.Distance(player.transform.position, this.transform.position);
        if (dist < 10f)
        {
          
        }
        if (dist < 10f)
        {
            EnemyShootPlayer();
        } 
        else
        {
            //anim.SetBool("isWalking", false);
            //anim.SetBool("isShooting", false);

        }
    }

     void EnemyShootPlayer()
    {
        Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
        AudioSource shootSound = this.GetComponent<AudioSource>();
            
        bulletPrefab.transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
      
    }

    void EnemyRotateToPlayer()
    {
        Vector3 dir = player.transform.position - this.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        this.transform.rotation = lookRotation;

        Vector3 myEulerAngles = this.transform.rotation.eulerAngles;
        myEulerAngles.x = 0;
        this.transform.rotation = Quaternion.Euler(myEulerAngles);
    }

   
}
