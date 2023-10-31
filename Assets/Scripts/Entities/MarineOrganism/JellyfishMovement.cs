using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class JellyfishMovement : MarineOrganismMovement
    {
        Vector3 currentPosition;


        public override void Move()
        {
            currentPosition = transform.position;
            currentPosition.x += moveSpeed * Time.deltaTime * directionX;
            currentPosition.y += moveSpeed * Time.deltaTime * directionY;

            if (currentPosition.x >= maxBound.x || currentPosition.x <= minBound.x)
            {
                FlipSpriteX();
                currentPosition.x = Mathf.Clamp(currentPosition.x, minBound.x, maxBound.x);
            }

            if (currentPosition.y >= maxBound.y || currentPosition.y <= minBound.y)
            {
                directionY *= -1;
                currentPosition.y = Mathf.Clamp(currentPosition.y, minBound.y, maxBound.y);
                FlipSpriteY();
            }

            transform.position = currentPosition;
        }
        public override void FlipSpriteX()
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
            directionX *= -1;
        }
    }
}