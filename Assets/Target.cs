using KaijuSolutions.Agents;
using UnityEngine;

public class Target : MonoBehaviour
{
    public KaijuAgent agent;
    
    public MoveType type = 0;

    public bool wander;
    
    private void Awake()
    {
        OnValidate();
        
        if (agent != null)
        {
            switch (type)
            {
                case MoveType.Seek:
                default:
                    agent.Seek(this, clear: false);
                    break;
                case MoveType.Pursue:
                    agent.Pursue(this, clear: false);
                    break;
                case MoveType.Flee:
                    agent.Flee(this, clear: false);
                    break;
                case MoveType.Evade:
                    agent.Evade(this, clear: false);
                    break;
            }
            
            if (wander)
            {
                agent.Wander(clear: false);
            }
        }
        
        Destroy(this);
    }
    
    private void OnValidate()
    {
        if (agent == null)
        {
            agent = FindAnyObjectByType<KaijuAgent>();
        }
    }
    
    public enum MoveType
    {
        Seek,
        Pursue,
        Flee,
        Evade
    }
}