using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager pointer;

    List<List<ISelectable>> units;

    List<ISelectable> selectedObject;

    List<KeyCode> NumberKey;

    private void Awake()
    {
        if (pointer == null)
            pointer = this;
        units = new List<List<ISelectable>>();

        selectedObject = new List<ISelectable>();

        NumberKey = new List<KeyCode>
        {
            KeyCode.Alpha0,
            KeyCode.Alpha1,
            KeyCode.Alpha2,
            KeyCode.Alpha3,
            KeyCode.Alpha4,
            KeyCode.Alpha5,
            KeyCode.Alpha6,
            KeyCode.Alpha7,
            KeyCode.Alpha8,
            KeyCode.Alpha9,
        };

        for (int i = 0; i < NumberKey.Count; i++)
        {
            units.Add(new List<ISelectable>());
            units[i] = new List<ISelectable>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            DeselectAll();

        int i = 0;
        foreach (KeyCode key in NumberKey)
        {
            if (Input.GetKeyDown(key) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
            {
                if (selectedObject.Count > 0)
                {
                    units[i] = new List<ISelectable>();
                    units[i].AddRange(selectedObject);
                }
            }
            else if (Input.GetKeyDown(key) && units[i].Count > 0)
            {
                foreach (ISelectable selectable in units[i])
                {
                    SelectObject(selectable);
                }
            }
            i++;
        }
    }

    #region API

    public void SelectObject(ISelectable selectable)
    {
        selectable.Selected = true;
        selectedObject.Add(selectable);
        Debug.Log(selectable + "Selezionato");
    }

    public void DeselectAll()
    {
        foreach (ISelectable selectable in selectedObject)
        {
            selectable.Selected = false;
        }

        selectedObject = new List<ISelectable>();
    }

    #endregion
}
