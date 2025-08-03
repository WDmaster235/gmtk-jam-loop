using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ButtonsControllerMainmanue : MonoBehaviour
{
    public GameObject rules;
    


    private void Awake()
    {
        rules = GameObject.Find("Rules");
    }

 
    void Start()
    {
      
       
    }


    void Update()
    {
        
    }

   


    public void StartButton()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
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
