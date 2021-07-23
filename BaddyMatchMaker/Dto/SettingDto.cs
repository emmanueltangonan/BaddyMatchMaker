using BaddyMatchMaker.Models;
using System;

namespace BaddyMatchMaker.Dto
{
    public class SettingDto
    {
        public int? MatchDuration { get; set; }

        public bool? IgnoreSex { get; set; }

        public static SettingDto FromModel(Setting model)
        {
            if (model == null)
            {
                return null;
            }

            return new SettingDto()
            {
                MatchDuration = model.MatchDuration, 
                IgnoreSex = model.IgnoreSex, 
            }; 
        }

        public Setting ToModel()
        {
            return new Setting()
            {
                MatchDuration = MatchDuration, 
                IgnoreSex = IgnoreSex, 
            }; 
        }
    }
}