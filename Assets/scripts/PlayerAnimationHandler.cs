using UnityEngine;
using System.Collections;

public class PlayerAnimationHandler : MonoBehaviour
{
    [Header("Animation Clips")]
    public AnimationClip startAnimation;
    public AnimationClip BattleAnimation;

    [Header("References")]
    public Animator playerAnimator;
    public Animator hulaAnimator;

    LevelManager levelManager;

    bool introFinished = false;
    string currentTrigger = "";

    const string TRIGGER_BATTLE = "PlayerBattle";
    const string TRIGGER_SWEAT = "PlayerBattleSweat";

    void Start()
    {
        levelManager = FindAnyObjectByType<LevelManager>();

        // Play the intro animation manually
        playerAnimator.Play(startAnimation.name, 0, 0f);

        // Let hula animation start (it's looping and default in its Animator)
        StartCoroutine(WaitForIntro());
    }

    IEnumerator WaitForIntro()
    {
        yield return new WaitForSeconds(startAnimation.length);
        introFinished = true;
    }

    void Update()
    {
        if (!introFinished) return;
        if (levelManager.Health > 15)
        {
            if (currentTrigger != BattleAnimation.name)
            {
                playerAnimator.Play(BattleAnimation.name);
                currentTrigger = BattleAnimation.name;
            }
        }
        else if (levelManager.Health > 0)
        {
            SetTriggerOnce(playerAnimator, TRIGGER_SWEAT);
        }
    }

    void SetTriggerOnce(Animator anim, string triggerName)
    {
        if (currentTrigger == triggerName) return;

        anim.ResetTrigger(currentTrigger);
        anim.SetTrigger(triggerName);
        currentTrigger = triggerName;
    }
}
