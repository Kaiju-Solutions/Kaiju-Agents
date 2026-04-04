# Utility

Kaiju Agents provides you with the ability to visually create utility AI and is based on a [sample by git-amend](https://youtu.be/S4oyqrsU2WU "git-Amend - Utility AI: Mastering Smart Decisions in Unity!").

## Overview

1. Create a class which extends from [`KaijuUtilityBrain`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Utility.KaijuUtilityBrain.html "KaijuUtilityBrain") and attach it to your agent.
2. Override the [`KaijuUtilityBrain.UpdateBlackboard()` method](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Utility.KaijuUtilityBrain.html#KaijuSolutions_Agents_Utility_KaijuUtilityBrain_UpdateBlackboard "KaijuUtilityBrain.UpdateBlackboard()"), and use the set methods to assign blackboard variables.
3. Create actions by extending [`KaijuUtilityAction`](https://agents.kaijusolutions.ca/api/KaijuSolutions.Agents.Utility.KaijuUtilityAction.html "KaijuUtilityAction").
4. Create instances of the new actions.
5. Create and configure considerations by right-clicking in the project and going to `Kaiju Solutions > Agents > Utility > Considerations`.
6. Assign considerations to their actions.
7. Assign actions to the created brain.
8. When playing, the utility scores of all actions can be seen in the inspector of the brain.