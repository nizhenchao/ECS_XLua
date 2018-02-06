using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventListener : MonoBehaviour, IPointerClickHandler
{
    private Action onClickHandler = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (onClickHandler != null)
        {
            onClickHandler.Invoke();
        }
    }

    public void setClickHandler(Action handler)
    {
        onClickHandler = handler;
    }
}

