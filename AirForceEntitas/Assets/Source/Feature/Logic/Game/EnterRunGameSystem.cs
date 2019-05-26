using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class EnterRunGameSystem : ReactiveSystem<GameEntity>
{
    Contexts _contexts;
    public EnterRunGameSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        _contexts.game.ReplacePlayerData(3);

        _contexts.game.ReplacePlayerBorn(true);
    }

    protected override bool Filter(GameEntity entity)
    {
        return (entity.gameState.value == GameState.Run);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameState);
    }
}

