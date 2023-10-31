using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class CloudMovement : MonoBehaviour
    {
        protected float speed;
        protected float endPosX;

        protected void Update()
        {
            MovingCloud();

        }
        protected virtual void MovingCloud()
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x > endPosX)
            {
                Destroy(gameObject);
            }
        }

        public virtual void StartFloating(float speed, float endPosX)
        {
            this.endPosX = endPosX;
            this.speed = speed;
        }


    }
}