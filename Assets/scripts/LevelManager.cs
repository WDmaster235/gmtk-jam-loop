using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public enum PosInputs 
    {
        a, d, Lc, Rc, empty,
    }

    public int BeatLength = 0;

    private int Health;
    private int ArrIndex = 0;
    private int TupBeatLength;
    private enum PlayerInput;

    void Start() 
    {
        Health = 30;
    }

    void Update() 
    {

        TupBeatLength = Inputs[ArrIndex].Item2;
        if (TupBeatLength - BeatLength == 0) 
        {
            BeatLength = 0;
            ArrIndex++;
        }

        PlayerInput = PlayerInputs();

        if (Inputs[ArrIndex].Item1 != PlayerInput) 
        {
            Health -= 3;
        }
        else if(Inputs[ArrIndex].Item1 != empty)
        {
            Health++;
        }

    }

    private PosInputs PlayerInputs() 
    {
        if (Input.GetKeyDown("a"))
        {
            return a;
        }
        else if (Input.GetKeyDown("d"))
        {
            return d;
        }
        else if (IInput.GetMouseButtonDown(0))
        {
            return Lc;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            return Rc;
        }
        else 
        {
            return empty;
        }
    } 
}
