using CoreAndFood.Repositories.Abstract;
using MediatR;
using NuGet.Protocol.Plugins;
using X.PagedList;

namespace CoreAndFood.CQRS.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, List<GetAllCategoryQueryResponse>>
    {
        readonly ICategoryRepository _categoryRepository;

        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<GetAllCategoryQueryResponse>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetAll().Select(category => new GetAllCategoryQueryResponse
            {
                CategoryName = category.CategoryName,
                CategoryDescription = category.CategoryDescription,
                Status = category.Status
            }).ToListAsync();
        }
    }
}
