using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class HealthScript : MonoBehaviour
{
    public GameObject gameCanvas;

    private EnemyAnimator enemy_Anim;
    private NavMeshAgent navAgent;
    private EnemyController enemy_Controller;

    public float health = 100f;
    public bool is_Player, is_Boar, is_Cannibal;

    private bool is_Dead;
    private EnemyAudio enemyAudio;

    private PlayerStats player_Stats;

    private void Awake()
    {
        if (is_Boar || is_Cannibal)
        {
            enemy_Anim = GetComponent<EnemyAnimator>();
            enemy_Controller = GetComponent<EnemyController>();
            navAgent = GetComponent<NavMeshAgent>();

            //get audio
        }

        if (is_Player)
        {
            player_Stats = GetComponent<PlayerStats>();
        }

        
    }

    public void ApplyDamage(float damage)
    {
        if (is_Dead)
            return;

        health -= damage;

        if (is_Player)
        {
            //show stats Health UI
            player_Stats.Display_HealthStats(health);
        }

        if (is_Boar || is_Cannibal)
        {
            if (enemy_Controller.Enemy_State == EnemyState.PATROL)
            {
                enemy_Controller.chase_Distance = 50f;
                enemyAudio = GetComponentInChildren<EnemyAudio>();
            }
        }

        if (health <= 0f)
        {
            PlayerDied();
            is_Dead = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlayerDied()
    {
        // if (is_Cannibal)
        // {
        //     GetComponent<Animator>().enabled = false;
        //     GetComponent<BoxCollider>().isTrigger = false;
        //     GetComponent<Rigidbody>().AddTorque(-transform.forward * 50f);
        //     enemy_Controller.enabled = false;
        //     enemy_Anim.enabled = false;

        //     //Start a coroutine for sounds
        //     StartCoroutine(DeadSound());


        //     //Spawn manager to spawn more enemy
        // }

        // if (is_Boar)
        // {
        //     navAgent.velocity = Vector3.zero;
        //     navAgent.isStopped = true;
        //     enemy_Controller.enabled = false;
        //     enemy_Anim.Dead();

        //     StartCoroutine(DeadSound());
        // }

        

        if (is_Player) //Player died
        {
            //GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.ENEMY_TAG);

            //for (int i = 0; i < enemies.Length; i++)
            //{
            //    enemies[i].GetComponent<XbotEnemyController>().enabled = false;
            //}

            GameObject enemy = GameObject.FindGameObjectWithTag(Tags.ENEMY_TAG);
            //enemy.GetComponent<XbotEnemyController>().enabled = false;

            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            GetComponent<WeaponManager>().GetCurrentSelectedWeapon().gameObject.SetActive(false);

            gameCanvas.GetComponent<GameManager>().PlayerLoose();

        }

        if (tag == Tags.PLAYER_TAG)
        {
            //Invoke("RestartGame", 3f);
        }
        else
        {
            Invoke("TurnOffGameObject", 3f);
        }
    }

    void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene1");
    }

    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }

    IEnumerator DeadSound()
    {
        yield return new WaitForSeconds(0.3f);
        enemyAudio.Play_DeadSound();
    }
}
