using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class EventListener : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Action<PointerEventData> onClickHandler = null;//点击事件
    private Action<PointerEventData> onBeginDargHandler = null;//开始拖拽
    private Action<PointerEventData> onDargHandler = null;//拖拽中
    private Action<PointerEventData> onEndDargHandler = null;//停止拖拽

    private bool usingAnim = false;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (onBeginDargHandler != null)
        {
            onBeginDargHandler.Invoke(eventData);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (onDargHandler != null)
        {
            onDargHandler.Invoke(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (onEndDargHandler != null)
        {
            onEndDargHandler.Invoke(eventData);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        doAnim();
        if (onClickHandler != null)
        {
            onClickHandler.Invoke(eventData);
        }
    }

    public void setClickHandler(Action<PointerEventData> handler)
    {
        onClickHandler = handler;
    }
    public void setBeginDragHandler(Action<PointerEventData> handler)
    {
        onBeginDargHandler = handler;
    }
    public void setDragHandler(Action<PointerEventData> handler)
    {
        onDargHandler = handler;
    }
    public void setEndDragHandler(Action<PointerEventData> handler)
    {
        onEndDargHandler = handler;
    }
    public void setUseAnim(bool isUse)
    {
        this.usingAnim = isUse;
    }
    private void doAnim()
    {
        if (this.usingAnim)
        {
            this.gameObject.transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.15f).OnComplete(() =>
            {
                this.gameObject.transform.DOScale(Vector3.one, 0.1f);
            });
        }
    }
}

