using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEventWidget : MonoBehaviour {

    protected CEntity agent = null;
    protected CEntity Agent {
        get {
            if (agent == null) {
                agent = this.GetComponentInParent<CEntity>();
            }
            return agent;
        }
    }


    public virtual void playEffect(string args) {
        if (Agent != null) {
            Agent.playEffect(args);
        }
    }


    public virtual void playAudio(string args)
    {
        if (Agent != null)
        {
            Agent.playAudio(args);
        }
    }

    public virtual void playHit(string args)
    {
        if (Agent != null)
        {
            Agent.playHit(args);
        }
    }

}
