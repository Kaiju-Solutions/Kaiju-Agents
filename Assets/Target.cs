using KaijuSolutions.Agents;
using UnityEngine;

public class Target : MonoBehaviour
{
    public KaijuAgent agent;
    
    public MoveType type = MoveType.None;

    public bool wander;
    
    private void Awake()
    {
        OnValidate();
        
        if (agent != null)
        {
            switch (type)
            {
                case MoveType.Seek:
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
                case MoveType.None:
                default:
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
        None,
        Seek,
        Pursue,
        Flee,
        Evade
    }
}