// Script for spawning ships

using UnityEngine;
using System.Collections;

public class SpawnButton : MonoBehaviour {

    public GameObject carrier, battleship, submarine, crusier, destroyer;
    private GameObject button;

    public void SpawnCarrier()
    {        
        Debug.Log("Carrier Spawned");
        Instantiate(carrier);
        GameObject.Find("CarrierButton").SetActive(false);
    }

    public void SpawnBattelship()
    {
        Debug.Log("Battleship Spawned");
        Instantiate(battleship);
        button = GameObject.Find("BattleshipButton");
        button.SetActive(false);
    }

    public void SpawnSubmarine()
    {
        Debug.Log("Submarine Spawned");
        Instantiate(submarine);
        button = GameObject.Find("SubmarineButton");
        button.SetActive(false);
    }

    public void SpawnCruiser()
    {
        Debug.Log("Cruiser Spawned");
        Instantiate(crusier);
        button = GameObject.Find("CruiserButton");
        button.SetActive(false);
    }

    public void SpawnDestroyer()
    {
        Debug.Log("Destroyer Spawned");
        Instantiate(destroyer);
        button = GameObject.Find("DestroyerButton");
        button.SetActive(false);
    }
}  
