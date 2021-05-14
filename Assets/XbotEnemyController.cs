using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XbotEnemyController : MonoBehaviour
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
    public XbotEnemyController otherEnemy;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");

        //gunPrefab = this.GetComponentInChildren<Transform> 
        //gun = gunPrefab.GetComponent<Shoot>();


        //enemyRb = GetComponent<Rigidbody>();
        //gunPrefabPos = GameObject.FindGameObjectWithTag("Arm");

        //gunPrefabPos = this.GetComponentInChildren<Transform>();
        //FindDeepChild(this.transform, "mixamorig:RightHand");
        //if (gunPrefabPos != null)
        //{
        //    Instantiate(gunPrefab, gunPrefabPos.transform.position, gunPrefabPos.transform.rotation);
        //    Debug.Log("gunPrefab Instantiated!");

        //}
        //else Debug.Log("COulnd't instantiate gun!");
    }



    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
        if (player == null)
            return;

        EnemySensePlayer();
        //if (GameManager.gameEnd)
        //{
        //    anim.SetBool("isShooting", false);
        //}

    }


    //I want enemy to scan for player every frame
    void EnemySensePlayer()
    {
        EnemyRotateToPlayer();
        dist = Vector3.Distance(player.transform.position, this.transform.position);
        if (dist < 10f)
        {
            if (otherEnemy != null) {
                
                otherEnemy.gameObject.SetActive(false);
            }
        }
        if (dist < 10f)
        {
            //EnemyReachPlayer();
            EnemyShootPlayer();
        }
        else
        {
            //anim.SetBool("isWalking", false);
            anim.SetBool("isShooting", false);

        }
    }

    void EnemyRotateToPlayer()
    {
        Vector3 dir = player.transform.position - this.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        this.transform.rotation = lookRotation;

    }

    void EnemyShootPlayer()
    {
        anim.SetBool("isShooting", true);
        //gun.FireBullet(); //This method is not syncing up with the character's animation. Will call this from the animation itself. 
        //Instantiate(bulletPrefab, transform.position, transform.rotation);

    }

    public void AnimationShooting()
    {
        //firePoint = this.transform.Find("Firepoint");
            //GetComponentInChildren<Transform>().Find("Firepoint"); //I cannot use gameobject find because there are two firepoint present. 
        //I have to link it to individual enemy
        if (firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
            ParticleSystem flash = Instantiate(muzzleFlash, firePoint.transform.position, firePoint.transform.rotation);
            flash.Play();
            AudioSource shootSound = this.GetComponent<AudioSource>();
            
            shootSound.Play();
            Destroy(flash.gameObject, 0.1f);
        }
        else print("Firepoint not detected");
    }

    //If player is sensed, enemy should walk towards the player. 
    void EnemyReachPlayer()
    {
        //anim.SetBool("isWalking", true);

        //Vector3 dir = player.transform.position - this.transform.position;
        ////enemyRb.velocity = dir.normalized * enemySpeed * Time.deltaTime;
        //this.transform.Translate(dir.normalized * enemySpeed * Time.deltaTime);
        //if (dist < 1f)
        //{
        //    EnemyAttack();
        //}
        //else
        //{
        //    anim.SetBool("isAttack", false);
        //}
    }

    //If player is close to the enemy, enemy should attack. 
    void EnemyAttack()
    {
        //anim.SetBool("isAttack", true);
        //if (Input.GetKeyDown(KeyCode.Mouse0)) //This code is not working properly
        //{
        //    Debug.Log("Left Mouse button is pressed!");
        //    EnemyDeath();
        //}
    }

    void EnemyDeath()
    {
        //anim.SetBool("isDying", true);
        //enemySpeed = 0;
        //anim.SetBool("isDying", false);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
