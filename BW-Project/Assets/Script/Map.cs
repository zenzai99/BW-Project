﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int row;
    public int col;

    public int allCharacter;

    public int maxCharacter;

    public Tile[,] map;

    public GameObject mapRoot;

    void Awake()
    {
        map = new Tile[row,col];
        maxCharacter = row * col;
        int num = 0;

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                map[i, j] = mapRoot.transform.GetChild(num).GetComponent<Tile>();
                map[i, j].row = i;
                map[i, j].col = j;
                num++;
            }
        }
    }


    public void MoveCharacter(int origin_x,int origin_y, int moveto_x,int moveto_y)
    {
        map[moveto_y, moveto_x].LinkCharacter(map[origin_y, origin_x].character);
        map[origin_y, origin_x].UnLinkCharacter();
    }

    public void DestroyCharacter(int x, int y)
    {
        map[y, x].DestroyCharacter();
    }
}
