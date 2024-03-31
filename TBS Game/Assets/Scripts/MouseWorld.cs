using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake() {
        instance = this;
    }

    // Update is called once per frame
    void Update() {
        transform.position = GetPosition();
    }

    public static Vector3 GetPosition() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, instance.m_mouseWorldLayerMask);
        return hit.point;
    }
    [SerializeField] private LayerMask m_mouseWorldLayerMask;
    private static MouseWorld instance;
}
