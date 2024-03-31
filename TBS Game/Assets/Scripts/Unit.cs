using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    void Awake() {
        m_targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, m_targetPosition) > 0.1f) {
            Vector3 moveDirection = (m_targetPosition - transform.position).normalized;
            transform.position += m_speed * Time.deltaTime * moveDirection;

            float rotateSpeed = 5.0f;
            transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
        }
    }

    public void Move(Vector3 targetPosition) {
        // make the cube on the plane
        m_targetPosition = targetPosition + Vector3.up * 0.5f;
    }

    private Vector3 m_targetPosition;
    [SerializeField]private float m_speed = 5.0f;
}
