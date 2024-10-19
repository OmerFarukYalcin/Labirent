using UnityEngine;

public class BallCollision : MonoBehaviour
{
    // Reference to the BallHealth component.
    private BallHealt ballHealt;

    // Damage value to apply when hitting a wall.
    private int _damage = 1;

    private void Start()
    {
        // Cache the BallHealt component attached to this GameObject.
        ballHealt = GetComponent<BallHealt>();
    }

    private void OnCollisionEnter(Collision cls)
    {
        // If the object collided with is named "finish", proceed to the next level.
        if (cls.gameObject.name.Equals("finish"))
        {
            GameManager.instance.NextLevel();
        }

        // If the object has the "Wall" tag, apply damage to the ball.
        if (cls.gameObject.CompareTag("Wall"))
        {
            ballHealt.TakeDamage(_damage);
        }

        // If the object collided with is named "gameStep", trigger the game step logic.
        if (cls.gameObject.name.Equals("gameStep"))
        {
            GameManager.instance.GameStepCollided();
        }
    }
}
