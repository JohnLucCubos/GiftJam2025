using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    [SerializeField] Vector2 offset;
    [SerializeField] float speed = 1f;
    [SerializeField] float amplitude = 1f;
    void Start()
    {
        offset = this.transform.position;
    }

    void Update()
    {
        this.transform.position = new Vector3()
        {
            x = offset.x + Mathf.Sin(Time.time * speed) * amplitude,
            y = offset.y + Mathf.Cos(Time.time * speed * amplitude) / 2f,
            z = 0f
        };
    }
}
