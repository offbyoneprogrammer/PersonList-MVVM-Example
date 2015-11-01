using PersonList.Model;
using PersonList.Utils;
using System;
using System.Collections.ObjectModel;
namespace PersonList.ViewModel
{
    public class DefaultViewModel : BindableBase
    {
        Person selectedPerson;
        String personLocation;
        public ObservableCollection<Person> PersonList { get; private set; }

        public DelegateCommand GetLocationIn3SecCommand { get; private set; }

        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                SetProperty(ref selectedPerson, value);
                PersonLocation = selectedPerson.Name + " is " + selectedPerson.CurrentLocation;
            }
        }
        public String PersonLocation
        {
            get { return personLocation; }
            private set { SetProperty(ref personLocation, value); }
        }

        public DefaultViewModel()
        {
            PersonList = new ObservableCollection<Person>();
            PersonList.Add(new Person("Alice", "at Home"));
            PersonList.Add(new Person("Bob", "at the Supermarket"));
            PersonList.Add(new Person("Eve", "at Work"));

            SelectedPerson = PersonList[0];
            GetLocationIn3SecCommand = new DelegateCommand(GetLocationIn3SecExecute, GetLocationIn3SecCanExecute);
        }

        private bool GetLocationIn3SecCanExecute(object obj)
        {
            return SelectedPerson != null;
        }

        private void GetLocationIn3SecExecute(object obj)
        {
            SelectedPerson.PropertyChanged += SelectedPerson_PropertyChanged;
            SelectedPerson.UpdateCurrentLocationIn3Seconds();
        }

        private void SelectedPerson_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var person = sender as Person;
            if (person == null)
                return;

            if (person != SelectedPerson)
                return;

            PersonLocation = person.Name + " is " + person.CurrentLocation;
            return;
        }
    }
}
