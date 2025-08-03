using UnityEngine;

public class dadAnimation: MonoBehaviour
{

    private Animator animator;
    private float timer = 0f;
    private bool isInBattle = true;
    private bool isSweaty = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("ToBattle");
    }

    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);

    }

}