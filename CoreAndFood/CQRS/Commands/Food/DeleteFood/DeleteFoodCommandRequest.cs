using MediatR;

namespace CoreAndFood.CQRS.Commands.Food.AddFood
{
    public class DeleteFoodCommandRequest : IRequest<DeleteFoodCommandResponse>
    {
        public int Id { get; set; }
    }
}
