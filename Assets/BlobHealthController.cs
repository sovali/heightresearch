using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobHealthController : MonoBehaviour
{
    public enum BlobType {
        SHORT, MEDIUM, TALL
    }

    public float health = 50f;
    private BlobEnemyController enemyController;
    private Animator enemyAnim;
    public BlobType type;

    // Start is called before the first frame update
    void Start()
    {
        enemyController = GetComponent<BlobEnemyController>();
        //enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public BlobType getBlobType() {
        print("This is the type: "+ type);
        return type;
    }

     public void ApplyDamage(float damage)
    {
        //print("Apply Damage called");
        health -= damage;

        if(health <= 0f)
        {

            GameObject gameCanvas = GameObject.FindWithTag("Canvas");
            gameCanvas.GetComponent<GameManager>().EnemyDied();
            Destroy(this.gameObject.transform.parent.gameObject,1f);
        }
    }
}
