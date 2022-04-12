using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> target;
    private float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameoverText;
    private int score;
    public bool isGameActive;
    public Button restartButton;
    public GameObject tiltleScreen;
    

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnTarget()
    {
        while (isGameActive) { 
        yield return new WaitForSeconds(spawnRate);
        int index = Random.Range(0, target.Count);
        Instantiate(target[index]);
  
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        Debug.Log("update success GM");
    }
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameoverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void ResartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {
        tiltleScreen.gameObject.SetActive(false);
        isGameActive = true;
        spawnRate /= difficulty;
        StartCoroutine(spawnTarget());
        score = 0;
        UpdateScore(0);
    }
}
