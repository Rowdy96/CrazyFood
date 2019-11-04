using AutoMapper;
using CrazyFood.DomainModel.Models;
using CrazyFood.Repository.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyFood.Repository.AutoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Users, UserAC>()
                .ForMember(
                dest => dest.Id, opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                dest => dest.Name, opt => opt.MapFrom(src => src.Name)
                )
                .ForMember(
                dest => dest.Phone, opt => opt.MapFrom(src => src.PhoneNumber)
                )
                .ForMember(
                dest => dest.Email, opt => opt.MapFrom(src => src.Email)
                )
                .ForMember(
                dest => dest.Address, opt => opt.MapFrom(src => src.Address)
                );
            
            CreateMap<Follow, FollowAC>();
            CreateMap<FollowAC, Follow>();
        }
    }
}
