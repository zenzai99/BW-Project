﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName;
    public string characterPlayerName;
    public int myAllPeople;
    public bool myTurn;

    public GameObject leaderCharacter;

    public MouseScript mouseScript;
    private PathFinder pathFinder;

    public bool selectCharecter;

    public delegate void state();
    public state active;

    void Start()
    {
        pathFinder = FindObjectOfType<PathFinder>();

        playerName = GameData.instance.myName;
        characterPlayerName = GameData.instance.myCharacterName;
        myAllPeople = GameData.instance.myAllPeople;
        myTurn = GameData.instance.myTurn;

        if (GameData.instance.firstPlayer)
        {
            SetFrist();
        }
        else if (GameData.instance.firstPlayer)
        {
            SetSecond();
        }
    }

    // Update is called once per frame

    public void SetFrist()
    {
        GameData.instance.myEnergy = 5;
        active = (state)(Playing);
        active();
    }

    public void SetSecond()
    {
        GameData.instance.myEnergy = 6;
        active = (state)(Waiting);
        active();
    }

    public void updateVariable()
    {
        GameData.instance.myAllPeople = myAllPeople;
        GameData.instance.myTurn = myTurn;
    }

    void Update()
    {
        updateVariable();

        if (active == Playing && myTurn) //  to self
        {
            active = (state)(Playing);
            active();
        }
        else if (active == Playing && !myTurn) // Playing to Waiting
        {
            active = (state)(Waiting);
            active();
        }
        else if (active == Waiting && !myTurn) // to self
        {
            active = (state)(Waiting);
            active();
        }
        else if (active == Waiting && myTurn) // Waiting to Playing
        {
            active = (state)(Playing);
            active();
        }
        else if (active == Waiting && GameSystem.instance.End) // Waiting to end
        {
            active = (state)(Waiting);
            active();
        }


        if (active == Playing && GameData.instance.myEnergy == 0)
        {
            EndTurn();
        }
    }

    private void Playing()
    {

        if (!selectCharecter)
        {
            MouseOver();
            SelectCharecter();
        }
        else if (selectCharecter)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.collider.tag == "Path")
            {
                MoveCharecter();

            }
            else
            {
                SelectCharecter();
            }
        }

    }

    private void Waiting()
    {
        MouseOver();

        if (!GameSystem.instance.delayLoad)
        {
            StartCoroutine(GameSystem.instance.LoadDelay(1));
        }
        
    }

    public void StartTurn()
    {
        GameData.instance.myEnergy = 5;
        myTurn = true;
    }

    public void UesSkill()
    {
        leaderCharacter.GetComponent<LeaderCharacter>().UseSkill();
    }



    public void EndTurn()
    {
        if (myTurn)
        {
            myTurn = false;
            KNN.instance.StartKNN();
            myAllPeople = GameSystem.instance.HowManyMyPeople(playerName);
            if (!GameSystem.instance.delayUp)
            {
                StartCoroutine(GameSystem.instance.UpDelay(1));
            }
            GameSystem.instance.NextQueue();
        }
    }

    public void MouseOver()
    {
        mouseScript.ShowMouseOverObject();
    }

    private void SelectCharecter()
    {
        mouseScript.MouseSelectCharacter(ref selectCharecter, pathFinder, this);

    }
    private void MoveCharecter()
    {
        mouseScript.SelectToMove(ref selectCharecter, ref GameData.instance.myEnergy, pathFinder);

    }
}
