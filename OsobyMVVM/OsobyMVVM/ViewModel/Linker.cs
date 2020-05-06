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
    using System.Windows.Controls.Primitives;
    using System.Windows.Controls;

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
            return p;
        }


        //public Person EditPerson(Person p, string[] s, int[] i)
        //{
        //    Person p = opera.Ed
        //}
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

        public Person currentPerson;

        public Person CurrentPerson
        {
            get
            {
                //if (currentPerson != null)
                //{
                //    Surname = currentPerson.Surname;
                //    Name =  currentPerson.Name;
                //    Age = Convert.ToInt32(currentPerson.Age);
                //    Weight =  Convert.ToInt32(currentPerson.Weight);
                //}
                return currentPerson;
            }
            set
            {
                currentPerson = value;
                onPropertyChanged(nameof(CurrentPerson));
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
                           if (Age == 0 || Weight == 0 || Name == null || Surname == null || Surname=="" || Name=="")
                               MessageBox.Show("Uwaga! Masz niepoprawne dane!", "UWAGA, BŁĄD");
                           else
                           {
                               Person p = AddPerson(new string[] { Surname, Name }, new int[] { Age, Weight });
                               JsonManager.PersonToJson(p);
                               //dla zapewnienia ze dane beda nowe
                               Age = 0;
                               Weight = 0;
                           }
                       },
                       arg => (true)
                        );
                }
                return _returnsList;
            }
        }


        private ICommand _editing = null;
        public ICommand Editing
        {
            get
            {
                _editing = new RelayCommand(
                  arg =>
                    {
                        if (Age == 0 || Weight == 0 || Name==null ||Surname==null || Surname == "" || Name == "")
                            MessageBox.Show("Uwaga! Masz niepoprawne dane!", "UWAGA, BŁĄD");
                        else
                        {
                            if (currentPerson != null)
                                EditExisting(currentPerson);
                            JsonManager.PeopleToJson(oc);
                        }
                       },
                     arg => (true)
                  );
                return _editing;
            }

        }


        public void EditExisting(Person current)
        {
            int i = oc.IndexOf(current);
            Oc.Remove(current);
            Person p = opera.AddPerson(new string[] { Surname, Name }, new int[] { Age, Weight });
            Oc.Insert(i, p);
            currentPerson = null;
        }



        private ICommand _deleting = null;
        public ICommand Deleting
        {
            get
            {
                _deleting = new RelayCommand(
                  arg =>
                  {
                      if(currentPerson!=null)
                      Delete(currentPerson);
                      JsonManager.PeopleToJson(oc);
                  },
                     arg => (true)
                  );
                return _deleting;
            }
        }
        public void Delete(Person p)
        {
            oc.Remove(p);
            JsonManager.PeopleToJson(oc);
            currentPerson = null;
        }


        #endregion

    }
}
