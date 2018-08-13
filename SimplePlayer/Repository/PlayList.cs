using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePlayer.Repository
{

    public class PlayList
    {
        private ObservableCollection<String> filesCollection = new ObservableCollection<String>();


        public ObservableCollection<String> FilesCollection
        {
            get
            {
                //if (filesCollection == null)
                //{
                //    filesCollection = new ObservableCollection<String>()
                //    {
                //         @"E:\Artem\Videos\Avengers.mkv",
                //        @"E:\Artem\Videos\Eminem - Lose Yourself.ts"
                //    };
                //}
                return filesCollection;
            }
            set
            {
                filesCollection = value;
            }

            
        }



        public void AddToPlayList(String uri)
        {
            if (filesCollection == null)
            {
                filesCollection = new ObservableCollection<String>();
                filesCollection.Add(uri);
                //OnPropertyChanged();
            }
            else
            {
                filesCollection.Add(uri);
            }
                
                
        }

        //public void DeleteFromPlayList(String uri)
        //{
        //    filesCollection.Remove(uri);
        //}





    }

}
