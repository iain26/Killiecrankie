using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool lastBool = false;
    public bool buttonPressed = false;

    public SoldierLeaping soldier;

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }

    private void Update()
    {
       if(buttonPressed != lastBool)
        {
            lastBool = buttonPressed;
            if (gameObject.name == "CrouchButton")
            {
                soldier.Crouch();
            }
            if(gameObject.name == "JumpButton")
            {
                soldier.Jump();
            }
        }
    }
}
