using AutoMapper;
using MyFoodLog.Models.FoodItem;
using MyFoodLog.Database.Models;

namespace MyFoodLog.Core.AutoMapper;

public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<FoodItem, FoodItemDto>();
        CreateMap<CreateFoodItemDto, FoodItem>();
    }
}