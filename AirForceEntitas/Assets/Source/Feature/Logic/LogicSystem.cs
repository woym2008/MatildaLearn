using UnityEngine;
using System.Collections;
using Entitas;

public class LogicSystem : Feature
{
    public LogicSystem(Contexts contexts, Services services)
    {
        Add(new EnterReadyGameSystem(contexts));
        Add(new TitleGameSystem(contexts, services));
        Add(new EnterRunGameSystem(contexts));

        Add(new CreatePlayerSystem(contexts, services));
        Add(new PlayerUpdateSystem(contexts, services));

        Add(new EnemyCreateSystem(contexts, services));
        Add(new EnemyUpdateSystem(contexts));
    }
}
