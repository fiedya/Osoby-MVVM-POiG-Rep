using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace OsobyMVVM.ViewModel
{
    using Model;
    using BaseClass;
    internal class Linker : ViewModelBase
    {
        private Operating opera = new Model.Operating();
        public ObservableCollection<Person> oc = new ObservableCollection<Person>();

        public Linker()
        {
           oc = JsonManager.LoadJsonBase();
        }

        public Person AddPerson(string[] s, int[] i)
        {

            Person p = opera.AddPerson(s, i);
            oc.Add(p);
            MessageBox.Show(Convert.ToString(oc.Count));
            return p;
        }

        public Person EditPerson(Person p, string[] s, int[] i)
        {
            Person p = opera.Ed
        }
        #region Interfejs publiczny
        //skłąda się z
        //string Surname - nazwisko
        //string Name - imie
        //int Age - wiek
        //int Weight - waga



        public string Surname { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }

        private string stringToSave = null;
        public string StringToSave
        {
            //string, który posłuży zapisaniu
            //tego w formie jednego stringa
            get
            {
                return stringToSave;
            }
            set
            {
                stringToSave = value;
            }
        }

        #endregion

        private string result = null;
        public string Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
                onPropertyChanged(nameof(Result));
            }
        }

        public ObservableCollection<Person> Oc
        {
            get
            {
                return oc;
            }
            set
            {
                oc = value;
                onPropertyChanged(nameof(Oc));
            }
        }


        #region Polecenia

        private ICommand _returnsList = null;
        public ICommand ReturnsList
        {
            get
            {
                if (_returnsList == null)
                {

                    _returnsList = new RelayCommand(
                       arg =>
                       {
                           Result = opera.ToListPerson(Surname, Name, Age, Weight);
                           Person p = AddPerson(new string[] { Surname, Name }, new int[] { Age, Weight });
                             JsonManager.PersonToJson(p);
                           //JsonManager.PeopleToJson(oc);

                       },
                       arg => (!string.IsNullOrEmpty(Surname)) && (!string.IsNullOrEmpty(Name))
                        );
                }
                return _returnsList;
            }
        }

        #region polecenie odpoiwedzialne za czyszczenie wyniku - własnosci Result  
        private ICommand _clear = null;
        public ICommand Clear
        {
            get
            {
                if (_clear == null)
                {
                    _clear = new RelayCommand(
                        arg => { Result = null; },

                        arg => true

                        );
                }

                return _clear;
            }
        }



        private ICommand _editing = null;
        public ICommand Editing
        {
            get
            {
                _returnsList = new RelayCommand(
                  arg =>
                    {
                         Result = opera.ToListPerson(Surname, Name, Age, Weight);
                         opera.EditExisting(p, Surname, Name, Age, Weight);
                         JsonManager.PeopleToJson(oc);
                       },
                     arg => (!string.IsNullOrEmpty(Surname)) && (!string.IsNullOrEmpty(Name))
                  );
                return _editing;
            }

        }

        private ICommand _deleting = null;
        public ICommand Deleting
        {
            get
            {
                Delete(p);
                return _deleting;
            }
        }


        public void Delete(Person p)
        {
            oc.Remove(p);
            JsonManager.PeopleToJson(oc)l
        }

        bool IsOk(int age, int weight)
        {
            if (age >= 0 && age <= 100 && weight >= 10 && weight <= 120) return true;
            else return false;
        }


        #endregion

        #endregion
    }
}
