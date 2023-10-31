using Assets.Scripts.ScenceController.Backgrounds;
using Assets.Scripts.Untils;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public abstract class MarineOrganismMovement : MonoBehaviour
    {
        [SerializeField] protected float moveSpeed;
        protected Vector3 minBound;
        protected Vector3 maxBound;
        protected int directionX = 1;
        protected int directionY = 1;
        private bool boundsAssigned = false;

        void Start()
        {
            moveSpeed = RandomSpeed.GetRandomSpeed();

            if (transform.localScale.x < 0)
            {
                directionX = -1;
            }
            BackgroundPlay backgroundPlay = FindObjectOfType<BackgroundPlay>();
            if (backgroundPlay != null)
            {
                backgroundPlay.OnPlayStateChanged += HandlePlayStateChanged;
            }

        }
        private void Update()
        {
            if (boundsAssigned)
                Move();
            
        }

        void HandlePlayStateChanged()
        {
            StartCoroutine(DelayedBoundsAssignment());
        }

        private IEnumerator DelayedBoundsAssignment()
        {
            yield return new WaitForSeconds(0.95f);
            minBound = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
            maxBound = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
            boundsAssigned = true;
        }


        public abstract void Move();

      
        public abstract void FlipSpriteX();
       

        public void FlipSpriteY()
        {
            Vector3 localScale = transform.localScale;
            localScale.y *= -1;
            transform.localScale = localScale;
        }
       
    }
}
