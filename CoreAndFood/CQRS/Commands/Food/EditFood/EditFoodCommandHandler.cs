using CoreAndFood.Models;
using CoreAndFood.Repositories.Abstract;
using MediatR;
using NuGet.Protocol.Plugins;

namespace CoreAndFood.CQRS.Commands.Food.EditFood
{
    public class EditFoodCommandHandler : IRequestHandler<EditFoodCommandRequest, EditFoodCommandResponse>
    {
        readonly IFoodRepository _foodRepository;

        public EditFoodCommandHandler(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public Task<EditFoodCommandResponse> Handle(EditFoodCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedFood = _foodRepository.Get(request.Id);

            updatedFood.Name = request.Name;
            updatedFood.Stock = request.Stock;
            updatedFood.Price = request.Price;
            updatedFood.ImageUrl = request.ImageUrl;
            updatedFood.Description = request.Description;
            updatedFood.CategoryId = request.CategoryId;

            _foodRepository.Update(updatedFood);

            return null;

        }
    }
}
