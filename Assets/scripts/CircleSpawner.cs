using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    [HideInInspector] public int BeatLength { get; set; }
    private int ArrIndex = 0;
    private int currTupBeatLength;
    string currLevelInputs; //string format: "wantedInput""length", ... exmpale: a2,d3,e4,s1
    [SerializeField] public GameObject hulaIndicatorF;
    [SerializeField] public GameObject hulaIndicatorJ;
    [SerializeField] public GameObject hulaIndicatorDodge;

    void Start()
    {
        currLevelInputs = LevelData.GetLevel1Data();
    }

    void Update()
    {
        if (ArrIndex + 1 < currLevelInputs.Length)
            currTupBeatLength = currLevelInputs[ArrIndex + 1] - '0';
        if (currTupBeatLength - BeatLength <= 0)
        {
            BeatLength = 0;
            ArrIndex += 3;
            if (currLevelInputs[ArrIndex] == 'f')
                Instantiate(hulaIndicatorF, new Vector3(-2.5f, -1.3f, 0), Quaternion.identity);
            else if (currLevelInputs[ArrIndex] == 'j')
                Instantiate(hulaIndicatorJ, new Vector3(-2.5f, -1.3f, 0), Quaternion.identity);
            else if (currLevelInputs[ArrIndex] == 's')
                Instantiate(hulaIndicatorDodge, new Vector3(-2.5f, -1.3f, 0), Quaternion.identity);
        }
    }
}
