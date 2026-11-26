using KaijuSolutions.Agents.Graphs;
using UnityEngine;

namespace KaijuSolutions.Agents.Exercises.CTF
{
    [RequireComponent(typeof(Trooper))]
    public sealed class TrooperGraphServices : MonoBehaviour, IGraphServiceProvider
    {
        public void Register(GraphServices services)
        {
            var trooper = GetComponent<Trooper>();
            services.Predicates.Add("trooper.has-flag", _ => trooper.HasFlag);
            services.Predicates.Add("trooper.can-attack", _ => trooper.CanAttack);
            services.Scorers.Add("trooper.health", _ => trooper.Health);
            services.RegisterAction("trooper.observe", context =>
            {
                context.Set("health", GraphValue.From(trooper.Health));
                context.Set("ammo", GraphValue.From(trooper.Ammo));
                context.Set("carrying", GraphValue.From(trooper.HasFlag));
            });
        }
    }
}
