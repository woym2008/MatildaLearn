using UnityEngine;
using System.Collections;
using Entitas;

public class TitleGameSystem : IExecuteSystem
{
    Contexts _contexts;
    Services _services;
    public TitleGameSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;
        _services = services;
    }   
    public void Execute()
    {
        var curState = _contexts.game.gameState.value;
        if(curState == GameState.Title)
        {
            var keydata = _services.InputService.KeyData;
            if(keydata.isPressed(InputData.KeyState.Enter))
            {
                _contexts.game.ReplaceGameState(GameState.Run);
                var uis = _contexts.game.GetEntities<GameEntity>(GameMatcher.UI);
                foreach(var ui in uis)
                {
                    ui.isDestroyed = true;
                }
            }
        }
    }
}
