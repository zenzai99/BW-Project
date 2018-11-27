﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;

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
    }

    public void RandomSpawnNPC(int n)
    {
        for (int i = 0; i < n; i++)
        {
            SpawnNPC();
        }
    }

    public void RandomSpawnCharacter(string playerName, string skinName, int n)
    {
        for (int i = 0; i < n; i++)
        {
            SpawnCharacter(playerName, skinName);
        }
    }

    public void RandomSpawnMyPeople()
    {
        SpawnCharacter(GameData.instance.myID, GameData.instance.myCharacterName);
    }

    void Spawn(GameObject character,int x,int y)
    {
        GameObject tempCharacter = Instantiate(character, Map.instance.GetBlockPosition(x,y), Quaternion.identity);
        Map.instance.map[y, x].LinkCharacter(tempCharacter);
        tempCharacter.GetComponent<Character>().x = x;
        tempCharacter.GetComponent<Character>().y = y;
        Map.instance.allCharacter++;
    }

    private void SpawnNPC()
    {
        if (Map.instance.allCharacter >= Map.instance.maxCharacter)
        {
            Debug.Log("Error: Map is full");
            return;
        }

        int x = Random.Range(0, Map.instance.col);
        int y = Random.Range(0, Map.instance.row);

        while (Map.instance.map[y, x].GetComponent<Tile>().HaveCharacter())
        {
            Debug.Log("Error: Spawn Repeated");
            x = Random.Range(0, Map.instance.col);
            y = Random.Range(0, Map.instance.row);
        }

        Spawn(CharacterStore.instance.npc, x,y);

        Debug.Log("NPC spawn On :" + Map.instance.map[y, x].name + " <X:" + x + " Y:" + y + ">");
    }

    private void SpawnCharacter(string playerName,string skinName)
    {
        if (Map.instance.allCharacter >= Map.instance.maxCharacter)
        {
            Debug.Log("Error: Map is full");
            return;
        }

        int x = Random.Range(0, Map.instance.col);
        int y = Random.Range(0, Map.instance.row);

        while (Map.instance.map[y, x].GetComponent<Tile>().HaveCharacter())
        {
            Debug.Log("Error: Spawn Repeated");
            x = Random.Range(0, Map.instance.col);
            y = Random.Range(0, Map.instance.row);
        }

        //GameObject tempCharacter;
        if (skinName == "PrayutLeader")
        {
            GameObject tempCharacter = Instantiate(CharacterStore.instance.prayut, Map.instance.GetBlockPosition(x, y), Quaternion.identity);
            Map.instance.map[y, x].LinkCharacter(tempCharacter);
            tempCharacter.GetComponent<Character>().x = x;
            tempCharacter.GetComponent<Character>().y = y;
            tempCharacter.GetComponent<Character>().group = playerName;
            Map.instance.allCharacter++;
        }
        else if (skinName == "TrumpLeader")
        {
            GameObject tempCharacter = Instantiate(CharacterStore.instance.trump, Map.instance.GetBlockPosition(x, y), Quaternion.identity);
            Map.instance.map[y, x].LinkCharacter(tempCharacter);
            tempCharacter.GetComponent<Character>().x = x;
            tempCharacter.GetComponent<Character>().y = y;
            tempCharacter.GetComponent<Character>().group = playerName;
            Map.instance.allCharacter++;
        }
        else if (skinName == "KimLeader")
        {
            GameObject tempCharacter = Instantiate(CharacterStore.instance.kim, Map.instance.GetBlockPosition(x, y), Quaternion.identity);
            Map.instance.map[y, x].LinkCharacter(tempCharacter);
            tempCharacter.GetComponent<Character>().x = x;
            tempCharacter.GetComponent<Character>().y = y;
            tempCharacter.GetComponent<Character>().group = playerName;
            Map.instance.allCharacter++;
        }
        else
        if (skinName == "Prayut")
        {
            GameObject tempCharacter = Instantiate(CharacterStore.instance.prayutGuard, Map.instance.GetBlockPosition(x, y), Quaternion.identity);
            Map.instance.map[y, x].LinkCharacter(tempCharacter);
            tempCharacter.GetComponent<Character>().x = x;
            tempCharacter.GetComponent<Character>().y = y;
            tempCharacter.GetComponent<Character>().group = playerName;
            Map.instance.allCharacter++;
        }
        else if (skinName == "Trump")
        {
            GameObject tempCharacter = Instantiate(CharacterStore.instance.trumpGuard, Map.instance.GetBlockPosition(x, y), Quaternion.identity);
            Map.instance.map[y, x].LinkCharacter(tempCharacter);
            tempCharacter.GetComponent<Character>().x = x;
            tempCharacter.GetComponent<Character>().y = y;
            tempCharacter.GetComponent<Character>().group = playerName;
            Map.instance.allCharacter++;
        }
        else if (skinName == "Kim")
        {
            GameObject tempCharacter = Instantiate(CharacterStore.instance.kimGuard, Map.instance.GetBlockPosition(x, y), Quaternion.identity);
            Map.instance.map[y, x].LinkCharacter(tempCharacter);
            tempCharacter.GetComponent<Character>().x = x;
            tempCharacter.GetComponent<Character>().y = y;
            tempCharacter.GetComponent<Character>().group = playerName;
            Map.instance.allCharacter++;
        }
        else
        {
            Debug.Log("Error : characterPlayerName in Spawner Player<"+ playerName + ">");
        }

        Debug.Log("Character<"+ playerName + "> spawn On :" + Map.instance.map[y, x].name + " <X:" + x + " Y:" + y + ">");
    }

    public void SpawnNPC(int x,int y)
    {
        Spawn(CharacterStore.instance.npc, x, y);

        Debug.Log("NPC spawn On :" + Map.instance.map[y, x].name + " <X:" + x + " Y:" + y + ">");
    }

    public void SpawnCharacter(string playerName, string skinName, int x, int y)
    {
        if (skinName == "PrayutLeader")
        {
            GameObject tempCharacter = Instantiate(CharacterStore.instance.prayut, Map.instance.GetBlockPosition(x, y), Quaternion.identity);
            Map.instance.map[y, x].LinkCharacter(tempCharacter);
            tempCharacter.GetComponent<Character>().x = x;
            tempCharacter.GetComponent<Character>().y = y;
            tempCharacter.GetComponent<Character>().group = playerName;
            Map.instance.allCharacter++;
        }
        else if (skinName == "TrumpLeader")
        {
            GameObject tempCharacter = Instantiate(CharacterStore.instance.trump, Map.instance.GetBlockPosition(x, y), Quaternion.identity);
            Map.instance.map[y, x].LinkCharacter(tempCharacter);
            tempCharacter.GetComponent<Character>().x = x;
            tempCharacter.GetComponent<Character>().y = y;
            tempCharacter.GetComponent<Character>().group = playerName;
            Map.instance.allCharacter++;
        }
        else if (skinName == "KimLeader")
        {
            GameObject tempCharacter = Instantiate(CharacterStore.instance.kim, Map.instance.GetBlockPosition(x, y), Quaternion.identity);
            Map.instance.map[y, x].LinkCharacter(tempCharacter);
            tempCharacter.GetComponent<Character>().x = x;
            tempCharacter.GetComponent<Character>().y = y;
            tempCharacter.GetComponent<Character>().group = playerName;
            Map.instance.allCharacter++;
        }
        else
        if (skinName == "Prayut")
        {
            GameObject tempCharacter = Instantiate(CharacterStore.instance.prayutGuard, Map.instance.GetBlockPosition(x, y), Quaternion.identity);
            Map.instance.map[y, x].LinkCharacter(tempCharacter);
            tempCharacter.GetComponent<Character>().x = x;
            tempCharacter.GetComponent<Character>().y = y;
            tempCharacter.GetComponent<Character>().group = playerName;
            Map.instance.allCharacter++;
        }
        else if (skinName == "Trump")
        {
            GameObject tempCharacter = Instantiate(CharacterStore.instance.trumpGuard, Map.instance.GetBlockPosition(x, y), Quaternion.identity);
            Map.instance.map[y, x].LinkCharacter(tempCharacter);
            tempCharacter.GetComponent<Character>().x = x;
            tempCharacter.GetComponent<Character>().y = y;
            tempCharacter.GetComponent<Character>().group = playerName;
            Map.instance.allCharacter++;
        }
        else if (skinName == "Kim")
        {
            GameObject tempCharacter = Instantiate(CharacterStore.instance.kimGuard, Map.instance.GetBlockPosition(x, y), Quaternion.identity);
            Map.instance.map[y, x].LinkCharacter(tempCharacter);
            tempCharacter.GetComponent<Character>().x = x;
            tempCharacter.GetComponent<Character>().y = y;
            tempCharacter.GetComponent<Character>().group = playerName;
            Map.instance.allCharacter++;
        }
        else
        {
            Debug.LogError("Error : characterPlayerName in Spawner");
        }

        Debug.Log("Character<" + playerName + "> spawn On :" + Map.instance.map[y, x].name + " <X:" + x + " Y:" + y + ">");
    }


}
