using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for holding the main game data

public class GameData : MonoBehaviour
{
    public static GameObject player;
    public static GameObject ghostPlayer;
    public static GameObject cam;
    public static GameObject ghostCamera;
    public static GameObject ship;
    public static GameObject ghostShip;
    public static Rigidbody shipRB;
    public static Rigidbody ghostShipRB;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ghostPlayer = GameObject.FindGameObjectWithTag("Ghost Player");
        cam = Camera.main.gameObject;
        ghostCamera = GameObject.FindGameObjectWithTag("Ghost Camera");
        ship = GameObject.FindGameObjectWithTag("Ship");
        ghostShip = GameObject.FindGameObjectWithTag("Ghost Ship");
        shipRB = ship.GetComponent<Rigidbody>();
        ghostShipRB = ghostShip.GetComponent<Rigidbody>();
    }

}
