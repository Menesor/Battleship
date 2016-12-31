// Script to keep track of main game logic and variables

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour {

    // declare and initialize variables
    public int enemyHit = 0,
        playerHit = 0,
        shipsSet = 0;
    public string turn;
    public List<string> playerShipsHit, enemyShipsHit, playerGuesses, enemyGuesses;
    public Animator anim;

    // called when game first starts
    void Start()
    {
        turn = "Player";
    }

    // called every frame by unity
    void Update()
    {
        // checks to see if it is the enemy's turn
        if (turn == "Enemy")
        {
            EnemyTurn();
        }
        // check if either player or ai wins
        CheckWin();
    }

    // function used to determine a winner
    public void CheckWin()
    {
        // if player hit all points on the enemy's ships
        if (enemyHit == 17)
        {
            // sets trigger to win, stage to winscreen, and disables the message saying the enemy won
            anim.SetTrigger("Win");
            anim.SetInteger("Stage", 3);
            GameObject.Find("HUDCanvas/WinScreen/EnemyWins").SetActive(false);
        }
        // if enemy hit all points on the player's ships
        else if (playerHit == 17)
        {
            // sets trigger to win, stage to winscreen, and disables the message saying the player won
            anim.SetTrigger("Win");
            anim.SetInteger("Stage", 3);
            GameObject.Find("HUDCanvas/WinScreen/PlayerWins").SetActive(false);
        }       
    }
    // function containing logic for ai's turn
    public void EnemyTurn()
    {
        bool isOk = false;
        int col, row;
        string guess = "";
        System.Random rand = new System.Random();

        SquareSprite s;

        while(isOk == false)
        {
            col = rand.Next(1, 11);
            row = rand.Next(1, 11);

            guess = GetLetter(col) + row.ToString();

            s = GameObject.Find(guess).GetComponent<SquareSprite>();

            if (s.EnemyHitOrMiss(guess) == true)
            {
                isOk = true;
            }
        }
    }
    // converts column integer to appropriate letter
    public string GetLetter(int col)
    {
        string letter = "";
        switch (col)
        {
            case 1:
                letter = "A";
                break;
            case 2:
                letter = "B";
                break;
            case 3:
                letter = "C";
                break;
            case 4:
                letter = "D";
                break;
            case 5:
                letter = "E";
                break;
            case 6:
                letter = "F";
                break;
            case 7:
                letter = "G";
                break;
            case 8:
                letter = "H";
                break;
            case 9:
                letter = "I";
                break;
            case 10:
                letter = "J";
                break;
        }
        return letter;
    }
}
