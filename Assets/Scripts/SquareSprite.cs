// Script attached to each square

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SquareSprite : MonoBehaviour {

    // declare and initialize variables
    public Sprite transparent, red, grey, green, purple, yellow;
    public Animator anim;
    public int enemyHit, playerHit;
    public string location = "", turn = "";
    public List<string> carrierPosition, battleshipPosition, cruiserPosition, submarinePosition, destroyerPosition;
    public List<string> eCarrierPosition, eBattleshipPosition, eCruiserPosition, eSubmarinePosition, eDestroyerPosition;

    private SpriteRenderer sr;    

    // function called when game starts up. initializes lists, spriterenderer, and animator
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        anim = GameObject.Find("HUDCanvas").GetComponent<Animator>();        

        // get player positions
        carrierPosition = GameObject.Find("ScriptManager").GetComponent<GameStart>().carrierPosition;
        battleshipPosition = GameObject.Find("ScriptManager").GetComponent<GameStart>().battleshipPosition;
        cruiserPosition = GameObject.Find("ScriptManager").GetComponent<GameStart>().cruiserPosition;
        submarinePosition = GameObject.Find("ScriptManager").GetComponent<GameStart>().submarinePosition;
        destroyerPosition = GameObject.Find("ScriptManager").GetComponent<GameStart>().destroyerPosition;

        // get ai positions
        eCarrierPosition = GameObject.Find("ScriptManager").GetComponent<GameStart>().eCarrierPosition;
        eBattleshipPosition = GameObject.Find("ScriptManager").GetComponent<GameStart>().eBattleshipPosition;
        eCruiserPosition = GameObject.Find("ScriptManager").GetComponent<GameStart>().eCruiserPosition;
        eSubmarinePosition = GameObject.Find("ScriptManager").GetComponent<GameStart>().eSubmarinePosition;
        eDestroyerPosition = GameObject.Find("ScriptManager").GetComponent<GameStart>().eDestroyerPosition;
    }

    // called every frame by unity
    void Update()
    {
        turn = GameObject.Find("ScriptManager").GetComponent<GameLogic>().turn;
    }

    // called if player clicks on the square
    public void OnMouseDown()
    {
        // only run HitOrMiss if player's turn
        if(GameObject.Find("ScriptManager").GetComponent<GameLogic>().turn == "Player" && anim.GetInteger("Stage") == 2)
        {
            PlayerHitOrMiss(location);
        }
    }

    // called in OnMouseDown(). checks if square contains enenmy location and sets square appropriate color
    public void PlayerHitOrMiss(string location)
    {
        // check and see if the current location is in any list
        if (GameObject.Find("ScriptManager").GetComponent<GameLogic>().playerGuesses.Contains(location) == false)
        {
            if (eCarrierPosition.Contains(location) || eBattleshipPosition.Contains(location) || eCruiserPosition.Contains(location) || eSubmarinePosition.Contains(location) || eDestroyerPosition.Contains(location))
            {
                // sets sprite to red, increases hit counter, and adds location to shipsHit list and player guess lists
                sr.sprite = red;
                GameObject.Find("ScriptManager").GetComponent<GameLogic>().enemyHit++;
                GameObject.Find("ScriptManager").GetComponent<GameLogic>().enemyShipsHit.Add(location);
                GameObject.Find("ScriptManager").GetComponent<GameLogic>().playerGuesses.Add(location);
            }
            else
            {
                // sets sprite to grey, and adds to playerguess list
                sr.sprite = grey;
                GameObject.Find("ScriptManager").GetComponent<GameLogic>().playerGuesses.Add(location);
            }
            // sets turn to enemy
            GameObject.Find("ScriptManager").GetComponent<GameLogic>().turn = "Enemy";
        }    
    }
    // called in EnemyTurn() in GameLogic.cs
    public bool EnemyHitOrMiss(string location)
    {
        if (GameObject.Find("ScriptManager").GetComponent<GameLogic>().enemyGuesses.Contains(location) == false)
        {
            // check and see if the current location is in any list
            if (carrierPosition.Contains(location) || battleshipPosition.Contains(location) || cruiserPosition.Contains(location) || submarinePosition.Contains(location) || destroyerPosition.Contains(location))
            {
                // sets sprite to red, increases hit counter, and adds location to shipsHit list and enemy guess lists
                sr.sprite = red;
                GameObject.Find("ScriptManager").GetComponent<GameLogic>().playerHit++;
                GameObject.Find("ScriptManager").GetComponent<GameLogic>().playerShipsHit.Add(location);
                GameObject.Find("ScriptManager").GetComponent<GameLogic>().enemyGuesses.Add(location);
            }
            else
            {
                // sets sprite to grey, and adds to enemyguess list
                sr.sprite = grey;
                GameObject.Find("ScriptManager").GetComponent<GameLogic>().enemyGuesses.Add(location);
            }

            // sets turn to player
            GameObject.Find("ScriptManager").GetComponent<GameLogic>().turn = "Player";
            Debug.Log("Player Turn");
            return true;
        }
        else
        {
            return false;
        }      
    }
}
