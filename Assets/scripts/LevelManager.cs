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
    [SerializeField] public GameObject hulaIndicatorF;
    [SerializeField] public GameObject hulaIndicatorJ;
    [SerializeField] public GameObject hulaIndicatorDodge;

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
    bool indicatorCanSpawn;
    string currLevelInputs; //string format: "wantedInput""length", ... exmpale: a2,d3,e4,s1
    float timeTillNextIndicator;

    void Start()
    {
        hasCurrKeyBeenPressed = false;
        currLevelInputs = LevelData.GetLevel1Data();
        playerAnimationHandler.startAnim();
        indicatorCanSpawn = true;
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
            int timeTillNextTap = currTupBeatLength;
            char nextBeat = 'e';
            
            for (int i = ArrIndex + 3; i < currLevelInputs.Length; i += 3)
            {
                timeTillNextTap += currLevelInputs[i + 1] - '0';
                if (currLevelInputs[i] == 'j' || currLevelInputs[i] == 'f' || currLevelInputs[i] == 's')
                {
                    nextBeat = currLevelInputs[i];
                    break;
                }

            }
            timeTillNextIndicator = timeTillNextTap * beatManager.IntervalLength;

            

            if (timeTillNextIndicator <= 1 && indicatorCanSpawn)
            {
                if (nextBeat == 'j')
                {
                    Instantiate(hulaIndicatorJ, new Vector3(0f, 0f, 0f), Quaternion.identity);
                }
                if (nextBeat == 'f')
                {
                    Instantiate(hulaIndicatorF, new Vector3(0f, 0f, 0f), Quaternion.identity);
                }
                if (nextBeat == 's')
                {
                    Instantiate(hulaIndicatorF, new Vector3(0f, 0f, 0f), Quaternion.identity);
                }

                indicatorCanSpawn = false;
            }
            
            if(timeTillNextIndicator <= 0)
            {
                indicatorCanSpawn = true;
            }

            if (currTupBeatLength - BeatLength <= 0)
            {
                BeatLength = 0;


                timeTillNextTap = currTupBeatLength;
                
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

    private void FixedUpdate()
    {
        timeTillNextIndicator -= Time.deltaTime;
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
