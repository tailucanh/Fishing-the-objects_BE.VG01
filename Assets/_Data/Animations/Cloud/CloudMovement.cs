using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloudMovement : BaseMonoBehaviour
{
   protected float speed;
   protected float endPosX;

   protected override void Update()
   {
      this.MovingCloud();

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
