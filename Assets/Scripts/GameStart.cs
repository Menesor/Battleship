// Script for the start button on setup screen

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStart : MonoBehaviour {

    // declare variables
    public Animator anim;

    public List<string> carrierPosition, battleshipPosition, cruiserPosition, submarinePosition, destroyerPosition;
    public List<string> eCarrierPosition, eBattleshipPosition, eCruiserPosition, eSubmarinePosition, eDestroyerPosition;

    // called every frame by unity
    void Update()
    {
        // checks if it is in the setup stage
        if (anim.GetInteger("Stage") == 1)
        {
            // controlls visibility of start button
            if (GameObject.Find("ScriptManager").GetComponent<GameLogic>().shipsSet == 5)
            {
                GameObject.Find("HUDCanvas/SetupScreen/FinishedSetupButton").SetActive(true);
            }
            else
            {
                GameObject.Find("HUDCanvas/SetupScreen/FinishedSetupButton").SetActive(false);
            }
        }
    }
    // sets positions for player and ai into Lists
    public void MainGameplay()
    {
        SetPlayerPosition();
        SetEnemyPosition();

        // This function is here for testing purposes
        // DisplayEnemyPosition(eCarrierPosition, eBattleshipPosition, eCruiserPosition, eSubmarinePosition, eDestroyerPosition);       
    }
    // set player positions
    public void SetPlayerPosition()
    {
        carrierPosition = GameObject.Find("5carrier(Clone)").GetComponent<DragDrop>().position;
        battleshipPosition = GameObject.Find("4battleship(Clone)").GetComponent<DragDrop>().position;
        cruiserPosition = GameObject.Find("3cruiser(Clone)").GetComponent<DragDrop>().position;
        submarinePosition = GameObject.Find("3submarine(Clone)").GetComponent<DragDrop>().position;
        destroyerPosition = GameObject.Find("2destroyer(Clone)").GetComponent<DragDrop>().position;
    }
    // set enemy positions randomly
    public void SetEnemyPosition()
    {
        int col, row, rot;
        string position = "",
            name = "";
        bool isOk = false;
        System.Random rand = new System.Random();

        for (int i = 0; i < 5; i++)
        {
            isOk = false;
            switch (i)
            {
                case 0:
                    while (!isOk)
                    {
                        col = rand.Next(1, 7);
                        row = rand.Next(1, 7);
                        rot = rand.Next(1, 3);

                        name = "carrier";

                        for (int j = 0; j < 5; j++)
                        {
                            // check if horizontal (col) or vertical (row) placing, except on first loop
                            if (j != 0)
                            {
                                if (rot == 1)
                                {
                                    col += 1;
                                }
                                else if (rot == 2)
                                {
                                    row += 1;
                                }
                            }

                            position = GetLetter(col) + row.ToString();
                            eCarrierPosition.Add(position);
                        }
                        if (CheckPlacement(eCarrierPosition, name) == false)
                        {
                            isOk = true;
                        }
                        else
                        {
                            eCarrierPosition.Clear();
                        }
                    }
                    break;
                case 1:
                    while (!isOk)
                    {
                        col = rand.Next(1, 8);
                        row = rand.Next(1, 8);
                        rot = rand.Next(1, 3);

                        name = "battleship";

                        for (int j = 0; j < 4; j++)
                        {
                            if (j != 0)
                            {
                                if (rot == 1)
                                {
                                    col += 1;
                                }
                                else if (rot == 2)
                                {
                                    row += 1;
                                }
                            }

                            position = GetLetter(col) + row.ToString();
                            eBattleshipPosition.Add(position);
                        }
                        if (CheckPlacement(eBattleshipPosition, name) == false)
                        {
                            isOk = true;
                        }
                        else
                        {
                            eBattleshipPosition.Clear();
                        }
                    }
                    break;
                case 2:
                    while (!isOk)
                    {
                        col = rand.Next(1, 9);
                        row = rand.Next(1, 9);
                        rot = rand.Next(1, 3);

                        name = "cruiser";

                        for (int j = 0; j < 3; j++)
                        {
                            if (j != 0)
                            {
                                if (rot == 1)
                                {
                                    col += 1;
                                }
                                else if (rot == 2)
                                {
                                    row += 1;
                                }
                            }

                            position = GetLetter(col) + row.ToString();
                            eCruiserPosition.Add(position);
                        }
                        if (CheckPlacement(eCruiserPosition, name) == false)
                        {
                            isOk = true;
                        }
                        else
                        {
                            eCruiserPosition.Clear();
                        }
                    }
                    break;
                case 3:
                    while (!isOk)
                    {
                        col = rand.Next(1, 9);
                        row = rand.Next(1, 9);
                        rot = rand.Next(1, 3);

                        name = "submarine";

                        for (int j = 0; j < 3; j++)
                        {
                            if (j != 0)
                            {
                                if (rot == 1)
                                {
                                    col += 1;
                                }
                                else if (rot == 2)
                                {
                                    row += 1;
                                }
                            }

                            position = GetLetter(col) + row.ToString();
                            eSubmarinePosition.Add(position);
                        }
                        if (CheckPlacement(eSubmarinePosition, name) == false)
                        {
                            isOk = true;
                        }
                        else
                        {
                            eSubmarinePosition.Clear();
                        }
                    }
                    break;
                case 4:
                    while (!isOk)
                    {
                        col = rand.Next(1, 10);
                        row = rand.Next(1, 10);
                        rot = rand.Next(1, 3);

                        name = "destroyer";

                        for (int j = 0; j < 2; j++)
                        {
                            if (j != 0)
                            {
                                if (rot == 1)
                                {
                                    col += 1;
                                }
                                else if (rot == 2)
                                {
                                    row += 1;
                                }
                            }

                            position = GetLetter(col) + row.ToString();
                            eDestroyerPosition.Add(position);
                        }
                        if (CheckPlacement(eDestroyerPosition, name) == false)
                        {
                            isOk = true;
                        }
                        else
                        {
                            eDestroyerPosition.Clear();
                        }
                    }
                    break;
            }
        }
    }
    // converts column number to appropriate letter
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

    // this function checks to see if any of the values stored in the list argument are conatained inside of any of the previously set lists
    public bool CheckPlacement(List<string> positionList, string name)
    {
        bool found = false;
        foreach (string position in positionList)
        {
            if(found == true)
            {
                break;
            }
            else
            {
                switch (name)
                {
                    case "carrier":
                        if (eBattleshipPosition.Contains(position) || eCruiserPosition.Contains(position) || eSubmarinePosition.Contains(position) || eDestroyerPosition.Contains(position))
                        {
                            found = true;
                        }
                        else
                        {
                            found = false;
                        }
                        break;
                    case "battleship":
                        if (eCarrierPosition.Contains(position) || eCruiserPosition.Contains(position) || eSubmarinePosition.Contains(position) || eDestroyerPosition.Contains(position))
                        {
                            found = true;
                        }
                        else
                        {
                            found = false;
                        }
                        break;
                    case "cruiser":
                        if (eCarrierPosition.Contains(position) || eBattleshipPosition.Contains(position) || eSubmarinePosition.Contains(position) || eDestroyerPosition.Contains(position))
                        {
                            found = true;
                        }
                        else
                        {
                            found = false;
                        }
                        break;
                    case "submarine":
                        if (eCarrierPosition.Contains(position) || eBattleshipPosition.Contains(position) || eCruiserPosition.Contains(position) || eDestroyerPosition.Contains(position))
                        {
                            found = true;
                        }
                        else
                        {
                            found = false;
                        }
                        break;
                    case "destroyer":
                        if (eCarrierPosition.Contains(position) || eBattleshipPosition.Contains(position) || eCruiserPosition.Contains(position) || eSubmarinePosition.Contains(position))
                        {
                            found = true;
                        }
                        else
                        {
                            found = false;
                        }
                        break;
                }
            }            
        }
        return found;
    }
    // function used for testing to show enemy placement
    public void DisplayEnemyPosition(List<string> carrier, List<string> battleship, List<string> cruiser, List<string> submarine, List<string> destroyer)
    {
        foreach(string position in carrier)
        {
            SpriteRenderer sr = GameObject.Find("e" + position).GetComponent<SpriteRenderer>();
            Sprite red = GameObject.Find("e" + position).GetComponent<SquareSprite>().red;

            sr.sprite = red;
        }
        foreach (string position in battleship)
        {
            SpriteRenderer sr = GameObject.Find("e" + position).GetComponent<SpriteRenderer>();
            Sprite grey = GameObject.Find("e" + position).GetComponent<SquareSprite>().grey;

            sr.sprite = grey;
        }
        foreach (string position in cruiser)
        {
            SpriteRenderer sr = GameObject.Find("e" + position).GetComponent<SpriteRenderer>();
            Sprite green = GameObject.Find("e" + position).GetComponent<SquareSprite>().green;

            sr.sprite = green;
        }
        foreach (string position in submarine)
        {
            SpriteRenderer sr = GameObject.Find("e" + position).GetComponent<SpriteRenderer>();
            Sprite purple = GameObject.Find("e" + position).GetComponent<SquareSprite>().purple;

            sr.sprite = purple;
        }
        foreach (string position in destroyer)
        {
            SpriteRenderer sr = GameObject.Find("e" + position).GetComponent<SpriteRenderer>();
            Sprite yellow = GameObject.Find("e" + position).GetComponent<SquareSprite>().yellow;

            sr.sprite = yellow;
        }
    }
}
