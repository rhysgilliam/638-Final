using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    private MasterControl _masterControl;
    
    private int _spriteIndex = -1;
    private GameObject[][] _tiles;
    public GameObject[] Row1;
    public GameObject[] Row2;
    public GameObject[] Row3;

    public GameObject winText;
    public GameObject loseText;
    public GameObject tieText;

    public bool End { get; set; }
    private int _endTimer;
    private int[][] Board { get; set; }

    private void Start()
    {
        _masterControl = MasterControl.GetMasterControl();
        
        End = false;
        
        _tiles = new GameObject[3][];
        _tiles[0] = Row1;
        _tiles[1] = Row2;
        _tiles[2] = Row3;
        
        Board = new int[3][];
        for (var i = 0; i < 3; i++)
        {
            Board[i] = new int[3];
            for (var j = 0; j < 3; j++)
            {
                Board[i][j] = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        if (End)
        {
            if (_endTimer > 100)
            {
                _masterControl.SetSaturation(Mathf.Min(_masterControl.GetSaturation() + 30, 0));
                SceneManager.LoadScene("Alley 2");
            }
            else
                _endTimer++;
        }
    }
    
    
    // literally the worst code i have ever written please do not look at this
    public int PlayerTurn(GameObject tile)
    {
        if (End)
            return -1;
        
        var player = _spriteIndex % 2 + 1;
        if (player == 0)
            player = 2;

        // Loop through the _tiles array to find the coordinates of the clicked tile
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                if (_tiles[i][j] == tile)
                {
                    Debug.Log(i + ", " + j + " is now " + player);
                    Board[i][j] = player;
                    break;
                }
            }
        }
        _spriteIndex++;
        // check if the game is won
        // 1 is O, 2 is X
        var win = CheckWin();
        switch (win)
        {
            case 2:
                winText.SetActive(true);
                End = true;
                return _spriteIndex % 2;
            case 1:
                loseText.SetActive(true);
                End = true;
                return _spriteIndex % 2;
            case 0:
                tieText.SetActive(true);
                End = true;
                return _spriteIndex % 2;
            default:
                return _spriteIndex % 2;
        }
    }

    public void RandomTurn()
    {
        if (End)
            return;
        if (CheckWin() != -1)
            return;
        
        
        int i;
        int j;
        do
        {
            // Debug.Log("Choosing tile...");
            i = Random.Range(0, 2);
            j = Random.Range(0, 2);

            if (CheckWin() != -1)
            {
                return;
            }
            
        } while (Board[i][j] != 0);
        
        Debug.Log("Chose tile " + i + ", " + j);

        _tiles[i][j].GetComponent<TurnScript>().SpriteRenderer.sprite =
            _tiles[i][j].GetComponent<TurnScript>().images[1];
        PlayerTurn(_tiles[i][j]);
    }
    
    // i think this function literally just checks each possible win condition lmfao thanks chatgpt
    private int CheckWin()
    {
        // Check rows
        for (var i = 0; i < 3; i++)
        {
            if (Board[i][0] != 0 && Board[i][0] == Board[i][1] && Board[i][0] == Board[i][2])
            {
                return Board[i][0];
            }
        }

        // Check columns
        for (int j = 0; j < 3; j++)
        {
            if (Board[0][j] != 0 && Board[0][j] == Board[1][j] && Board[0][j] == Board[2][j])
            {
                return Board[0][j];
            }
        }

        // Check diagonals
        if (Board[0][0] != 0 && Board[0][0] == Board[1][1] && Board[0][0] == Board[2][2])
        {
            return Board[0][0];
        }
        if (Board[0][2] != 0 && Board[0][2] == Board[1][1] && Board[0][2] == Board[2][0])
        {
            return Board[0][2];
        }

        // Check for tie or game not finished
        var hasEmpty = false;
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                if (Board[i][j] == 0)
                {
                    hasEmpty = true;
                    break;
                }
            }
            if (hasEmpty)
            {
                break;
            }
        }
        if (!hasEmpty)
        {
            // If there are no empty slots, the game is tied
            return 0;
        }

        // If none of the above conditions are met, the game is not finished yet
        return -1;
    }
}
