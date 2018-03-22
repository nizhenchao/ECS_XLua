using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用于动画帧事件与Lua交互
/// </summary>
public class CEntity : MonoBehaviour
{
    private long uid;
    public long UID
    {
        get
        {
            return this.uid;
        }
        set
        {
            this.uid = value;
        }
    }

    private Action<string> playAudioEvent = null;
    private Action<string> playEffectEvent = null;
    private Action<string> playHitEvent = null;

    /// <summary>
    /// 由Lua调用
    /// </summary>
    /// <param name="foo"></param>
    public void setPlayAudioEvent(Action<string> foo)
    {
        playAudioEvent = foo;
    }
    public void setPlayEffectEvent(Action<string> foo)
    {
        playEffectEvent = foo;
    }
    public void setPlayHitEvent(Action<string> foo)
    {
        playHitEvent = foo;
    }

    /// <summary>
    /// 由animeventwidget调用
    /// </summary>
    public virtual void playAudio(string args)
    {
        if (playAudioEvent != null)
        {
            playAudioEvent(args);
        }
    }

    public virtual void playEffect(string args)
    {
        if (playEffectEvent != null)
        {
            playEffectEvent(args);
        }
    }

    public virtual void playHit(string args)
    {
        if (playHitEvent != null)
        {
            playHitEvent(args);
        }
    }


    public void OnDestroy()
    {
        playAudioEvent = null;
        playEffectEvent = null;
        playHitEvent = null;
    }

}

