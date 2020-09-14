using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Engine
{
    public class Location : BaseNotificationClass
    {
        private int _id { get; set; }
        private string _name { get; set; }
        private string _description { get; set; }
        public int ID 
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("ID");
            }
        }
        public string Name 
        {
            get { return _name; }
            set 
            {
                _name = value;
                OnPropertyChanged("Name");
            } 
        }
        public string Description 
        {
            get { return _description;}
            set 
            {
                _description = value;
                OnPropertyChanged("Description");
            }        
        }    
    }
}
