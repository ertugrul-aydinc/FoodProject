using CoreAndFood.Models;
using CoreAndFood.Repositories.Abstract;
using MediatR;
using NuGet.Protocol.Plugins;

namespace CoreAndFood.CQRS.Commands.Food.AddFood
{
    public class AddFoodCommandHandler : IRequestHandler<AddFoodCommandRequest, AddFoodCommandResponse>
    {
        readonly IFoodRepository _foodRepository;

        public AddFoodCommandHandler(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public Task<AddFoodCommandResponse> Handle(AddFoodCommandRequest request, CancellationToken cancellationToken)
        {
            Models.Food f = new Models.Food();

            if (request.ImageUrl != null)
            {
                var extension = Path.GetExtension(request.ImageUrl.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/resimler/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                request.ImageUrl.CopyTo(stream);
                f.ImageUrl = newImageName;
            }

            f.Name = request.Name;
            f.Description = request.Description;
            f.Price = request.Price;
            f.Stock = request.Stock;
            f.CategoryId = request.CategoryId;

            _foodRepository.Add(f);

            return null;
        }
    }
}
