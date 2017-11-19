using Caliburn.Micro;
using myTestTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myTestTool.ViewModels
{
    public class ShellViewModel:Conductor<object>  // :Screen
    {
        private string _firstname="HARRY";
        private string _lastname;
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
        private PersonModel _personModel;

        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "Hari", LastName = "Gangwar" });
            People.Add(new PersonModel { FirstName = "Harry", LastName = "Poonam" });
            People.Add(new PersonModel { FirstName = "vicky", LastName = "G" });
        }
        public string FirstName
        {
            get {
                return _firstname;
                }
            set {
                _firstname = value;
                NotifyOfPropertyChange(() => FirstName);   //this updates property with new value whenever property value is changed.
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string  LastName
        {
            get {
                return _lastname;
                }
            set {
                _lastname = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
                }
        }


        public string FullName
        {
            get {
                return $"{FirstName} {LastName}";
                }
        }

        
        public BindableCollection<PersonModel> People
        {
            get { return _people; }
            set { _people = value; }
        }

        
        public PersonModel SelectedPerson
        {
            get { return _personModel; }
            set {
                _personModel = value;
                NotifyOfPropertyChange(() => SelectedPerson);
                }
        }

        public bool CanClearText(string firstname, string lastname) //this method is working of its own, without its access.   // => !String.IsNullOrWhiteSpace(firstname) && !String.IsNullOrWhiteSpace(lastname);
        {
            //return !String.IsNullOrWhiteSpace(firstname) && !String.IsNullOrWhiteSpace(lastname);
            if (String.IsNullOrWhiteSpace(firstname) && String.IsNullOrWhiteSpace(lastname))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ClearText(string firstname, string lastname)
        {
            FirstName = "";
            firstname = "";
            LastName = "";
        }

        public void LoadPageOne()
        {
           ActivateItem(new FirstChildViewModel());
        }
        public void LoadPageTwo()
        {
            ActivateItem(new SecondChildViewModel());
        }

    }
}
