using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTarget : FsmState
{   
    private ShipAI ship;

    [HideInInspector]
    public int counter;
    public float searchTime;
    public float meneuverTime;
    private float timer;
    private int coin1;
    private int coin2;
    private int coin3;

    void Update()
    {
        searchTime += Time.deltaTime;
        if(timer < meneuverTime)
        {
            timer += Time.deltaTime;
            Meneuver();
        }
        else
        {
            timer = 0f;
            flipCoins();
        }
        

    }

    void Meneuver()
    {
        ship.Yaw(coin1);
        ship.Roll(coin2);
        ship.Pitch(coin3);
    }

    void Awake()
    {
        ship = GetComponent<ShipAI> ();
        Reset();
        flipCoins();
    }

    void OnEnable() 
    {
        Reset();
        flipCoins();
    }

    void OnDisable() 
    {
        StopAllCoroutines();
    }

    void flipCoins()
    {
        coin1 = ship.PosNeg();
        coin2 = ship.PosNeg();
        coin3 = ship.PosNeg();
    }

    void Reset()
    {
        ship.angles = ship.aimVec.transform.eulerAngles;
        ship.enemiesInRange.Clear();
        ship.target = null;
        timer = 0f;
        searchTime = 0f;

        StartCoroutine(ship.FindEnemiesInRange());
		StartCoroutine(ship.AcquireTarget());
    }

}
