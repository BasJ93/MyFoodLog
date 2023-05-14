using AutoMapper;
using MyFoodLog.Models.FoodItem;
using MyFoodLog.Database.Models;
using MyFoodLog.Models.FoodConsumption;
using MyFoodLog.Models.Meals;
using MyFoodLog.Models.MealTypes;

namespace MyFoodLog.Core.AutoMapper;

public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<FoodItem, FoodItemDto>();
        CreateMap<CreateFoodItemDto, FoodItem>();
        CreateMap<MealType, MealTypeDto>();
        CreateMap<Meal, MealDto>()
            .ForMember(dest => dest.ConsumedFood, opt => opt.MapFrom(source => source.ConsumedItems))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.MealType.Name));
        CreateMap<FoodItemConsumption, FoodConsumptionDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.FoodItem.Name))
            .ForMember(dest => dest.QuantityUnit, opt => opt.MapFrom(source => source.FoodItem.QuantityUnit))
            .ForMember(dest => dest.Energy, opt => opt.MapFrom<decimal>(source => source.Amount * source.FoodItem.Energy))
            .ForMember(dest => dest.Carbohydrates, opt => opt.MapFrom<decimal>(source => source.Amount * source.FoodItem.Carbohydrates))
            .ForMember(dest => dest.Fat, opt => opt.MapFrom<decimal>(source => source.Amount * source.FoodItem.Fat))
            .ForMember(dest => dest.Protein, opt => opt.MapFrom<decimal>(source => source.Amount * source.FoodItem.Protein));
    }
}