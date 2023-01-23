using MediatR;

namespace CoreAndFood.CQRS.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryRequest : IRequest<List<GetAllCategoryQueryResponse>>
    {
    }
}
