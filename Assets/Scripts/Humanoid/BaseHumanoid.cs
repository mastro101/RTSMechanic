using UnityEngine;
using System.Collections;

public class BaseHumanoid : MonoBehaviour, ISelectable
{
    Renderer renderer;

    bool selected;
    public bool Selected
    {
        get { return selected; }
        set
        {
            selected = value;
            if (selected)
                renderer.material.color = Color.green;
            if (!selected)
                renderer.material.color = Color.white;
        }
    }

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        Selected = false;
    }

    private void OnMouseDown()
    {
        if (!Selected)
            UnitManager.pointer.SelectObject(this);
    }
}
