using System;
using System.Collections.Generic;
using System.Text;
using DJSuite.Models;
namespace DJSuite.ViewModels
{
    public class SongViewModel : BaseViewModel
    {
        public Song song { get; set; }
        public SongViewModel(Song song = null)
        {
            Title = song?.Name;
            this.song = song;
        }


    }
}
