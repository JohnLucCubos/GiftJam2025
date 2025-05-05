using UnityEngine;

public class StarAlternation : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float amplitude = 1f;
    [SerializeField] Vector2 offset;
    [SerializeField] float rotationSpeed = 50f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, Mathf.Sin(Time.time * .01f));
    }
}
