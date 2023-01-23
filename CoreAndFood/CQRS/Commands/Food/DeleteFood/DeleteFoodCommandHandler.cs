using CoreAndFood.Repositories.Abstract;
using MediatR;

namespace CoreAndFood.CQRS.Commands.Food.AddFood
{
    public class DeleteFoodCommandHandler : IRequestHandler<DeleteFoodCommandRequest, DeleteFoodCommandResponse>
    {
        readonly IFoodRepository _foodRepository;

        public DeleteFoodCommandHandler(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public Task<DeleteFoodCommandResponse> Handle(DeleteFoodCommandRequest request, CancellationToken cancellationToken)
        {
            _foodRepository.DeleteById(request.Id);
            return null;
        }
    }
}
