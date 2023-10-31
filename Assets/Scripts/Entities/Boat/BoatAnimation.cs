using Assets.Scripts.Untils;
using Spine.Unity;
using System.ComponentModel;
using UnityEngine;



namespace Assets.Scripts.Entities
{
    public enum StateBoat
    {
        [Description("Starting")]
        Start,

        [Description("Ending")]
        End,

        [Description("Bien mat")]
        Disappear,

        [Description("Day")]
        Rope,

        [Description("Item Mu")]
        Item
    }

    public class BoatAnimation : MonoBehaviour, IAnimationBoat
{
        private SkeletonAnimation skeletonAnimation;

        protected void Start()
        {
            skeletonAnimation = GetComponent<SkeletonAnimation>();
        }

        public void SetAnimation(StateBoat newSate, bool isLoop)
        {
            skeletonAnimation.AnimationState.SetAnimation(0, EnumHelper.GetDescription(newSate), isLoop);
        }

       
    }
}
