// Script called on start button in setup screen

using UnityEngine;
using System.Collections;

public class FinishedSetupButton : MonoBehaviour {

    // declare variables
    public Animator anim;
    public GameObject squareTemplate;
    private GameObject targets, square;

    public void StartStage2()
    {
        // checks to make sure player has placed all pieces
        if(GameObject.Find("ScriptManager").GetComponent<GameLogic>().shipsSet == 5)
        {
            // changes stage and trigger
            Debug.Log("Setup complete");
            anim.SetTrigger("GameStart");
            anim.SetInteger("Stage", 2);

            // vectors used to spawn squares
            Vector3 adjustX = new Vector3(3.4f, 0f, 0f);
            Vector3 adjustY = new Vector3(0f, -3.4f, 0f);
            Vector3 resetX = new Vector3(-30.6f, 0f, 0f);
            Vector3 resetY = new Vector3(0f, 34f, 0f);
            Vector3 switchSides = new Vector3(35.6f, 0f, 0f);
            Vector3 resetAnchors = new Vector3(-32.85f, 15f, 0f);

            // reference for first square
            targets = GameObject.Find("Anchors");

            // create transparent squres
            for (int h = 0; h < 2; h++)
            {
                // for player side
                if (h == 0)
                {
                    // for each column
                    for (int i = 0; i < 10; i++)
                    {
                        // for each row
                        for (int j = 1; j < 11; j++)
                        {
                            if (j == 1)
                            {
                                // creates square at target position and labels it the appropriate name
                                square = Instantiate(squareTemplate, targets.transform.position, targets.transform.rotation) as GameObject;
                                square.name = GetLetter(j) + (i + 1).ToString();
                                square.GetComponent<SquareSprite>().location = GetLetter(j) + (i + 1).ToString();
                            }
                            else
                            {
                                // creates square at adjusted target position and labels it the appropriate name
                                targets.transform.position += adjustX;
                                square = Instantiate(squareTemplate, targets.transform.position, targets.transform.rotation) as GameObject;
                                square.name = GetLetter(j) + (i + 1).ToString();
                                square.GetComponent<SquareSprite>().location = GetLetter(j) + (i + 1).ToString();
                            }
                        }
                        // resets x and adjusts y for reference
                        targets.transform.position += adjustY;
                        targets.transform.position += resetX;
                    }
                    // resets y and switches sides of grid for reference
                    targets.transform.position += resetY;
                    targets.transform.position += switchSides;
                }
                // for enemy side
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 1; j < 11; j++)
                        {
                            if (j == 1)
                            {
                                square = Instantiate(squareTemplate, targets.transform.position, targets.transform.rotation) as GameObject;
                                square.name = "e" + GetLetter(j) + (i + 1).ToString();
                                square.GetComponent<SquareSprite>().location = GetLetter(j) + (i + 1).ToString();
                            }
                            else
                            {
                                targets.transform.position += adjustX;
                                square = Instantiate(squareTemplate, targets.transform.position, targets.transform.rotation) as GameObject;
                                square.name = "e" + GetLetter(j) + (i + 1).ToString();
                                square.GetComponent<SquareSprite>().location = GetLetter(j) + (i + 1).ToString();
                            }
                        }
                        targets.transform.position += adjustY;
                        targets.transform.position += resetX;
                    }
                }
            }

            targets.transform.position = resetAnchors;
        }               
    }
    // converts integer column to appropriate name
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
