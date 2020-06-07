using ETModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseComponent : MonoBehaviour
{

    public Unit unit;
    // Start is called before the first frame update
    void Awake()
    {
        //unit = gameObject.
         
    }

    private void OnMouseEnter()
    {
        UserInputComponent.Instance.SelectUnit = unit;
    }
    private void OnMouseExit()
    {
        UserInputComponent.Instance.SelectUnit = null;
    }
}
