using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameStart;
    public RectTransform panel;
    public Button restart;
    public Button quit;
    public Button start;
    public Text introText;
    public Text gameOverText;
    public Text youWinText;
    public GameObject player;
    public GameObject[] Enemies;
    public int numOfEnemies;
    public string nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        gameStart = false;
        panel.gameObject.SetActive(true);
        introText.gameObject.SetActive(true);
        start.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        Enemies = GameObject.FindGameObjectsWithTag("Blob");
        numOfEnemies = Enemies.Length;
        print("Num of enemies = " + numOfEnemies);
        Cursor.lockState = CursorLockMode.None;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void EnemyDied() 
    {
        numOfEnemies--;

        if (numOfEnemies == 0) {
            if (nextLevel != "GameOver") {
                //Cursor.lockState = CursorLockMode.Locked;
                print("loading next level");
                SceneManager.LoadScene(nextLevel);
            } else {
                PlayerWins();   
            }
            
        }
    }

    public void PlayerWins()
    {
        print("Player wins called");
        panel.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        youWinText.gameObject.SetActive(true);
        
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerAttack>().enabled = false;
        player.GetComponent<WeaponManager>().GetCurrentSelectedWeapon().gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        print("Unlocked");
    }

    public void PlayerLoose()
    {
        panel.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        print("Unlocked");

    }

    public void StartGame()
    {
        print("Start method called");
        gameStart = true;
        panel.gameObject.SetActive(false);
        introText.gameObject.SetActive(false);
        start.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        print("locked");

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
