using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
	public int startingScore = 0;

	public string playerName;
	public string playerScoreTextObjectName;

	private Text playerScoreText;
	private int score;

	private void Start()
	{
		playerScoreText = GameObject.Find(playerScoreTextObjectName).GetComponent<Text>();
		score = startingScore;
    }

	private void Update()
	{
		if (playerScoreText)
		{
			playerScoreText.text = playerName + ": " + score;
        }
	}

	public void AddScore(int scoreToAdd)
	{
		score += scoreToAdd;
	}
}
