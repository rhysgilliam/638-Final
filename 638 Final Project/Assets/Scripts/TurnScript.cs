using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnScript : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer { get; private set; }
    private GameObject _gameBoard;
    public Sprite[] images;
    private bool _unplayed = true;

    private void Start()
    {
        SpriteRenderer.sprite = null;
    }

    private void OnMouseDown()
    {
        if (_unplayed && !_gameBoard.GetComponent<GameScript>().End)
        {
            var index = _gameBoard.GetComponent<GameScript>().PlayerTurn(gameObject);
            SpriteRenderer.sprite = images[index];
            _gameBoard.GetComponent<GameScript>().RandomTurn();
            
            _unplayed = false;
        }
    }


    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        _gameBoard = GameObject.Find("GameBoard");
    }
}
