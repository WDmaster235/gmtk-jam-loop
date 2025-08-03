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
    [SerializeField] public int Health;

    [Header("Animation")]
    [SerializeField] Animator playerAnimator;
    [SerializeField] PlayerAnimationHandler playerAnimationHandler;
    [SerializeField] Animator hulaHoopAnimator;

    [Header("Music")]
    [SerializeField] BeatManager beatManager;


    [HideInInspector] public int BeatLength { get; set; }
    private int ArrIndex = 0;
    public PosInputs PlayerInput { get; private set; }
    private int currTupBeatLength;
    private bool hasCurrKeyBeenPressed;

    string currLevelInputs; //string format: "wantedInput""length", ... exmpale: a2,d3,e4,s1

    void Start()
    {
        hasCurrKeyBeenPressed = false;
        currLevelInputs = LevelData.GetLevel1Data();
        playerAnimationHandler.startAnim();
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
            }

            currTupBeatLength = currLevelInputs[ArrIndex + 1] - '0';

            if (PlayerInput.ToString()[0] == currLevelInputs[ArrIndex] && !hasCurrKeyBeenPressed && currLevelInputs[ArrIndex] != 'e')
            {
                Health = Math.Min(30, Health + HealingAmount);
                hasCurrKeyBeenPressed = true;
            }


            else if (PlayerInput.ToString()[0] != 'e' && PlayerInput.ToString()[0] != currLevelInputs[ArrIndex])
            {
                Health -= DamageAmount;
            }

            if (currTupBeatLength - BeatLength <= 0)
            {
                BeatLength = 0;


                int timeTillNextTap = currTupBeatLength;

                for (int i = ArrIndex + 3; currLevelInputs[i] != 'j' && currLevelInputs[i] != 'f'; i+=3)
                {
                    timeTillNextTap += currLevelInputs[i+1] - '0';
                }

                hulaHoopAnimator.speed = 1/(beatManager.IntervalLength * timeTillNextTap);

               if (hasCurrKeyBeenPressed == false && currLevelInputs[ArrIndex] != 'e')
               {
                   Health -= DamageAmount;
                   Debug.Log(Health);
               }

                ArrIndex += 3;

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
                }

                ArrIndex += 3;
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
            playerAnimator.Play("HipLeft");
            return PosInputs.f;
        }
        else if (Input.GetKeyDown("j"))
        {
            playerAnimator.Play("HipRight");
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
