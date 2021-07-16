// ******************************************************************
//       /\ /|       @file       DebugActionsPawnExtension.cs
//       \ V/        @brief      角色测试扩展
//       | "")       @author     Shadowrabbit, yingtu0401@gmail.com
//       /  |                    
//      /  \\        @Modified   2021-06-11 08:01:53
//    *(__\_\        @Copyright  Copyright (c) 2021, Shadowrabbit
// ******************************************************************

using System.Collections.Generic;
using JetBrains.Annotations;
using Verse;

namespace SR.ToolRimWorld.SetRot
{
    [UsedImplicitly]
    public class DebugActionsPawnExtension
    {
        /// <summary>
        /// 测试 改变地图上所有角色朝向
        /// </summary>
        [UsedImplicitly]
        [DebugAction("SR.ToolRimWorld.SetRot", "Change all rotations of pawns in map",
            allowedGameStates = AllowedGameStates.PlayingOnMap)]
        private static void IssueDecree()
        {
            var debugMenuOptionList = new List<DebugMenuOption>();
            var debugMenuOptionEast = new DebugMenuOption("East", DebugMenuOptionMode.Tool,
                () => { SetRotOfPawnsInMap(Rot4.East); });
            var debugMenuOptionSouth = new DebugMenuOption("South", DebugMenuOptionMode.Tool,
                () => { SetRotOfPawnsInMap(Rot4.South); });
            var debugMenuOptionWest = new DebugMenuOption("West", DebugMenuOptionMode.Tool,
                () => { SetRotOfPawnsInMap(Rot4.West); });
            var debugMenuOptionNorth = new DebugMenuOption("North", DebugMenuOptionMode.Tool,
                () => { SetRotOfPawnsInMap(Rot4.North); });
            debugMenuOptionList.Add(debugMenuOptionEast);
            debugMenuOptionList.Add(debugMenuOptionSouth);
            debugMenuOptionList.Add(debugMenuOptionWest);
            debugMenuOptionList.Add(debugMenuOptionNorth);
            Find.WindowStack.Add(new Dialog_DebugOptionListLister(debugMenuOptionList));
        }

        /// <summary>
        /// 设置地图上所有角色的旋转 并暂停游戏
        /// </summary>
        /// <param name="rot4"></param>
        private static void SetRotOfPawnsInMap(Rot4 rot4)
        {
            var map = Find.CurrentMap;
            foreach (var pawn in map.mapPawns.AllPawnsSpawned)
            {
                pawn.Rotation = rot4;
            }

            Find.TickManager.CurTimeSpeed = TimeSpeed.Paused;
        }
    }
}