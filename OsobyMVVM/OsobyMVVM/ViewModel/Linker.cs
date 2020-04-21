using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace OsobyMVVM.ViewModel
{
    using Model;
    using BaseClass;
    internal class Linker : ViewModelBase
    {
        private Operating opera = new Model.Operating();

        public Linker()
        {
            //update osób ?
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

        private string stringToSave=null;
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
                stringToSave= value;
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

        #region Polecenia

        private ICommand _returns = null;
        public ICommand Returns
        {
            get
            {
                if(_returns==null)
                {
                    //mam nadzieje, ze przypisuje ReturnsPerson
                    //jeśli poniższe nie są nullami
                    _returns = new RelayCommand(
                        arg => { Result = opera.StringPerson(Surname, Name, Age, Weight); },
                        arg => string.IsNullOrEmpty(Surname) && string.IsNullOrEmpty(Name)
                        );
                }
                return _returns;
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
        #endregion

        #endregion
    }
}
