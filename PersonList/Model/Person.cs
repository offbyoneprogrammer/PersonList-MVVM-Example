using PersonList.Utils;
using System;
using Windows.UI.Xaml;

namespace PersonList.Model
{
    public class Person : BindableBase
    {
        private DispatcherTimer timer = new DispatcherTimer();
        public String Name { get; set; }

        private String currentLocation;
        public String CurrentLocation
        {
            get { return currentLocation; }
            set { SetProperty(ref currentLocation, value); }
        }

        public Person(String name, String currentlocation)
        {
            Name = name;
            CurrentLocation = currentlocation;
        }

        public void UpdateCurrentLocationIn3Seconds()
        {
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Tick += tickEvent;
            timer.Start();
        }

        private void tickEvent(object sender, object e)
        {
            timer.Stop();
            CurrentLocation = "Still at " + CurrentLocation;
        }
    }
}
