using KaijuSolutions.Agents.Graphs;
using UnityEngine;

namespace KaijuSolutions.Agents.Exercises.Microbes
{
    [RequireComponent(typeof(Microbe))]
    public sealed class MicrobeGraphServices : MonoBehaviour, IGraphServiceProvider
    {
        public void Register(GraphServices services)
        {
            var microbe = GetComponent<Microbe>();
            services.Scorers.Add("microbe.energy", _ => microbe.Energy);
            services.Predicates.Add("microbe.cooling", _ => microbe.OnCooldown);
            services.RegisterAction("microbe.observe", context =>
            {
                context.Set("energy", GraphValue.From(microbe.Energy));
                context.Set("cooldown", GraphValue.From(microbe.Cooldown));
            });
        }
    }
}
