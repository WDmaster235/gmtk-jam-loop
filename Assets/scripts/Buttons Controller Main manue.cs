using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsControllerMainmanue : MonoBehaviour
{
    GameObject rules;


    private void Awake()
    {
        rules = GameObject.Find("Rules");
    }

 
    void Start()
    {
        rules.SetActive(false);
    }


    void Update()
    {

    }

    public void StartButton()
    {
        SceneManager.LoadScene("Level Select", LoadSceneMode.Single);
    }

    public void RulesButton()
    {
        rules.SetActive(true);
    }

    public void BackRulesButton()
    {
        rules.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
