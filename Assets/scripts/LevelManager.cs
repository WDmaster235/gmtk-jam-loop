using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public enum PosInputs
    {
        f,
        j,
        s, //space
        e  //empty
    }

    [SerializeField] private int HealingAmount;
    [SerializeField] private int DamageAmount;
    [SerializeField] private int Health;

    [HideInInspector] public int BeatLength { get; set; }
    private int ArrIndex = 0;
    private PosInputs PlayerInput;
    private int currTupBeatLength;
    private bool hasCurrKeyBeenPressed;

    [SerializeField] string currLevelInputs; //string format: "wantedInput""length", ... exmpale: a2,d3,e4,s1

    void Start()
    {
        hasCurrKeyBeenPressed = false;
        currLevelInputs = LevelData.GetLevel1Data();
    }

    void Update()
    {
        if (ArrIndex < currLevelInputs.Length - 1)
        {
            PlayerInput = PlayerInputs();
            //Debug.Log(PlayerInput.ToString()[0]);
            currTupBeatLength = currLevelInputs[ArrIndex + 1] - '0';

            if (PlayerInput.ToString()[0] == currLevelInputs[ArrIndex] && !hasCurrKeyBeenPressed && currLevelInputs[ArrIndex] != 'e')
            {
                Health = Math.Min(30, Health + HealingAmount);
                hasCurrKeyBeenPressed = true;
            }PlayerInput = PlayerInputs();
        //Debug.Log(PlayerInput.ToString()[0]);
        currTupBeatLength = currLevelInputs[ArrIndex + 1] - '0';

        if (PlayerInput.ToString()[0] == currLevelInputs[ArrIndex] && !hasCurrKeyBeenPressed && currLevelInputs[ArrIndex] != 'e')
        {
            Health = Math.Min(30, Health + HealingAmount);
            hasCurrKeyBeenPressed = true;
        }


        else if (PlayerInput.ToString()[0] != 'e' && PlayerInput.ToString()[0] != currLevelInputs[ArrIndex])
        {
            Health -= DamageAmount;
            //Debug.Log(Health);
        }

        if (currTupBeatLength - BeatLength <= 0)
        {
            BeatLength = 0;
            
            if (hasCurrKeyBeenPressed == false && currLevelInputs[ArrIndex] != 'e')
            {
                Health -= DamageAmount;
                Debug.Log(Health);
            }

            ArrIndex += 3;
            //Debug.Log("Next Bit!!");
            if (currLevelInputs[ArrIndex] != 'e')
                Debug.Log(currLevelInputs[ArrIndex]);
            hasCurrKeyBeenPressed = false;
        }


            else if (PlayerInput.ToString()[0] != 'e' && PlayerInput.ToString()[0] != currLevelInputs[ArrIndex])
            {
                Health -= DamageAmount;
                Debug.Log(Health);
            }

            if (currTupBeatLength - BeatLength <= 0)
            {
                BeatLength = 0;

                if (hasCurrKeyBeenPressed == false && currLevelInputs[ArrIndex] != 'e')
                {
                    Health -= DamageAmount;
                    //Debug.Log(Health);
                }

                ArrIndex += 3;
                //Debug.Log("Next Bit!!");
                if (currLevelInputs[ArrIndex] != 'e')
                    Debug.Log(currLevelInputs[ArrIndex]);
                hasCurrKeyBeenPressed = false;
            }
        }
        else
        {
            Win();
        }
    }

    private void Win()
    {

    }

    private PosInputs PlayerInputs()
    {
        if (Input.GetKeyDown("f"))
        {
            return PosInputs.f;
        }
        else if (Input.GetKeyDown("j"))
        {
            return PosInputs.j;
        }
        else if (Input.GetKeyDown("space"))
        {
            return PosInputs.s;
        }
        else
        {
            return PosInputs.e;
        }
    }
}
