﻿using UnityEngine;
using System.Collections;
using Entitas;

public class PlayerUpdateSystem : IExecuteSystem
{
    Contexts _contexts;
    Services _services;
    IGroup<GameEntity> _players;
    Vector2 updir = new Vector2(0,1);
    Vector2 leftdir = new Vector2(1,0);
    public PlayerUpdateSystem(Contexts contexts, Services services)
    {
        _players = contexts.game.GetGroup(GameMatcher.Player);
        _contexts = contexts;
        _services = services;
    }
    public void Execute()
    {
        if(_contexts.game.gameState.value != GameState.Run)
        {
            return;
        }


        var startpos = _contexts.config.planeConfig.startPos;
        foreach (var p in _players)
        {
            if(p.playerState.state == PlayerState.Appear)
            {
                //Debug.Log("Appear");
                if (p.position.value.y >= startpos.y)
                {
                    p.ReplacePlayerState(PlayerState.Run);
                }
                else
                {
                    var speed = _contexts.config.planeConfig.speed;
                    p.ReplacePosition(
                p.position.value + updir*speed*Time.deltaTime
                    );
                }
            }
            else if(p.playerState.state == PlayerState.Run)
            {
                //Debug.Log("Run");

                var speed = _contexts.config.planeConfig.speed;
                var keydata = _services.InputService.KeyData;
                var offset = Vector2.zero;
                if (keydata.isPressed(InputData.KeyState.Up))
                {
                    offset += Time.deltaTime * updir * speed;
                }
                if (keydata.isPressed(InputData.KeyState.Left))
                {
                    offset -= Time.deltaTime * leftdir * speed;
                }
                if (keydata.isPressed(InputData.KeyState.Down))
                {
                    offset -= Time.deltaTime * updir * speed;
                }
                if (keydata.isPressed(InputData.KeyState.Right))
                {
                    offset += Time.deltaTime * leftdir * speed;
                }
                p.ReplacePosition(
                p.position.value + offset
                    );
            }
            if(p.hasView)
            {
                p.view.Value.Position = p.position.value;
            }

        }
    }
}