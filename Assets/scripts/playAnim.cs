using UnityEngine;
using UnityEngine.EventSystems;

public class playAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public Animator playAnimation;

    void Start()
    {
        playAnimation.speed = 0f;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        playAnimation.speed = 1f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        playAnimation.speed = 0f;
    }
}
