using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _maxHeight = 5f;
    [SerializeField] private float _descentSpeed = 2f;
    [SerializeField] private int _scoreToAdd;
    [SerializeField] private BrilliantSpawner _spawner;

    private GameController _gameController;
    private int _score;
    private Rigidbody2D _rb;

    private void Start()
    {
        _gameController = FindObjectOfType<GameController>();
        _rb = GetComponent<Rigidbody2D>();
        _score = 0;
        _gameController.ChangeScore(_score);
    }

    private void Update()
    {
        if (transform.position.y > _maxHeight)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = _maxHeight;
            transform.position = newPosition;

            _rb.velocity = new Vector2(_rb.velocity.x, -_descentSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Lose")
        {
            _gameController.GameOver();
        }

        if (collision.transform.tag == "Score")
        {
            _spawner.DiamondPickedUp();
            _score += _scoreToAdd;
            _gameController.ChangeScore(_score);
            Destroy(collision.gameObject);
        }
    }
}
