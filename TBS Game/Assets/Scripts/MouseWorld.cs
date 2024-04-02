using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour {

    private LayerMask m_mouseWorldLayerMask;
    private static MouseWorld m_instance;

    private void Awake() {
        m_mouseWorldLayerMask = LayerMask.GetMask("MousePlane");
        SetFloorLayer();
        m_instance = this;
    }

    // Update is called once per frame
    void Update() {
        transform.position = GetPosition();
    }

    public static Vector3 GetPosition() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, m_instance.m_mouseWorldLayerMask);
        return hit.point;
    }

    private void SetFloorLayer() {
        GameObject floor = GameObject.Find("Floor");
        if (floor != null) {
            floor.layer = LayerMask.NameToLayer("MousePlane");
        } else {
            Debug.LogError("Floor object not found in the scene.");
        }
    }
}
