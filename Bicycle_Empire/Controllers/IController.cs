using System.Collections.Generic;

namespace Bicycle_Empire
{
    interface IController<T>
    {
        // mall för hur controller klasserna ska byggas upp. 
        List<T> GetAll();
        List<T> GetByString(string category, string input);
        int Add(T instance);
        void Update(int id, string category, string input);
        int Delete(int id);
    }
}
