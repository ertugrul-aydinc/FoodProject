using MediatR;

namespace CoreAndFood.CQRS.Commands.Food.EditFood
{
    public class EditFoodCommandRequest : IRequest<EditFoodCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
