using UnityEngine;

public class BrownShitAnimationHandler : MonoBehaviour
{
    private Animator animator;
    private float timer = 0f;
    private bool isInBattle = true; // Start with Battle

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("ToBattle"); // force initial state just in case
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (isInBattle && timer >= 2f)
        {
            animator.SetTrigger("ToSweat");
            timer = 0f;
            isInBattle = false;
        }
        
    }
}
