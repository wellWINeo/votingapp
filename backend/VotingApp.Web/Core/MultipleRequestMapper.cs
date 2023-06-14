using FastEndpoints;

namespace VotingApp.Web.Core;

public class MultipleRequestMapper<TRequest, TEntity, TMapper>
    : RequestMapper<IEnumerable<TRequest>, IEnumerable<TEntity>>
    where TMapper : RequestMapper<TRequest, TEntity>, new()
    where TRequest : notnull
{
    public override IEnumerable<TEntity> ToEntity(
        IEnumerable<TRequest> entities)
    {
        var mapper = new TMapper();
        foreach (var entity in entities)
            yield return mapper.ToEntity(entity);
    }
}