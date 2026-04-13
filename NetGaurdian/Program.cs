using NetGuardian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetGaurdian
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //creating an imstance for audio bot
            Audio audio = new Audio();
            audio.Playaudio();

            //Calling the logo constructer to display the logo
            new Image();

            //created an instance for the bot class
            Bot bot = new Bot();
            bot.Chat();


        }
    }
}
