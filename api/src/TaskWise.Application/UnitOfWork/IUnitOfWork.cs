namespace TaskWise.Application.UnitOfWork;

public interface IUnitOfWork
{
    Task SaveChanges(CancellationToken ct);
}
