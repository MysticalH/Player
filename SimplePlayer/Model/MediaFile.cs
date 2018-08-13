using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePlayer.Model
{
    class MediaFile
    {
        private Uri playFile;

        public Uri PlayFile
        {
            get {
                //if (playFile == null)
                //{
                //    playFile = new Uri(@"E:\Artem\Videos\Eminem - Lose Yourself.ts");
                //}
                return playFile; }
            set { playFile = value; }
        }

    }
}
