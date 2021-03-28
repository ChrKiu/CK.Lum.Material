using AutoMapper;
using CK.Lum.Material.Data.RavenDb.Models;
using CK.Lum.Material.Domain.Models.MaterialAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MaterialModel = CK.Lum.Material.Domain.Models.MaterialAggregate.Material;

namespace CK.Lum.Material.Data.Mapping
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<MaterialModel, MaterialDbo>()
                .ForMember(dest => dest.Id, o => o.MapFrom(source => source.Id))
                .ForMember(dest => dest.IsVisible, o => o.MapFrom(source => source.IsVisible))
                .ForMember(dest => dest.Name, o => o.MapFrom(source => source.Name))
                .ForMember(dest => dest.TypeOfPhase, o => o.MapFrom(source => source.TypeOfPhase))
                .ForMember(dest => dest.MaterialFunction, o => o.MapFrom(source => source.MaterialFunction))
                .ReverseMap()
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<MaterialFunction, MaterialFunctionDbo>()
                .ForMember(dest => dest.MaxTemperature, o => o.MapFrom(source => source.MaxTemperature))
                .ForMember(dest => dest.MinTemperature, o => o.MapFrom(source => source.MinTemperature))
                .ReverseMap()
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}
