using Assets.Scripts.Animations;
using Assets.Scripts.Untils;
using Spine.Unity;
using System.ComponentModel;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public enum StateHook
    {
        [Description("Moc gap do Open")]
        Open,

        [Description("Moc gap do Close")]
        Close,

        [Description("Moc gap do wating")]
        Waiting
    }

    public class HookAnimation : MonoBehaviour, IHookAnimation
{
        private SkeletonAnimation skeletonAnimation;
        private ObjectWaterAnimation _objectWaterAnimation;

        protected void Start()
        {
            skeletonAnimation = GetComponent<SkeletonAnimation>();
            _objectWaterAnimation = GetComponent<ObjectWaterAnimation>();

        }

        public void SetAnimation(StateHook newState,bool isLoop)
        {
            skeletonAnimation.AnimationState.SetAnimation(0, EnumHelper.GetDescription(newState), isLoop);
        }

        public void EnableAnimation()
        {
            _objectWaterAnimation.enabled = true;
        }

        public void DisableAnimation()
        {
            _objectWaterAnimation.enabled = false;
        }
    }
}
