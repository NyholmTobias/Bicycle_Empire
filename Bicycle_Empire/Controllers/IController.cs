using System.Collections.Generic;

namespace Bicycle_Empire
{
    interface IController<T>
    {
        List<T> GetAll();
        List<T> GetByString(string category, string input);
        int Add(T instance);
        void Update(int id, string category, string input);
        int Delete(int id);
    }
}
