using Assets.Scripts.Audios;
using Assets.Scripts.ScenceController;
using Assets.Scripts.Untils;
using Spine;
using Spine.Unity;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class BoneHookMovement : MonoBehaviour, IMoveBoneHook
    {

        [SerializeField] private float moveDistance = 12f;
        private SkeletonAnimation skeletonAnimation;
        protected Bone hookBone;
        protected float initialY;
        protected float initialX;
        protected float targetY;
        protected float delayDuration = 1f;
        protected float changeDuration = 1f;
        private SceneController _sceneController;
        private IHookObject _hookObject;

        protected void Awake()
        {
            _sceneController = FindObjectOfType<SceneController>();
            skeletonAnimation = GetComponent<SkeletonAnimation>();
            _hookObject = transform.parent.GetComponentInChildren<IHookObject>();
            hookBone = skeletonAnimation.Skeleton.FindBone(EnumHelper.GetDescription(StateBoat.Rope));
        }

        public void MoveBone()
        {
            if (hookBone != null)
            {
                initialY = hookBone.Y;
                initialX = hookBone.X;

                targetY = initialY - moveDistance;
                StartCoroutine(DelayBeforeChange());
            }
        }


        public void ResetBone()
        {
            hookBone.Y = initialY;
            hookBone.X = initialX;
        }


        private IEnumerator DelayBeforeChange()
        {
            yield return new WaitForSeconds(delayDuration);
            _sceneController.ChangeState(GameState.Play);
            yield return StartCoroutine(CoroutineMoveBone());
            ResetBone();
            _hookObject.Show();
            AudioGuiding.Instance.Play();
        }

        private IEnumerator CoroutineMoveBone()
        {
            float startTime = Time.time;
            float elapsedTime = 0f;
            Vector2 initialPosition = new Vector2(hookBone.X, hookBone.Y);
            Vector2 targetPosition = new Vector2(initialPosition.x + 2.7f, targetY);

            while (elapsedTime < changeDuration)
            {
                float t = elapsedTime / changeDuration;

                float newY = Mathf.Lerp(initialPosition.y, targetPosition.y, t);
                hookBone.Y = newY;

                float newX = Mathf.Lerp(initialPosition.x, targetPosition.x, t);
                hookBone.X = newX;

                elapsedTime = Time.time - startTime;
                yield return null;
            }
          
        }

      
    }
}
