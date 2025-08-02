using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    Animator animator;
    Animator hulaAnimator;
    LevelManager levelManager;

    string currentTrigger = "";

    void Start()
    {
        levelManager = FindAnyObjectByType<LevelManager>();
        animator = GetComponent<Animator>();
        hulaAnimator = GetComponentInChildren<Animator>();

        SetTriggerOnce(animator, "StartPlayer");
        SetTriggerOnce(hulaAnimator, "PlayerHulaHoop");
    }

    void Update()
    {
        if (levelManager.Health > 15)
        {
            SetTriggerOnce(animator, "PlayerBattle");
        }
        else if (levelManager.Health > 0)
        {
            SetTriggerOnce(animator, "PlayerBattleSweat");
        }
        else
        {
            SetTriggerOnce(animator, "LoosingPlayer");
        }
    }

    void SetTriggerOnce(Animator anim, string triggerName)
    {
        if (currentTrigger == triggerName) return;

        anim.ResetTrigger(currentTrigger);  // reset previous trigger
        anim.SetTrigger(triggerName);
        currentTrigger = triggerName;
    }
}
