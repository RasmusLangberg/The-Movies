using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace The_Movies.Services
{
    public class MessageService : IMessageService
    {



        public void ShowMessage(string message)
        {
            MessageBox.Show(message,"fejl",MessageBoxButton.OK,MessageBoxImage.Error);
        }

    }
}
