using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    //for our score text
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI infoText;

    //spawn a new target every second
    private float spawnRate = 1.5f;

    //variable to store score
    private int score;

    public bool isGameActive;
    public Button restartButton;
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        //enable Title, score, and Info screens
        scoreText.gameObject.SetActive(false);
        titleText.gameObject.SetActive(true);
        infoText.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore(0);

    }

   
    IEnumerator SpawnTarget()
    {
        while(isGameActive) //while game is active
        {
            yield return new WaitForSeconds(spawnRate);

            //get a random object from the list to use
            //random number between first object and last object
            int index = Random.Range(0, targets.Count);

            Instantiate(targets[index]);
        }
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        //update our score text on screen 
        score += scoreToAdd;
        scoreText.text = "Score: " + score;

        if (score >= 100)   //call Game Over function
            GameOver();
    }

    public void GameOver()
    {
        
        restartButton.gameObject.SetActive(true);
        //set the Game Over text to appear
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        
        //use Scenemanager from library to get the active scene by name
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        
        isGameActive = true;    //for determining game play
        score = 0;

        //call the Spawn Target method with a CoRoutine
        StartCoroutine(SpawnTarget());

        scoreText.gameObject.SetActive(true);
        titleText.gameObject.SetActive(false);
        infoText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);

    }

}
