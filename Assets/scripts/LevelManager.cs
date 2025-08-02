using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public enum PosInputs
    {
        a,
        d,
        j,
        empty
    }

    [SerializeField] private int HealingAmount;
    [SerializeField] private int DamageAmount;
    [SerializeField] private int Health;

    [HideInInspector] public int BeatLength { get; set; }
    private int ArrIndex = 0;
    private PosInputs PlayerInput;
    private int currTupBeatLength;
    private bool hasCurrKeyBeenPressed;

    [SerializeField] List<Tuple<PosInputs, int>> currLevelInputs = new List<Tuple<PosInputs, int>>()
    {
        new Tuple<PosInputs, int>(PosInputs.empty, 14),
        new Tuple<PosInputs, int>(PosInputs.a, 2),
        new Tuple<PosInputs, int>(PosInputs.empty, 2),
        new Tuple<PosInputs, int>(PosInputs.d, 2),
        new Tuple<PosInputs, int>(PosInputs.empty, 4),
        new Tuple<PosInputs, int>(PosInputs.a, 2),
        new Tuple<PosInputs, int>(PosInputs.d, 2),
        new Tuple<PosInputs, int>(PosInputs.empty, 2),

        new Tuple<PosInputs, int>(PosInputs.a, 2),
        new Tuple<PosInputs, int>(PosInputs.empty, 2),
        new Tuple<PosInputs, int>(PosInputs.d, 2),
        new Tuple<PosInputs, int>(PosInputs.empty, 4),
        new Tuple<PosInputs, int>(PosInputs.a, 2),
        new Tuple<PosInputs, int>(PosInputs.d, 2),
        new Tuple<PosInputs, int>(PosInputs.empty, 2),

        new Tuple<PosInputs, int>(PosInputs.a, 2),
        new Tuple<PosInputs, int>(PosInputs.empty, 2),
        new Tuple<PosInputs, int>(PosInputs.d, 2),
        new Tuple<PosInputs, int>(PosInputs.empty, 4),
        new Tuple<PosInputs, int>(PosInputs.a, 2),
        new Tuple<PosInputs, int>(PosInputs.d, 2),
        new Tuple<PosInputs, int>(PosInputs.empty, 2),

        new Tuple<PosInputs, int>(PosInputs.empty, 2),
        new Tuple<PosInputs, int>(PosInputs.a, 2),
        new Tuple<PosInputs, int>(PosInputs.empty, 2),
        new Tuple<PosInputs, int>(PosInputs.d, 2),
        new Tuple<PosInputs, int>(PosInputs.empty, 2),
        new Tuple<PosInputs, int>(PosInputs.a, 2),
        new Tuple<PosInputs, int>(PosInputs.empty, 2),
        new Tuple<PosInputs, int>(PosInputs.d, 2),

        new Tuple<PosInputs, int>(PosInputs.a, 2),
        new Tuple<PosInputs, int>(PosInputs.empty, 2),
        new Tuple<PosInputs, int>(PosInputs.d, 2),
        new Tuple<PosInputs, int>(PosInputs.empty, 4),
        new Tuple<PosInputs, int>(PosInputs.a, 2),
        new Tuple<PosInputs, int>(PosInputs.d, 2),
        new Tuple<PosInputs, int>(PosInputs.empty, 2),

        new Tuple<PosInputs, int>(PosInputs.a, 2),
        new Tuple<PosInputs, int>(PosInputs.empty, 2),
        new Tuple<PosInputs, int>(PosInputs.d, 2),
        new Tuple<PosInputs, int>(PosInputs.empty, 4),
        new Tuple<PosInputs, int>(PosInputs.a, 2),
        new Tuple<PosInputs, int>(PosInputs.d, 2),
        new Tuple<PosInputs, int>(PosInputs.empty, 2),

        new Tuple<PosInputs, int>(PosInputs.empty, 2),
        new Tuple<PosInputs, int>(PosInputs.a, 2),
        new Tuple<PosInputs, int>(PosInputs.empty, 2),
        new Tuple<PosInputs, int>(PosInputs.d, 2),
        new Tuple<PosInputs, int>(PosInputs.empty, 2),
        new Tuple<PosInputs, int>(PosInputs.a, 2),
        new Tuple<PosInputs, int>(PosInputs.empty, 4),

        new Tuple<PosInputs, int>(PosInputs.empty, 2),
        new Tuple<PosInputs, int>(PosInputs.d, 2),
        new Tuple<PosInputs, int>(PosInputs.empty, 2),
        new Tuple<PosInputs, int>(PosInputs.a, 2),
        new Tuple<PosInputs, int>(PosInputs.empty, 2),
        new Tuple<PosInputs, int>(PosInputs.d, 2),
        new Tuple<PosInputs, int>(PosInputs.empty, 4),
    };


    void Start()
    {
        hasCurrKeyBeenPressed = false;
    }

    void Update()
    {
        //Debug.Log(Health);
        PlayerInput = PlayerInputs();
        currTupBeatLength = currLevelInputs[ArrIndex].Item2;

        if (PlayerInput == currLevelInputs[ArrIndex].Item1 && !hasCurrKeyBeenPressed && currLevelInputs[ArrIndex].Item1 != PosInputs.empty)
        {
            Health = Math.Min(30, Health + HealingAmount);
            hasCurrKeyBeenPressed = true;
        }

        else if (PlayerInput != currLevelInputs[ArrIndex].Item1 && PlayerInput != PosInputs.empty)
        {
            Health -= DamageAmount;
        }

        if (currTupBeatLength - BeatLength <= 0)
        {
            BeatLength = 0;
            
            if (hasCurrKeyBeenPressed == false && currLevelInputs[ArrIndex].Item1 != PosInputs.empty)
            {
                Health -= DamageAmount;
            }

            ArrIndex++;
            Debug.Log("Next Bit!!");
            Debug.Log(currLevelInputs[ArrIndex].Item1);
            hasCurrKeyBeenPressed = false;
        }
    }

    private PosInputs PlayerInputs()
    {
        if (Input.GetKeyDown("a"))
        {
            return PosInputs.a;
        }
        else if (Input.GetKeyDown("d"))
        {
            return PosInputs.d;
        }
        else if (Input.GetKeyDown("j"))
        {
            return PosInputs.j;
        }
        else
        {
            return PosInputs.empty;
        }
    }
}
