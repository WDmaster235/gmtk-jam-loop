using UnityEngine;
using System.Collections;

public class PlayerAnimationHandler : MonoBehaviour
{
    [Header("Animation Clips")]
    public AnimationClip startAnimation;

    [Header("References")]
    public Animator playerAnimator;

    private bool introFinished = false;

    private const string TRIGGER_HIP_LEFT = "HipLeft";
    private const string TRIGGER_HIP_RIGHT = "HipRight";

    void Start()
    {
        // Play the intro animation
        playerAnimator.Play(startAnimation.name, 0, 0f);
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

        AnimatorStateInfo stateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);

        if (Input.GetKeyDown(KeyCode.F) && !stateInfo.IsName("HipLeft"))
        {
            playerAnimator.ResetTrigger(TRIGGER_HIP_RIGHT); // reset the other trigger
            playerAnimator.SetTrigger(TRIGGER_HIP_LEFT);
        }
        else if (Input.GetKeyDown(KeyCode.J) && !stateInfo.IsName("HipRight"))
        {
            playerAnimator.ResetTrigger(TRIGGER_HIP_LEFT); // reset the other trigger
            playerAnimator.SetTrigger(TRIGGER_HIP_RIGHT);
        }
    }
}
