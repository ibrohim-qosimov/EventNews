using EventNews.API.DTOs;
using EventNews.API.Models.Entities;
using EventNews.API.Models.Languages;
using System.Collections.Generic;

namespace EventNews.API.Converters
{
    public static class RegionConverter
    {
        public static RegionModel ToModel(this Region entity, List<RegionModel>? children = null) => new RegionModel
        {
            Id = entity.Id,
            Title = entity.GetTitleByLanguage("uz"),
            Children = children
        };

        public static Region ToEntity(this CreateRegionDTO dto) => new Region
        {
            TitleUz = dto.TitleUz,
            TitleRu = dto.TitleRu,
            TitleEn = dto.TitleEn,
            TitleCrlyc = dto.TitleCrlyc,
            ParentId = dto.ParentId
        };
    }
}
