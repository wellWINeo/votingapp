using FastEndpoints;

namespace VotingApp.Web.Core;

public class MultipleResponseMapper<TResponse, TEntity, TMapper>
    : ResponseMapper<IEnumerable<TResponse>, IEnumerable<TEntity>>
    where TMapper : ResponseMapper<TResponse, TEntity>, new()
    where TResponse : notnull
{
    public override IEnumerable<TResponse> FromEntity(
        IEnumerable<TEntity> entities)
    {
        var mapper = new TMapper();
        foreach (var entity in entities)
            yield return mapper.FromEntity(entity);
    }
}