using UnityEngine;
using UnityEngine.UI;

public class CameraSliderRotate : MonoBehaviour
{
    public Transform target;
    public Slider slider;
    public float distance = 5f;
    public float height = 2f;

    void Update()
    {
        float angle = slider.value * 360f + 180f;
        float rad = angle * Mathf.Deg2Rad;

        Vector3 offset = new Vector3(
            Mathf.Sin(rad) * distance,
            height,
            Mathf.Cos(rad) * distance
        );

        transform.position = target.position + offset;
        transform.LookAt(target);
    }
}
