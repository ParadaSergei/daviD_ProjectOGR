using UnityEngine;

public class Ladder : MonoBehaviour
{
    public float speed = 5f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
        other.transform.GetComponent<Rigidbody2D>().gravityScale = 0;
            if (Input.GetKey(KeyCode.W))
            {
                other.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                other.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            }
            else
            {
                other.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
