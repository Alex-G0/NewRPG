using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using Engine;

namespace Engine.Actions 
{
    public class Action1 : BaseNotificationClass
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
