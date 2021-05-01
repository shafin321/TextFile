using System.Collections.Generic;

namespace TestFile
{
    public interface ICSVReader<TModel>
        where TModel : class, new()
    {
        List<TModel> ReadFromFile(string path);
    }
}