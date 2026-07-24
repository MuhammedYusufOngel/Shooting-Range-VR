using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float pinchValue = pinchAnimationAction.action.ReadValue<float>();
        animator.SetFloat("Trigger", pinchValue);

        float gripValue = gripAnimationAction.action.ReadValue<float>();
        animator.SetFloat("Grip", gripValue);

        Debug.Log($"Pinch Value: {pinchValue}, Grip Value: {gripValue}");
    }
}
