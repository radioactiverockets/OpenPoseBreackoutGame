
using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

	public int lives = 4;
	public int bricks = 20;
	public float resetDelay = 1f;
	public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
    public GameObject startButton;
	public GameObject deathParticles;
	public static GM instance = null;

    //[SerializeField] int currentScore = 0;
    //[SerializeField] int pointsPerBlockDestroyed = 83;
    //[SerializeField] TextMeshProUGUI scoreText;

    private GameObject clonePaddle;
    private GameObject cloneStartButton;

	// Use this for initialization
	void Start () 
	{
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);

        //scoreText.text = currentScore.ToString();
        SetUp ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void SetUp()
	{
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;
		Instantiate (bricksPrefab, transform.position, Quaternion.identity);
        cloneStartButton = Instantiate(startButton, transform.position, Quaternion.identity) as GameObject;
    }

    //public void AddToScore()
    //{
    //    currentScore += pointsPerBlockDestroyed;
    //    scoreText.text = currentScore.ToString();
    //}

    public void CheckGameOver()
	{
		if (bricks < 1) {
			youWon.SetActive (true);
			Time.timeScale = 0.25f;
			Invoke ("Reset", resetDelay);
		}
		if (lives < 1) {
			gameOver.SetActive (true);
			Time.timeScale = 0.25f;
			Invoke ("Reset", resetDelay);
		}
	}

	void Reset()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void LoseLife()
	{
		lives--;
		livesText.text = "Lives: " + lives;
		Instantiate (deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy (clonePaddle);
        Destroy (startButton);
		Invoke ("SetupPaddle", resetDelay);
		CheckGameOver ();
	}

	void SetupPaddle()
	{
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;
        cloneStartButton = Instantiate(startButton, transform.position, Quaternion.identity) as GameObject;
    }

	public void DestroyBrick()
	{
		bricks--;
		CheckGameOver ();
	}
}
