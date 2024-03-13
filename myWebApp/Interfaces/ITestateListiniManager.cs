
using myWebApp.Shared.Models;

namespace myWebApp.Interfaces
{
    public interface ITestateListiniManager
    {
        public List<TestataListino> GetTestateListini();

        public string AddTestataListino(TestataListino rk);

        public string UpdateTestataListino(string IDListino, TestataListino rk);

        public TestataListino GetTestataListino(string IDListino);

        public TestataListino DeleteTestataListino(string IDListino);
    }
}