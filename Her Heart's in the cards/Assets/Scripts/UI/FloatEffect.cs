using UnityEngine;

public class FloatEffect : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // Move the object up and down
        float newY = Mathf.Sin(Time.time * 5f);
        transform.position = new Vector3(transform.position.x, transform.position.y + newY, 0f);
    }
}
