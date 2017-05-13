using PasswordReminder.Model;

namespace PasswordReminder.Controller
{
    interface IDataLayerManager
    {
        ResultModel<Person> SavePerson(Person person);
        void UpdateData();
        void DeleteData();
        void GetDataAll();
        ResultModel<int> Delete(int id);
        ResultModel<Person> GetDataWithFieldValue(string fieldValue);
     
    }
}
