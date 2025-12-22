using KaijuSolutions.Agents;
using UnityEngine;

public class Target : MonoBehaviour
{
    public KaijuAgent agent;
    
    public MoveType type = 0;
    
    private void Awake()
    {
        OnValidate();
        
        if (agent != null)
        {
            switch (type)
            {
                case MoveType.Seek:
                default:
                    agent.Seek(this);
                    break;
                case MoveType.Pursue:
                    agent.Pursue(this);
                    break;
                case MoveType.Flee:
                    agent.Flee(this);
                    break;
                case MoveType.Evade:
                    agent.Evade(this);
                    break;
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