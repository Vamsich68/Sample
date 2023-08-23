using Sample.Models;

namespace Sample.Repo
{
    public interface IEmployeeRepoEF
    {
        Employee Find(string id);
        List<Employee> GetAll();
        Employee Update(Employee employee);
        Employee Add(Employee employee);
        void Remove(string id);
        object Find(object value);
    }
}
