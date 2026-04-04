using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace KaijuSolutions.Agents.Utility
{
    /// <summary>
    /// <see cref="KaijuUtilityConsideration"/> which evaluates multiple sub-considerations.
    /// </summary>
#if UNITY_EDITOR
    [Icon("Packages/ca.kaijusolutions.agents/Editor/Icon.png")]
    [HelpURL("https://agents.kaijusolutions.ca/manual/utility-ai.html")]
    [CreateAssetMenu(menuName = "Kaiju Solutions/Agents/Utility/Composite", fileName = "Composite", order = 5)]
#endif
    public class KaijuUtilityCompositeConsideration : KaijuUtilityConsideration
    {
        /// <summary>
        /// How to combine the <see cref="considerations"/>.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("How to combine the considerations.\n" +
                 "Average - Take the average of all considerations after their evaluation is complete.\n" +
                 "Add - Add all considerations in order, stopping early if the total at any point reaches one.\n" +
                 "Subtract - Subtract all considerations in order using the first consideration as the initial value all others subtract from, stopping early if the total at any point reaches zero.\n" +
                 "Multiply - Multiply all considerations in order, stopping early if at any point the product is zero.\n" +
                 "Divide - Take the maximum consideration value, stopping early if a value of one is reached.\n" +
                 "Max - Take the maximum consideration value, stopping early if a value of one is reached.\n" +
                 "Min - Take the minimum consideration value, stopping early if a value of zero is reached.")]
#endif
        public OperationType operation = OperationType.Multiply;
        
        /// <summary>
        /// The considerations to evaluate.
        /// </summary>
#if UNITY_EDITOR
        [Tooltip("The considerations to evaluate.")]
#endif
        public List<KaijuUtilityConsideration> considerations;
        
        /// <summary>
        /// Get the utility for this consideration from [0, 1].
        /// </summary>
        /// <param name="brain">The <see cref="KaijuUtilityBrain"/> this is considering for.</param>
        /// <returns>The utility score for this consideration from [0, 1].</returns>
        public override float Evaluate([NotNull] KaijuUtilityBrain brain)
        {
            // Nothing to do if no considerations.
            if (considerations == null || considerations.Count < 1)
            {
                return 0f;
            }
            
            // Run the first evaluation.
            float result = considerations[0].Evaluate(brain);
            
            // See if there are early stopping conditions.
            switch (result)
            {
                // If it is zero, and it is a type that will now remain zero regardless of other values, stop early.
                case <= 0f when operation is OperationType.Multiply or OperationType.Divide or OperationType.Min or OperationType.Subtract:
                    return 0f;
                // If it is one, and it is a type that is looking for or summing up values, stop early as this would otherwise clamp to one.
                case >= 1f when operation is OperationType.Max or OperationType.Add:
                    return 1f;
            }
            
            // Loop through all other operations.
            for (int i = 1; i < considerations.Count; i++)
            {
                // Evaluate this consideration.
                float value = considerations[i].Evaluate(brain);
                
                // Perform the operation.
                switch (operation)
                {
                    // Average.
                    case OperationType.Average:
                        result += value;
                        break;
                        
                    // Subtract.
                    case OperationType.Subtract:
                        result -= value;
                        break;
                    
                    // Multiply.
                    case OperationType.Multiply:
                        // If this is zero, there is nothing else to do as all future operations will result in zero.
                        if (value <= 0f)
                        {
                            return 0f;
                        }
                        
                        result *= value;
                        break;
                    
                    // Divide.
                    case OperationType.Divide:
                        // Ensure no division by zero.
                        if (value != 0f)
                        {
                            result /= value;
                        }
                        
                        break;
                    
                    // Max.
                    case OperationType.Max:
                        // If this is the maximum value, then stop early.
                        if (value >= 1f)
                        {
                            return 1f;
                        }
                        
                        if (value > result)
                        {
                            result = value;
                        }
                        
                        break;
                    
                    // Min.
                    case OperationType.Min:
                        // If this is the minimum value, then stop early.
                        if (value <= 0f)
                        {
                            return 0f;
                        }
                        
                        if (value < result)
                        {
                            result = value;
                        }
                        
                        break;
                    
                    // Add.
                    case OperationType.Add:
                    default:
                        result += value;
                        
                        // If we have hit the maximum value, stop early.
                        if (result >= 1f)
                        {
                            return 1f;
                        }
                        
                        break;
                }
            }
            
            // Average if needed and then clamp.
            return Mathf.Clamp01(operation == OperationType.Average ? result / considerations.Count : result);
        }
        
        /// <summary>
        /// The types of operations we can perform.
        /// </summary>
        public enum OperationType
        {
            /// <summary>
            /// Take the average of all considerations after their evaluation is complete.
            /// </summary>
            Average,
            
            /// <summary>
            /// Add all considerations in order, stopping early if the total at any point reaches one.
            /// </summary>
            Add,
            
            /// <summary>
            /// Subtract all considerations in order using the first consideration as the initial value all others subtract from, stopping early if the total at any point reaches zero.
            /// </summary>
            Subtract,
            
            /// <summary>
            /// Multiply all considerations in order, stopping early if at any point the product is zero.
            /// </summary>
            Multiply,
            
            /// <summary>
            /// Divide all considerations in order using the first consideration as the initial value tall others divide against.
            /// </summary>
            Divide,
            
            /// <summary>
            /// Take the maximum consideration value, stopping early if a value of one is reached.
            /// </summary>
            Max,
            
            /// <summary>
            /// Take the minimum consideration value, stopping early if a value of zero is reached.
            /// </summary>
            Min
        }
    }
}