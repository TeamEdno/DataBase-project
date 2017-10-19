﻿using System;
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
1-Add a movie to the database.
2-Add an actor to a movie.
3-Add a director to a movie.
4-Add a studio to a movie;
5-Rate a movie.
6-Delete a movie.
0-Exit.";
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
            return "Please enter data as requested below.";
        }

        public string ListGeneralInstructions()
        {
            return "You can see top X movies from our collection! \nHow much is X?";
        }

        public string DeletingGeneralInstructions()
        {
            return "You can delete a movie.\nPlease type its title: ";
        }

        public string RatingGeneralInstructions()
        {
            return "You can change the rating of a movie.\nPlease type its title: ";
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

        public string Name()
        {
            return "Name: ";
        }

        public string YEstablished()
        {
            return "Year established: ";
        }

        public string Trivia()
        {
            return "Trivia: ";
        }

        public string ToWhichFilm()
        {
            return "Please type the title of the film: ";
        }

        public string Rate()
        {
            return "Rate: ";
        }
    }
}
