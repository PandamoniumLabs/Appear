using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Appear.Events
{
    public class UpdateFoldersEventArgs : RoutedEventArgs
    {
        private string path { get; set; }
        public string Path
        {
            get { return path; }
        }

        private ActionType action { get; set; }
        public ActionType Action
        {
            get { return action; }
        }

        public UpdateFoldersEventArgs(RoutedEvent e, string path, ActionType action) : base(e)
        {
            this.path = path;
            this.action = action;
        }

        public enum ActionType
        {
            ADD,
            REMOVE
        }
    }
}
