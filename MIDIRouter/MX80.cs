using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDIRouter
{
    class MX80
    {
        
        /// <summary>
        /// Reset the mx80 controller module
        /// </summary>
        public static string reset = "B0477F";

        /// <summary>
        /// Start test mode on mx80 controller module
        /// </summary>
        public static string testMode = "B0527F";

        /// <summary>
        /// Playback track
        /// </summary>
        public static string play = "B06301";

        /// <summary>
        /// Record incomming keys
        /// </summary>
        public static string record = "B06307";

        /// <summary>
        /// Enable keyboard midi output (using recording test of mx80 module)
        /// </summary>
        public static string enableMidiOut = "B06314";
       
    }
}
