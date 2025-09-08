using UnityEngine;

public class Legs : MonoBehaviour
{
    public bool IsGrounded {  get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<EntityMovement>() == null)
        {
            IsGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<EntityMovement>() == null)
        {
            IsGrounded = false;
        }
    }
}
