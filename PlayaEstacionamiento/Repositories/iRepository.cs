
namespace PlayaEstacionamiento.Repositories
{
    //interfas generica q funciona con cualquier clase
    public interface IRepository<T>
    {
        List<T> GetAll(); //metodos genericos q se pueden utilizar en cualquier clase
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
