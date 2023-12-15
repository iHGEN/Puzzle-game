using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Hand_animation_input : MonoBehaviour
{
    public InputActionProperty trigger;
    public InputActionProperty grip;
    public Animator animator;


    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Grip", grip.action.ReadValue<float>());
        animator.SetFloat("Trigger", grip.action.ReadValue<float>());
    }
}
