using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage = 20f;
    //public HealthScript playerHealth;
    private GameObject player;
    public float bulletSpeed = 10f;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG);
        Destroy(this.gameObject, 5f);
        //print("Start Function executed");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position += transform.forward * bulletSpeed * Time.deltaTime;

            if (Vector3.Distance(player.transform.position, transform.position) < 2f)
            {
                player.GetComponent<HealthScript>().ApplyDamage(damage);
            }
        }
        else print("Player not found");
    }

}
