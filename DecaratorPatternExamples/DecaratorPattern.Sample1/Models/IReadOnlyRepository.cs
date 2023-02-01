namespace DecaratorPattern.Sample1.Models
{
    public interface IReadOnlyRepository<T> 
    {
        T GetById(int id);
        List<T> List();

    }
}
