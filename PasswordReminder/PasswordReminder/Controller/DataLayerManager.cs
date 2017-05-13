using System;
using System.Collections.Generic;
using System.Linq;
using PasswordReminder.Helper;
using PasswordReminder.Model;
using SQLite.Net;
using Xamarin.Forms;

namespace PasswordReminder.Controller
{

    public class DataLayerManager : IDataLayerManager
    {
        private readonly SQLiteConnection _sqLiteConnection;

        public DataLayerManager()
        {
            _sqLiteConnection = DependencyService.Get<IConnectionHelper>().GetConnection();
            _sqLiteConnection.CreateTable<Person>();
            _sqLiteConnection.CreateTable<PersonSite>();
            //_sqLiteConnection.DeleteAll<PersonSite>();
        }

        #region CRUD

        public ResultModel<Person> SavePerson(Person model)
        {
            var result = new ResultModel<Person>();
            _sqLiteConnection.Insert(model);
            result.IsSuccess = true;
            return result;
        }

        public void UpdateData()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteData()
        {
            throw new System.NotImplementedException();
        }
        public ResultModel<int> Delete(int id)
        {
            var result= new ResultModel<int>();
            result.Value = _sqLiteConnection.Delete<PersonSite>(id);
            result.IsSuccess = true;
            return result;
        }


        public void GetDataAll()
        {
            throw new System.NotImplementedException();
        }

     

        public IEnumerable<PersonSite> GetAllPersonSites()
        {
            return _sqLiteConnection.Table<PersonSite>();
        }

        public ResultModel<Person> Login(Person modelPerson)
        {
            var person=new ResultModel<Person>();
            try
            {
                var result = _sqLiteConnection.Table<Person>().Where(x => x.Username == modelPerson.Username && x.Password == modelPerson.Password).FirstOrDefault();
                if (result != null)
                {
                    person.IsSuccess = true;
                }
                else
                {
                    person.Message = "Username or Password invalid";
                }
            }
            catch (Exception e)
            {
                person.Error = e.Message;
            }

            return person;
        }
        
    #endregion

        public ResultModel<PersonSite> SavePersonSite(PersonSite personSite)
        {
            var result = new ResultModel<PersonSite>();
            _sqLiteConnection.Insert(personSite);
            result.IsSuccess = true;
            return result;
        }

        public ResultModel<Person> GetDataWithFieldValue(string fieldValue)
        {
          var result= new ResultModel<Person>();
            var isDataExistInPerson =_sqLiteConnection.Table<Person>().FirstOrDefault(x => x.Email == fieldValue);
            if (isDataExistInPerson == null) return result;
            result.Value = isDataExistInPerson;
            result.IsSuccess = true;
            return result;
        }


        public ResultModel<Person> GetPersonInformation(string username)
        {
            var result = new ResultModel<Person>();
            var isDataExistInPerson = _sqLiteConnection.Table<Person>().FirstOrDefault(x => x.Username == username);
            if (isDataExistInPerson == null) return result;
            result.Value = isDataExistInPerson;
            result.IsSuccess = true;
            return result;
        }

        public ResultModel<Person> GetPersonById(int personSitePersonId)
        {
            var result = new ResultModel<Person>();
            var isDataExistInPerson = _sqLiteConnection.Table<Person>().FirstOrDefault(x => x.Id == personSitePersonId);
            if (isDataExistInPerson == null) return result;
            result.Value = isDataExistInPerson;
            result.IsSuccess = true;
            return result;
        }
    }
}
