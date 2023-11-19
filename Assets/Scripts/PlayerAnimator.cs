using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    //Defined values in animator as constants
    private const string IS_WALKING = "IsWalking";
    private const string MOVEMENT_BLEND = "Movement";
    private const string IS_BACKWARDS_WALKING = "IsBackwardsWalking";
    private const float ANIMATION_DAMPENING = 0.1f;


    [SerializeField] private Player player;
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
        transform.localPosition = Vector3.zero;
    }

    private void Update() {
        animator.SetBool(IS_WALKING, player.IsWalking());
        transform.localPosition = Vector3.zero;

        if (player.IsWalking())
        {
            AnimationHandler(player.GetBlendFloat());
        }
        else
        {
            AnimationHandler(0f);
        }

    }
    private void AnimationHandler(float blendFloat) => animator.SetFloat(MOVEMENT_BLEND, blendFloat, ANIMATION_DAMPENING, Time.deltaTime);
}
