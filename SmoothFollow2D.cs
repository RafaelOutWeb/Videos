using UnityEngine;
using System.Collections;

public class SmoothFollow2D : MonoBehaviour {

    public float dampTime = 0.3f; //offset from the viewport center to fix damping
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    public float m_XOffset, m_YOffset;


 void Update()
    {
        if (target)
        {
            Vector3 point = Camera.main.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta + new Vector3(m_XOffset, m_YOffset, 0);

            // Set this to the Y position you want the camera locked to
             destination.y = m_YOffset;

            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}
