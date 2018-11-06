﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public string roomID;
    public string q;
    public int K;
    public bool firstPlayer;

    public string myName;
    public string myCharacterName;
    public int myAllPeople;
    public int myEnergy;
    public bool myTurn;


    public string enemyName;
    public string enemyCharacterName;
    public int enemyAllPeople;
    public int enemyEnergy;
    public bool enemyTurn;

    public GameObject leaderCharacter;

    public GameObject npc;
    public GameObject characterPlayer;
    public GameObject characterEnemy;

    public static GameData instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);

        }
        DontDestroyOnLoad(gameObject);
    }
}
