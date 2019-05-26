using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class EnterReadyGameSystem : ReactiveSystem<GameEntity>
{
    Contexts _contexts;
    public EnterReadyGameSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var ui = _contexts.game.CreateEntity();
        ui.AddAsset("UI",5);
        ui.isUI = true;

        _contexts.game.ReplaceGameState(GameState.Title);
    }

    protected override bool Filter(GameEntity entity)
    {
        return (entity.gameState.value == GameState.Ready);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameState);
    }
}
