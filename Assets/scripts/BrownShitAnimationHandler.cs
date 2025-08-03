using UnityEngine;

public class BrownShitAnimationHandler : MonoBehaviour
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
        if (isInBattle && timer >= 30f && !isSweaty)
        {
            animator.SetTrigger("ToSweat");
            timer = 0f;
            isInBattle = false;
            isSweaty = true;
        }

        if (isSweaty && timer >= 40f)
        {
            animator.SetTrigger("ToRipp");
            timer = 0f;
            isInBattle = false;

        }

    }

}
