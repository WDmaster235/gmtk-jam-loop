using UnityEngine;
using System.Collections;

public class PlayerAnimationHandler : MonoBehaviour
{
    [Header("Animation Clips")]
    public AnimationClip startAnimation;

    [Header("References")]
    public Animator playerAnimator;
    [SerializeField] Animator HulaHoopFront;
    [SerializeField] Animator HulaHoopBack;

    private bool introFinished = false;


    public void startAnim()
    {
        playerAnimator.Play(startAnimation.name, 0, 0f);
        StartCoroutine(WaitForIntro());
    }

    IEnumerator WaitForIntro()
    {
        yield return new WaitForSeconds(startAnimation.length);
        HulaHoopBack.Play("HulaHoopBackAnim");
        HulaHoopFront.Play("HulaHoopFrontAnim");
        introFinished = true;
    }

    void Update()
    {
        if (!introFinished) return;

        AnimatorStateInfo stateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);
    }

    public bool GetIntroState() { return introFinished;  }
}
