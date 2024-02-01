﻿using AutoMapper;
using taskFelipe.Data.ValueObject;

namespace taskFelipe.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<TaskVO, Task>().ReverseMap();

            });
            return mappingConfig;
        }
    }
}
