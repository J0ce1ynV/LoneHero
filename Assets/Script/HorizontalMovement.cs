using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    static float t = 0;
    public float distance;
    public float speed;
    private float originalPos;

    void Start()
    {
        originalPos = transform.position.x;
    }

    void Update()
    {
        MovementHor();
    }

    private void MovementHor()
    {
        t += Time.deltaTime * speed;
        var x = originalPos + Mathf.Sin(t) * distance;
        transform.position = new Vector2(x, transform.position.y); 
    }
}
