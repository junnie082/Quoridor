﻿using System;
using UnityEngine;


public class Pawn  // Pawn 객체
{
    private Vector2Int mCoordinate;
    private int mPlankNum = 10;
    private int mPawnNum;

    public void SetCoordinate(Vector2Int coordinate)
    {
        mCoordinate = coordinate;
    }

    public int GetPawnNum()
    {
        return mPawnNum;
    }

    public Vector2Int GetCoordinate()
    {
        return mCoordinate;
    }

    public int GetPlankNum()
    {
        return mPlankNum;
    }



    public void UsePlank()
    {
        mPlankNum--;
    }

    public bool IsPlankValid()
    {
        if (mPlankNum <= 0) return false;
        else return true;
    }
}