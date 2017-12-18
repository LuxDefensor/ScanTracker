using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ScanTracker
{
    class USPD:DependencyObject
    {
        public static readonly DependencyProperty ID_uspdProperty =
            DependencyProperty.Register("ID_uspd", typeof(string), typeof(MainWindow));
        public string ID_uspd
        {
            get
            {
                return this.GetValue(ID_uspdProperty) as string;
            }
            set
            {
                this.SetValue(ID_uspdProperty, value);
            }
        }
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(MainWindow));
        public string Name
        {
            get
            {
                return this.GetValue(NameProperty) as string;
            }
            set
            {
                this.SetValue(NameProperty, value);
            }
        }
        public static readonly DependencyProperty TypeCommunProperty =
            DependencyProperty.Register("TypeCommun", typeof(string), typeof(MainWindow));
        public string TypeCommun
        {
            get
            {
                return this.GetValue(TypeCommunProperty) as string;
            }
            set
            {
                this.SetValue(TypeCommunProperty, value);
            }
        }
        public static readonly DependencyProperty COMPortProperty =
            DependencyProperty.Register("COMPort", typeof(string), typeof(MainWindow));
        public string COMPort
        {
            get
            {
                return "COM" + (this.GetValue(COMPortProperty) as string);
            }
            set
            {
                this.SetValue(COMPortProperty, value);
            }
        }
        public static readonly DependencyProperty DateProperty =
            DependencyProperty.Register("Date", typeof(string), typeof(MainWindow));
        public string Date
        {
            get
            {
                return this.GetValue(DateProperty) as string;
            }
            set
            {
                this.SetValue(DateProperty, value);
            }
        }
        public static readonly DependencyProperty EventProperty =
            DependencyProperty.Register("Event", typeof(string), typeof(MainWindow));
        public string Event
        {
            get
            {
                return this.GetValue(EventProperty) as string;
            }
            set
            {
                this.SetValue(EventProperty, value);
            }
        }
        public static readonly DependencyProperty CommentProperty =
            DependencyProperty.Register("Comment", typeof(string), typeof(MainWindow));
        public string Comment
        {
            get
            {
                return this.GetValue(CommentProperty) as string;
            }
            set
            {
                this.SetValue(CommentProperty, value);
            }
        }

        public static readonly DependencyProperty ProcessCountProperty =
            DependencyProperty.Register("ProcessCount", typeof(int?), typeof(MainWindow));
        public int? ProcessCount
        {
        get
            {
                return this.GetValue(ProcessCountProperty) as int?;
            }
            set
            {
                this.SetValue(ProcessCountProperty, value);
            }
        }
    }
}
