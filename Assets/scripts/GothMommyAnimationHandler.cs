using UnityEngine;

public class GothMommyAnimationHandler : MonoBehaviour
{

    private Animator animator;
    private float timer = 0f;
    private bool isInBattle = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("ToBattle");
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (isInBattle && timer >= 60f)
        {
            animator.SetTrigger("ToSweat");
            timer = 0f;
            isInBattle = false;
        }

    }


}
