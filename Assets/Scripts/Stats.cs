using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    private int _playerScore = 0;
    private int _playerLife = 3;

    public Text playerScoreText;
    public Text playerLifeText;

    public void ChangeScore(int score)
    {
        this._playerScore = this._playerScore + score;
        playerScoreText.text = this._playerScore.ToString();
    }

    public void ChangeLife(int x)
    {
        this._playerLife = this._playerLife - x;
        playerLifeText.text = _playerLife.ToString();
    }

    public bool isPlayerAlive()
    {
        return this._playerLife > 0;
    }
}