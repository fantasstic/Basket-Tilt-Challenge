using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen, _game;
    [SerializeField] private TMP_Text _scoreCounter;

    public void ChangeScore(int score)
    {
        _scoreCounter.text = score.ToString();
    }

    public void GameOver()
    {
        _game.SetActive(false);
        _gameOverScreen.SetActive(true);
    }
}
