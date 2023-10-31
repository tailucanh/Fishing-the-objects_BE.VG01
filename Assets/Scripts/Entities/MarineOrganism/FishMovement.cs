using Assets.Scripts.Untils;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class FishMovement : MarineOrganismMovement
    {

 
        public override void Move()
        {
            Vector3 currentPosition = transform.position;

            currentPosition.x += moveSpeed * Time.deltaTime * directionX;

            if (currentPosition.x >= maxBound.x)
            {
                directionX = -1;
                currentPosition.x = maxBound.x;
                FlipSpriteX();
            }
            else if (currentPosition.x <= minBound.x)
            {
                directionX = 1;
                currentPosition.x = minBound.x;
                FlipSpriteX();
            }

            transform.position = currentPosition;
        }

        public override void FlipSpriteX()
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}