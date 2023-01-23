using MediatR;

namespace CoreAndFood.CQRS.Commands.Food.AddFood
{
    public class AddFoodCommandRequest : IRequest<AddFoodCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IFormFile? ImageUrl { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
