using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRanking.GUI
{
    public class GraphicInterfaces
    {
        public GraphicInterfaces()
        {

        }

        public string MainMenuInterface()
        {
            return @"Hello!!!
Choose an action:
1-Add a movie to the database manually.
2-Read a file.
3-Exit.";
        }
        public string CreateDatabaseManuallyInterface()
        {
            return @"You chose to add movies to the database manually. To go back to the main menu press <1>.
Please enter the movie this way < something | something | something,something | something > .";
        }
        public string ReadFileInterface()
        {
            return @"You chose to read a file. To go back to the main menu press <1>.
Please enter the address of your file.";
        }
        public string MakePDFInterface()
        {
            return @"You chose to read a file. To go back to the main menu press <1>.
Not qute sure how were gonna create pdfs yet.";
        }

        public string CreateGeneralInstructions()
        {
            return "Please enter the required data as requested below.";
        }

        public string Title()
        {
            return "Title: ";
        }

        public string Genre()
        {
            return "Genre: ";
        }

        public string FName()
        {
            return "First name: ";
        }

        public string LName()
        {
            return "Last name: ";
        }

        public string YBorn()
        {
            return "Year born: ";
        }

        public string SBio()
        {
            return "Short bio: ";
        }


    }
}
