using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimationManager : BaseMonoBehaviour
{
    protected float verticalSpeed = 1.5f;
    protected float horizontalSpeed = 2f;
    protected float verticalAmplitude = 0.5f;
    protected float horizontalAmplitude = 0.5f;


    protected override void Update()
    {
        this.StartAnimation();
    }
    protected abstract void StartAnimation();

    public virtual void SetAnimationParameters(float verticalSpeed, float horizontalSpeed, float verticalAmplitude, float horizontalAmplitude)
    {
        this.verticalSpeed = verticalSpeed;
        this.horizontalSpeed = horizontalSpeed;
        this.verticalAmplitude = verticalAmplitude;
        this.horizontalAmplitude = horizontalAmplitude;
    }

}
