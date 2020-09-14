using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Engine.Actions
{
    public class Action5 : BaseNotificationClass
    {
        private double id { get; set; }

        private string content { get; set; }

        public double ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }
        public string Content
        {
            get { return content; }
            set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }
    }
}
