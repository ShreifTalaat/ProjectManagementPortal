using AutoMapper;
using BLL.ModelViews;
using DAL.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics.Contracts;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.Mapping
{
    public class MappingClass : Profile
    {

        public MappingClass()
        {
            CreateMap<DAL.Models.User, BLL.ModelViews.UserMV>()
.ReverseMap();
            CreateMap<DAL.Models.Task, BLL.ModelViews.TaskMV>().ReverseMap();
            CreateMap<DAL.Models.Project, BLL.ModelViews.ProjectMV>()
  
       .ReverseMap();


        }
    }
}
