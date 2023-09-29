using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Spine;
using Spine.Unity;
using UnityEngine;


public enum StateBoat
{
    [Description("Starting")]
    Start,

    [Description("Ending")]
    End,

    [Description("Bien mat")]
    Disappear
}


public class ExtendBoat : BaseMonoBehaviour
{
    protected static ExtendBoat instance;
    public static ExtendBoat Instance => instance;

    private SkeletonAnimation skeletonAnimation;
    protected Bone ropeBone;
    protected float initialY;
    protected float initialX;
    protected float targetY;
    protected float delayDuration = 3.25f;
    protected float changeDuration = 1f;
    [SerializeField] private float moveDistance = 10f;
    private bool audioPlayed = false;

    protected override void Awake()
    { 
        if (ExtendBoat.instance != null) return;
        ExtendBoat.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        AudioHurrah.Instance.HurrahAudioStop();
        AudioBackground.Instance.PlayAudioBackgroundStart();
        skeletonAnimation = GetComponent<SkeletonAnimation>();

        ropeBone = skeletonAnimation.Skeleton.FindBone("Day");

        if (ropeBone != null)
        {

            initialY = ropeBone.Y;
            initialX = ropeBone.X;

            targetY = initialY - moveDistance;

            StartCoroutine(DelayBeforeChange());
        }
       
    }

    protected override void Update()
    {
        base.Update();

        if (skeletonAnimation.gameObject.activeSelf == true)
        {
            ropeBone.Y = initialY;
            ropeBone.X = initialX;

        }
        if (InventoryManager.Instance.ListSize() == 0 && !audioPlayed)
        {
           
            audioPlayed = true; 
            StartCoroutine(PlayDelayEnd());
        }
        

    }

    private IEnumerator PlayDelayEnd()
    {
        AnimationEnd();
        yield return new WaitForSeconds(1.5f);
        AudioCongrats.Instance.CongratsAudioPlay();
        yield return new WaitForSeconds(2f);
        AudioCongrats.Instance.CongratsAudioStop();
        AudioHurrah.Instance.HurrahAudioPlay();
        yield return new WaitForSeconds(3f);
        AudioHurrah.Instance.HurrahAudioStop();
        PlayerMovement.Instance.MoveCharacterRight();
    }




    private  IEnumerator DelayBeforeChange()
    {
        yield return new WaitForSeconds(delayDuration);
        AudioBackground.Instance.PlayAudioBackgroundPlay();
        StartCoroutine(ChangeBoneLength());

    }


    private IEnumerator ChangeBoneLength()
    {
        float startTime = Time.time;
        float elapsedTime = 0f;
        Vector2 initialPosition = new Vector2(ropeBone.X, ropeBone.Y);
        Vector2 targetPosition = new Vector2(initialPosition.x + 2.7f, targetY);

        while (elapsedTime < changeDuration)
        {
            float t = elapsedTime / changeDuration;

            float newY = Mathf.Lerp(initialPosition.y, targetPosition.y, t);
            ropeBone.Y = newY;

            float newX = Mathf.Lerp(initialPosition.x, targetPosition.x, t);
            ropeBone.X = newX;

            elapsedTime = Time.time - startTime;
            yield return null;
        }

        ExtendHook.Instance.ShowHook();
    }
 
   

    public virtual void AnimationStart()
    {
        skeletonAnimation.AnimationState.SetAnimation(0, EnumHelper.GetDescription(StateBoat.Start), true);

    }
    public virtual void AnimationEnd( )
    {
        skeletonAnimation.AnimationState.SetAnimation(0, EnumHelper.GetDescription(StateBoat.End), false);
        
    }

    public virtual void AnimationHide()
    {
        skeletonAnimation.AnimationState.SetAnimation(0, EnumHelper.GetDescription(StateBoat.Disappear), false);
    }
}
