using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectedVisual : MonoBehaviour
{

    [SerializeField]private Unit m_unit;

    private MeshRenderer m_meshRenderer;

    void Awake() {
        m_unit = GetComponentInParent<Unit>();

        m_meshRenderer = GetComponent<MeshRenderer>();
    }

    void Start() {
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;

        UpdateVisual();
    }

    private void UnitActionSystem_OnSelectedUnitChanged(object sender, EventArgs empty) {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        if (UnitActionSystem.Instance.GetSelectedUnit() == m_unit) {
            m_meshRenderer.enabled = true;
        } else {
            m_meshRenderer.enabled = false;
        }
    }

}