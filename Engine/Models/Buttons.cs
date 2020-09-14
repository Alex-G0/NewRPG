using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Engine
{
    public class Buttons : INotifyPropertyChanged
    {
        private string _buttonContent { get; set; }
        private string _buttonContentNew { get; set; }
        private EventHandler _clickEvent { get; set; }
        private EventHandler _clickEventNew { get; set; }
        public string ButtonContentNew 
        {
            get { return _buttonContentNew; }
            set
            {
                _buttonContentNew = value;
                OnPropertyChanged("ButtonContentNew");
            }
        }
        public string ButtonContent
        {
            get { return _buttonContent; }
            set
            {
                _buttonContent = value;
                OnPropertyChanged("ButtonContent");
            }
        }
        public EventHandler ClickEvent
        {
            get { return _clickEvent; }
            set
            {
                _clickEvent = value;
                OnPropertyChanged("ClickEvent");
            }
        }
        public EventHandler ClickEventNew
        {
            get { return _clickEventNew; }
            set
            {
                _clickEventNew = value;
                OnPropertyChanged("ClickEventNew");
            }
        }









        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
