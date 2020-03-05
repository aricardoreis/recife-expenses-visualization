using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<ExpenseGroupedData, MonthlyExpenseViewModel>()
                .ForMember(dest => 
                    dest.Month,
                    opt => opt.MapFrom(src => src.Name));

            CreateMap<ExpenseGroupedData, CategorizedExpenseViewModel>()
                .ForMember(dest =>
                    dest.CategoryName,
                    opt => opt.MapFrom(src => src.Name));

            CreateMap<ExpenseGroupedData, SourceExpenseViewModel>()
                .ForMember(dest =>
                    dest.SourceName,
                    opt => opt.MapFrom(src => src.Name));
        }
    }
}
