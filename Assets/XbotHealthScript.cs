using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XbotHealthScript : MonoBehaviour
{
    public float health = 50f;
    private XbotEnemyController enemyController;
    private Animator enemyAnim;
    public GameObject gameCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyController = GetComponent<XbotEnemyController>();
        enemyAnim = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage(float damage)
    {
        //print("Apply Damage called");
        health -= damage;

        if(health <= 0f)
        {
            enemyAnim.SetTrigger(AnimationTags.DEAD_TRIGGER);
            enemyController.enabled = false;
            //Implement canvas thing. 
            gameCanvas.GetComponent<GameManager>().PlayerWins();
            //Destroy(this.gameObject, 5f);


        }
    }
}
