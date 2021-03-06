﻿/* ========================================================
 *	类名称：Services
 *	作 者：Zhangfan
 *	创建时间：2019-03-19 19:42:37
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Services
{
    public IInputService InputService;

    public IViewService ViewService;

    public CreatePlayerService CreatePlayerService;

    public Services(Contexts contexts)
    {
        InputService = new UnityInputService(contexts);

        ViewService = new UnityViewService(contexts);

        CreatePlayerService = new CreatePlayerService(contexts);
    }
}
