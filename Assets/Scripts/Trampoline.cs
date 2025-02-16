using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float jumpForce;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rigidbody2D = collision.GetComponent<Rigidbody2D>();

        if(rigidbody2D!=null)
        {
            rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocity.x, 0);

            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
