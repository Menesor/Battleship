// Script attached to each ship

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DragDrop : MonoBehaviour {
    
    // declare and initialize 
    public GameObject canvas;
    private Animator anim;
    private bool isSet = false;
    public int triggers = 0;
    private int requiredTriggers;
    private Collider2D col;
    public List<string> position = new List<string>();

    // Use this for initialization
    void Start () {
        canvas = GameObject.Find("HUDCanvas");
        anim = canvas.GetComponent<Animator>();

        col = GetComponent<Collider2D>();
        requiredTriggers = GetRequiredTriggers(gameObject.GetComponentInParent<DragDrop>());
	}
	
	// Update is called once per frame
	void Update () {
	    
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		bool overSprite = GetComponent<SpriteRenderer> ().bounds.Contains (mousePosition);

        if (!isSet)
        {
            //Sets the position of the sprite to mouse position
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                              Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                                              0.0f);

            // rotate the ship
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.Rotate(new Vector3(0f, 0f, -90f));
            }
            // sets ship if all colliders are hit
            if (Input.GetButton("Fire1") && triggers == requiredTriggers)
            {
                isSet = true;
                GameObject.Find("ScriptManager").GetComponent<GameLogic>().shipsSet++;
            }
        }
        // make so player can move ship after initial placement
        else if (overSprite && anim.GetInteger("Stage") != 2)
        {
            //Check if the mouse1 button was activated
            if (Input.GetButton("Fire1"))
            {
                isSet = false;
                GameObject.Find("ScriptManager").GetComponent<GameLogic>().shipsSet--;
            }
        }
    }

    // called for us by engine when colliding with triggers
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(anim.GetInteger("Stage") == 1)
        {
            triggers++;
            position.Add(col.gameObject.name);
        }        
    }
    // called by engine when no longer colliding
    public void OnTriggerExit2D(Collider2D col)
    {
        if (anim.GetInteger("Stage") == 1)
        {
            triggers--;
            position.Remove(col.gameObject.name);
        }
    }

    // function to get required number of triggers to be colliding with
    public int GetRequiredTriggers(DragDrop ship)
    {
        int required;
        switch (ship.name)
        {
            case "5carrier(Clone)":
                required = 5;
                break;
            case "4battleship(Clone)":
                required = 4;
                break;
            case "3cruiser(Clone)":
                required = 3;
                break;
            case "3submarine(Clone)":
                required = 3;
                break;
            case "2destroyer(Clone)":
                required = 2;
                break;
            default:
                Debug.Log("Error finding required triggers");
                required = 99;
                break;
        }
        return required;
    }
}
