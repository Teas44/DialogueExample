using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public float speed = 0.25f;
    private Vector3 v3;
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            BMove(-1);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            BMove(1);
        }
    }

    void BMove(int i)
    {
        v3 = transform.position;
        v3.x = v3.x + (i * speed);
        transform.position = v3;
    }
}
