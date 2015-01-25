﻿using System;
using UnityEngine;

public class GetInput : MonoBehaviour
{
    public int numberOfPlayers = 2;


    private void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            if (LevelManager.IsPlayerAlive(i))
            {
                GetPlayerInput(i);
            }
        }
    }

    void GetPlayerInput(int playerNumber)
    {
        var controllerString = GameManager.GetControllerString(playerNumber);
        Debug.Log(controllerString);
        Debug.Log(playerNumber);

        if (Input.GetButtonDown(controllerString + "Left Bump") && GameManager.JumpEnabled)
        {
            LevelManager.GetPlayer(playerNumber).Jump();
        }

        if (Input.GetButtonDown(controllerString + "Right Bump"))
        {
            //Attack
            LevelManager.GetPlayer(playerNumber).AttackSide();
        }

        if (Input.GetAxis(controllerString + "Trigger Left") > 0.9f)
        {
            //Magic Chrum Chrum
        }

        if (Input.GetAxis(controllerString + "Trigger Right") > 0.9f)
        {
            LevelManager.GetPlayer(playerNumber).AttackUpDown();
        }

        float axis_X = Input.GetAxis(controllerString + "Axis X");
        float axis_Y = Input.GetAxis(controllerString + "Axis Y");
        float axis_3 = Input.GetAxis(controllerString + "Axis 3");
        float axis_4 = Input.GetAxis(controllerString + "Axis 4");

        LevelManager.GetPlayer(playerNumber).Move(axis_X, -axis_Y);
        if (axis_3 != 0.0f || axis_4 != 0.0f)
            LevelManager.GetPlayer(playerNumber).Rotate(axis_3, -axis_4);
    }
}