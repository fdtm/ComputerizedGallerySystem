using System;
using CGS.Persistence;
using static CGS.Persistence.Data;
using static CGS.Validations.ArtPieceValidation;
using static CGS.Validations.ArtistValidation;
using CGS.Validations;

namespace CGS
{
    public class Function
    {
        public static void AddArtist()
        {
            if (ArtistCount < 5)
            {
                bool condition;

                string ID;
                do
                {
                    Console.Write("Enter ID: ");
                    ID = Console.ReadLine();
                    condition = Validation.IsIdValid(ID);
                    if (!condition)
                        Console.WriteLine("ID is not valid (Enter 5 Unique character)");
                } while (!condition);

                string fname;
                do
                {
                    Console.Write("Enter first name: ");
                    fname = Console.ReadLine();
                    condition = IsNameValid(fname);
                    if(!condition)
                        Console.WriteLine("first name should be at most 40 character");
                } while (!condition);

                string lname;
                do
                {
                    Console.Write("Enter last name: ");
                    lname = Console.ReadLine();
                    condition = IsNameValid(lname);
                    if (!condition)
                        Console.WriteLine("last name should be at most 40 character");
                } while (!condition);

                MyArtists[ArtistCount].ID = ID;
                MyArtists[ArtistCount].fname = fname;
                MyArtists[ArtistCount].lname = lname;
                Console.WriteLine("Artist Added Succesfully");

                Data.ArtistCount++;
            }
            else
            {
                Console.WriteLine("you can not add anymore artist");
            }
        }

        public static void AddCurator()
        {
            if (CuratorCount < 3)
            {
                bool condition;

                string ID;
                do
                {
                    Console.Write("Enter ID: ");
                    ID = Console.ReadLine();
                    condition = Validation.IsIdValid(ID);
                    if (!condition)
                        Console.WriteLine("ID is not valid (Enter 5 Unique character)");
                } while (!condition);

                string fname;
                do
                {
                    Console.Write("Enter first name: ");
                    fname = Console.ReadLine();
                    condition = IsNameValid(fname);
                    if (!condition)
                        Console.WriteLine("first name should be at most 40 character");
                } while (!condition);

                string lname;
                do
                {
                    Console.Write("Enter last name: ");
                    lname = Console.ReadLine();
                    condition = IsNameValid(lname);
                    if (!condition)
                        Console.WriteLine("last name should be at most 40 character");
                } while (!condition);

                Data.MyCurators[CuratorCount].ID = ID;
                Data.MyCurators[CuratorCount].fname = fname;
                Data.MyCurators[CuratorCount].lname = lname;
                Console.WriteLine("Curator Added Succesfully");

                CuratorCount++;
            }
            else
            {
                Console.WriteLine("you can not add anymore curator");
            }
        }

        public static void AddArtPiece()
        {
            if (ArtPieceCount < 10)
            {
                bool condition;

                string ID;
                do
                {
                    Console.Write("Enter ID: ");
                    ID = Console.ReadLine();
                    condition = Validation.IsIdValid(ID);
                    if (!condition)
                        Console.WriteLine("ID is not valid (Enter 5 Unique character)");
                } while (!condition);

                string title;
                do
                {
                    Console.Write("Enter title: ");
                    title = Console.ReadLine();
                    condition = IsTitleValid(title);
                    if (!condition)
                        Console.WriteLine("title should be at most 40 character");
                } while (!condition);

                string date;
                do
                {
                    Console.Write("Enter date: ");
                    date = Console.ReadLine();
                    condition = IsDateValid(date);
                    if(!condition)
                        Console.WriteLine("date must be 4 digits");
                } while (!condition);

                Console.Write("Enter ID artist: ");
                string IDArtist = Console.ReadLine();

                Console.Write("Enter ID curator: ");
                string IDCurator = Console.ReadLine();

                string estimed;
                do
                {
                    Console.Write("Enter estimed: ");
                    estimed = Console.ReadLine();
                    condition = IsEstimedAndPriceValid(estimed);
                    if(!condition)
                        Console.WriteLine("estimed must be digits");
                } while (!condition);

                string price;
                do
                {
                    Console.Write("Enter price: ");
                    price = Console.ReadLine();
                    condition = IsEstimedAndPriceValid(price);
                    if (!condition)
                        Console.WriteLine("price must be digits");
                } while (!condition);

                string status;
                do
                {
                    Console.Write("Enter status: ");
                    status = Console.ReadLine();
                    condition = IsStatusValid(status);
                    if(!condition)
                        Console.WriteLine("status should be D or S or O");
                } while (!condition);

                Data.MyArtPieces[ArtPieceCount].ID = ID;
                Data.MyArtPieces[ArtPieceCount].title = title;
                Data.MyArtPieces[ArtPieceCount].date = date;
                Data.MyArtPieces[ArtPieceCount].IDArtist = IDArtist;
                Data.MyArtPieces[ArtPieceCount].IDCurator = IDCurator;
                Data.MyArtPieces[ArtPieceCount].estimed = double.Parse(estimed == "" ? "0" : estimed);
                Data.MyArtPieces[ArtPieceCount].price = double.Parse(price == "" ? "0" : price);
                Data.MyArtPieces[ArtPieceCount].status = char.Parse(status);
                Console.WriteLine("Art Piece Added Succesfully");

                ArtPieceCount++;
            }
            else
            {
                Console.WriteLine("you can not add anymore art piece");
            }
        }

        public static void DisplayAllArtPieces()
        {
            bool isEmpty = true;
            for (int i = 0; i < Data.MyArtPieces.Length; i++)
            {
                var ArtPieces = Data.MyArtPieces[i];
                if (ArtPieces.ID != null)
                {
                    isEmpty = false;
                    Console.WriteLine($"ID = {ArtPieces.ID}, title = {ArtPieces.title}, date = {ArtPieces.date}, IDArtist = {ArtPieces.IDArtist}, IDCurator = {ArtPieces.IDCurator}, estimed = {ArtPieces.estimed}, price = {ArtPieces.price}, status = {ArtPieces.status}");
                }
            }
            if (isEmpty)
                Console.WriteLine("No Art Pieces has been added");
        }

        public static void FindArtPieceByCode(string code)
        {
            bool isExist = false;
            for (int i = 0; i < Data.MyArtPieces.Length; i++)
            {
                var ArtPieces = Data.MyArtPieces[i];
                if (ArtPieces.ID == code)
                {
                    isExist = true;
                    Console.WriteLine($"ID = {ArtPieces.ID}, title = {ArtPieces.title}, date = {ArtPieces.date}, IDArtist = {ArtPieces.IDArtist}, IDCurator = {ArtPieces.IDCurator}, estimed = {ArtPieces.estimed}, price = {ArtPieces.price}, status = {ArtPieces.status}");
                }
            }
            if (!isExist)
                Console.WriteLine("Not Found!");
        }
    }
}