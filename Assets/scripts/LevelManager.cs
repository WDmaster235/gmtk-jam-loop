using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] int levelNum;
    string[] levelData;
    string[] nextLevel = {"Level 2", "Main Menu"};
    string[] currentLevel = { "Level 1", "Level 2" };
    string currLevelInputs; //string format: "wantedInput""length", ... exmpale: a2,d3,e4,s1

    void Start()
    {
        levelData = new string[3];
        hasCurrKeyBeenPressed = false;
        levelData[0] = "e8,e8," +

            "f2,e2,j2,e4,f2,j2,e2," +
            "f2,e2,j2,e4,f2,j2,e2," +
            "f2,e2,j2,e4,f2,j2,e2," +
            "e2,f2,e2,j2,e2,f2,e2,j2," +
            "f2,e2,j2,e4,f2,j2,e2," +
            "f2,e2,j2,e4,f2,j2,e2," +
            "e2,f2,e2,j2,e2,f2,e4," +
            "e2,j2,e2,f2,e2,j2,e4," +

            "e4,f2,e2,j2,e2,f2,e2," +
            "e4,j2,e2,f2,e2,j2,e2," +
            "e4,f2,e2,j2,e2,f2,e2," +
            "j2,e2,f2,e2,j2,e2,f2,e2," +
            "e4,j2,e2,f2,e2,j2,e2," +
            "f2,e2,j2,e4,f2,e4," +
            "e4,j2,e2,f2,e2,j2,e2," +
            "e4,f2,e2,j2,e2,f2,e2," +

            "e4,j2,e2,f2,e2,j2,e2," +
            "e4,f2,e2,j2,e2,f2,e2," +
            "e4,j2,e2,e4,f2,e2," +
            "j2,e2,f2,e2,j2,e2,f2,e2," +
            "e4,j2,e2,f2,e2,j2,e2," +
            "f2,e2,j2,e4,f2,e4," +
            "e4,j2,e2,e4,f2,e2," +
            "e4,j2,e2,f2,e2,j2,e2," +

            "f2,e2,j2,e2,f2,e2,j2,e2," +
            "f2,e4,s2,e8," +
            "j2,e2,f2,e2,j2,e2,f2,e2," +
            "j2,e4,s2,e8," +
            "f2,e2,j2,e2,f2,e6," +
            "j2,e2,f2,e2,j2,e6," +
            "f2,e2,j2,e2,f2,e2,j2,e2," +
            "e4,f2,e2,j2,e2,f2,e2," +

            "e2,f2,j2,f2,e2,s2,e4," +

            "j2,e2,f2,e2,j2,e2,f2,e2," +
            "j2,e2,f2,e2,j2,e2,s2,e2," +
            "f2,e2,j2,e2,f2,e2,j2,e2," +
            "f2,j2,f2,j2,e4,s2,e2," +

            "f2,e2,j2,e2,f2,e2,j2,e2," +
            "f2,e2,j2,e2,f2,e2,s2,e2," +
            "j2,e2,f2,e2,j2,e2,f2,e2," +
            "j2,f2,j2,f2,e4,s2,e2," +

            "f2,e2,j2,e4,f2,j2,e2," +
            "f2,e2,j2,e4,f2,j2,e2," +
            "f2,e2,j2,e4,f2,j2,e2," +
            "e2,f2,e2,j2,e2,f2,e2,j2," +
            "f2,e2,j2,e4,f2,j2,e2," +
            "f2,e2,j2,e4,f2,j2,e2," +
            "e2,f2,j2,f2,e8," +
            "e2,j2,f2,j2,e8,";

        levelData[1] = "e8,e8," +

        "e4,f2,e2,e4,j2,e2," +
        "e4,f2,e2,e4,j2,f2," +
        "e4,j2,e2,e4,f2,e2," +
        "e4,j2,e2,e4,f2,j2," +
        "e4,f2,e2,e4,j2,e2," +
        "e4,f2,e2,e4,j2,f2," +
        "e4,j2,e2,e4,f2,e2," +
        "j1,f1,j1,e1,f1,j1,f1,e1,e1,j2,f2,j1,f2," +

        "s2,e2,f2,e2,e4,j2,f2," +
        "e2,e2,j2,e2,e4,f2,j2," +
        "s2,e2,f2,e2,e4,j2,f2," +
        "e2,e2,j2,e2,e4,f2,j2," +
        "s2,e2,f2,e2,e4,j2,f2," +
        "e2,e2,j2,e2,e4,f2,j2," +
        "s2,e2,f2,e2,e4,j2,f2," +
        "e2,e2,j2,e2,e4,f2,j2," +

        "f2,e1,j2,e3,f2,e1,j2,e3," +
        "f2,e1,j2,e3,f2,e1,j2,e3," +
        "f2,e1,j2,e3,f2,e1,j2,e3," +
        "f2,e1,j2,e3,f2,e1,j2,e3," +
        "f2,e1,j2,e3,f2,e1,j2,e3," +
        "f2,e1,j2,e3,f2,e1,j2,e3," +
        "f2,e1,j2,e3,f2,e1,j2,e3," +
        "f2,e1,j2,e3,f2,e1,j2,e3," +

        "e4,f2,e2,e4,j2,e2," +
        "e4,j2,e2,e4,f2,j2," +
        "e4,f2,e2,e4,j2,e2," +
        "e4,j2,e2,e4,f2,j2," +
        "e4,f2,e2,e4,j2,e2," +
        "e4,j2,e2,e4,f2,j2," +
        "e4,f2,e2,e4,j2,e2," +
        "e4,j2,e2,e4,f2,j2," +

        "f2,e2,j2,e2,f2,e2,j2,e2," +
        "f2,e2,j2,e2,f2,e2,j2,e2," +
        "f2,e2,j2,e2,f2,e2,j2,e2," +
        "f2,e2,j2,e2,f2,e2,j2,e2," +
        "f2,e2,j2,e2,f2,e2,j2,e2," +

        "s2,e2,e4,e8," +

        "s2,e6,s2,e6," +
        "s2,e6,s2,e2,f2,j2," +
        "s2,e6,s2,e6," +
        "s2,e6,s2,e2,f2,j2," +
        "s2,e6,s2,e6," +
        "s2,e6,s2,e2,f2,j2," +
        "s2,e6,s2,e6," +
        "s2,e6,s2,e2,f2,j2,";

        levelData[2] = "e8,e8" +
        "f2,e2,j2,e2,f2,e2,j2,e2," +
        "f2,e2,j2,e2,f2,e2,j2,e2," +
        "f2,e2,j2,e2,f2,e2,j2,e2," +
        "f2,e2,j2,e2,f2,e2,j2,e2," +

        "f2,j2,f2,e2,j2,e2,f2,e2," +
        "f2,j2,f2,e2,j2,e2,f2,e2," +
        "j2,e2,e4,e8," +
        "f2,e2,j2,e2,f2,e2,j2,e2," +

        "f2,e4,j2,e8," +
        "f2,e4,j2,e4,s2,e2," +
        "f2,e4,j2,e8," +
        "f2,e4,j2,e4,s2,e2," +
        "f2,e4,j2,e8," +
        "f2,e4,j2,e4,s2,e2," +
        "f2,e4,j2,e8," +
        "f2,e2,j2,e2,f2,e2,j2,e2," +

        "f2,e2,e4,j2,e2,e4," +
        "f2,j2,f2,e2,e8," +
        "f2,j2,f2,e2,e8," +
        "f2,j2,f2,e2,e8," +

        "j2,e2,f2,e2,e4,j2,e2" +
        "f2,j2,f2,e2,e4,j2,e2" +
        "f2,j2,f2,e2,e4,j2,e2" +
        "f2,j2,f2,e2,j2,e2,f2,e2" +

        "j2,e2,f2,e2,j2,e2,f2,e2," +
        "j2,e2,f2,e2,j2,e2,f2,e2," +
        "j2,e2,f2,e2,j2,e2,f2,e2," +
        "j2,e2,f2,e2,j2,e2,s2,e2," +

        "f2,e2,e4,j2,e2,e4," +
        "f2,e2,j2,e2,f2,e2,j2,e2" +
        "f2,j2,f2,j2,f2,e2,j2,e2" +
        "f2,j2,f2,j2,f2,e2,j2,e2" +

        "f2,e2,j2,e2,f2,e2,j2,e2," +
        "f2,e2,j2,e2,f2,e2,j2,e2," +
        "f2,e2,j2,e2,f2,e2,j2,e2," +
        "f2,e2,j2,e2,f2,j2,f2,j2," +

        "f2,e2,j2,e2,f2,e2,j2,e2," +
        "f2,e2,j2,e2,f2,e2,j2,e2," +
        "f2,e2,j2,e2,f2,e2,j2,e2," +
        "f2,e2,j2,e2,f2,j2,f2,j2," +

        "f2,e2,e4,j2,e2,e4," +
        "f2,e2,j2,e2,f2,e2,j2,e2" +
        "f2,j2,f2,j2,f2,e2,j2,e2" +
        "f2,j2,f2,j2,f2,e2,j2,e2" +

        "f2,e2,j2,e2,f2,e2,j2,e2," +
        "f2,e2,j2,e2,f2,e2,j2,e2," +
        "f2,e2,j2,e2,f2,e2,j2,e2," +
        "f2,e2,j2,e2,f2,e2,j2,e2," +

        "f2";

        currLevelInputs = levelData[levelNum];
        playerAnimationHandler.startAnim();
    }

    void Update()
    {
        if(Health <= 0) 
        {
            lose();
        }

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
        SceneManager.LoadScene(nextLevel[levelNum], LoadSceneMode.Single);
    }

    private void lose() 
    {
        SceneManager.LoadScene(currentLevel[levelNum], LoadSceneMode.Single);
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
