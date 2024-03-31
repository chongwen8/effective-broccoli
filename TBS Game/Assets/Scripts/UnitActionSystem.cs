using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (TryHandleUnitSelection()) {
                return;
            }
            if(m_selectedUnit) {
                m_selectedUnit.Move(MouseWorld.GetPosition());
            }
        }
    }

    private bool TryHandleUnitSelection() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, m_unitLayerMask)) {
            if(hit.transform.TryGetComponent<Unit>(out Unit unit)) {
                m_selectedUnit = unit;
                return true;
            }
        }
        return false;
    }

    [SerializeField] private Unit m_selectedUnit;
    [SerializeField] private LayerMask m_unitLayerMask;
}
