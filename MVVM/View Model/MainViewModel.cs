using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zcord.Core;
using Zcord.MVVM.Model;

namespace Zcord.MVVM.View_Model
{
    class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }

        public ObservableCollection<MessageModel> animedlyDesc { get; set; }

        public ObservableCollection<MessageModel> egirlDesc { get; set; }
        public ObservableCollection<ServerModel> Servers { get; set; }


        /* Commands */
        public RelayCommand SendCommand { get; set; }

        private ServerModel _selectedServer;

        public ServerModel SelectedServer
        {
            get { return _selectedServer; }
            set
            { _selectedServer = value;
                OnPropertyChanged();
            }
        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set { 
                _message = value;
                OnPropertyChanged();
            }

        }


        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Servers = new ObservableCollection<ServerModel>();

            animedlyDesc = new ObservableCollection<MessageModel>();
            egirlDesc = new ObservableCollection<MessageModel>();

            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    FirstMessage = false
                });
                Message = "";
            });

            animedlyDesc.Add(new MessageModel
            {
                Name = "Animedly",
                NameColor = "#ffffff",
                ImageSource = "./Icons/animedly-logo.png",
                Message = "The Official Server for animedly.net",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });

            egirlDesc.Add(new MessageModel
            {
                Name = "e-girl",
                NameColor = "#ffffff",
                ImageSource = "./Icons/e-girl.jpg",
                Message = ";)",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });

            Messages.Add(new MessageModel
            {
                Name = "George",
                NameColor = "#ffffff",
                ImageSource = "./Icons/ice-bear.png",
                Message = "The 3x+1 problem is quite interesting",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            }); 

            for (int i = 0; i < 4; i++)
            {
                Messages.Add(new MessageModel
                {
                    Name = "Mexico",
                    NameColor = "#ffffff",
                    ImageSource = "./Icons/ice-bear.png",
                    Message = "Let's Go",
                    Time = DateTime.Now,
                    IsNativeOrigin = true,
                });
            }

            Messages.Add(new MessageModel
            {
                Name = "George",
                NameColor = "#ffffff",
                ImageSource = "./Icons/ice-bear.png",
                Message = "The main server for Zcord",
                Time = DateTime.Now,
                IsNativeOrigin = true,
            });


            Servers.Add(new ServerModel
            {
                Name = "Zcord Central",
                ImageSource = "./Icons/cord-big.png",
                Messages = Messages

            });

            Servers.Add(new ServerModel
            {
                Name = "e-girl paradise",
                ImageSource = "./Icons/e-girl.jpg",
                Messages = egirlDesc

            });

            Servers.Add(new ServerModel
            {
                Name = "Animedly",
                ImageSource = "./Icons/animedly-logo.png",
                Messages = animedlyDesc

            });

        }
    }
}
