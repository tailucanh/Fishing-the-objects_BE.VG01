using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Spine;
using Spine.Unity;
using UnityEngine;

public enum StateHook
{
    [Description("Moc gap do Open")]
    Open,

    [Description("Moc gap do Close")]
    Close,

    [Description("Moc gap do wating")]
    Waiting
}

public class ExtendHook : AnimationManager
{
    protected static ExtendHook instance;
    public static ExtendHook Instance => instance;
    [SerializeField] protected Vector3 initialPosition;
    protected SkeletonAnimation skeletonAnimation;

    protected override void Awake()
    {
        if (ExtendHook.instance != null) return;
        ExtendHook.instance = this;
    }

    protected override void Start()
    {
      
        initialPosition = transform.localPosition;
        this.SetAnimationParameters(1f, 1f, 0.5f, 0.5f);
        skeletonAnimation = GetComponent<SkeletonAnimation>();
    }

   

    protected override void StartAnimation()
    {

        float verticalOffset = Mathf.Sin(Time.time * verticalSpeed) * verticalAmplitude;
        float horizontalOffset = Mathf.Sin(Time.time * horizontalSpeed) * horizontalAmplitude;

        transform.localPosition = initialPosition + new Vector3(horizontalOffset, verticalOffset, 0f);
    }
    public virtual void AnimationHookOpen()
    {
        skeletonAnimation.AnimationState.SetAnimation(0, EnumHelper.GetDescription(StateHook.Open), false);

    }

    public virtual void AnimationHookWating()
    {
        skeletonAnimation.AnimationState.SetAnimation(0, EnumHelper.GetDescription(StateHook.Waiting), false);
    }

    public virtual void AnimationHookClose()
    {
        skeletonAnimation.AnimationState.SetAnimation(0, EnumHelper.GetDescription(StateHook.Close), false);

    }

    public virtual void ShowHook()
    {
        gameObject.SetActive(true);
       
    }



    public virtual void HideHook()
    {
        gameObject.SetActive(false);
    }

    public virtual void EnebalAnimation()
    {
         enabled = true;
    }

    public virtual void DisableAnimation()
    {
        enabled = false;
    }

}
