namespace VotingApp.Domain.Shared;

public interface IEntity<out T>
{
    T Id { get; }
}