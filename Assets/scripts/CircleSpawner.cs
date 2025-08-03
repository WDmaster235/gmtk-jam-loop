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
    string[] levelData;
    [SerializeField] int levelNum;
    
    void Start()
    {
        levelData = new string[3];
        currLevelInputs = LevelData.GetLevel1Data();
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

        levelData[2] = "e8,e8," +
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
