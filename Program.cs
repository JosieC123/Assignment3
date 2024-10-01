﻿using NLog;
string path = Directory.GetCurrentDirectory() + "//nlog.config";
// create instance of Logger
var logger = LogManager.Setup().LoadConfigurationFromFile(path).GetCurrentClassLogger();
logger.Info("Program started");
string file = "mario.csv";
// make sure movie file exists
if (!File.Exists(file))
{
    logger.Error("File does not exist: {File}", file);
}
else
{
    //new character list
    List<Character> characters = [];

    // to populate the lists with data, read from the data file
    try
    {
        StreamReader sr = new(file);
        // first line contains column headers
        sr.ReadLine();
        while (!sr.EndOfStream)
        {
            string? line = sr.ReadLine();
            if (line is not null)
            {
                Character character = new();
                // character details are separated with comma(,)
                string[] characterDetails = line.Split(',');
                // 1st array element contains id
                   character.Id = UInt64.Parse(characterDetails[0]);
                // 2nd array element contains character name
                   character.Name = characterDetails[1] ?? string.Empty;
                // 3rd array element contains character description
                   character.Description = characterDetails[2] ?? string.Empty;
                // 4th array element contains character species
                   character.Species = characterDetails[3] ?? string.Empty;
                // 5th array element contains character First Appearance
                   character.FirstAppearance = characterDetails[4] ?? string.Empty;
                // 6th array element contains character Year Created
                   character.YearCreated = int.Parse(characterDetails[5]);
                   characters.Add(character);
            }
        }
        sr.Close();
    }
    catch (Exception ex)
    {
        logger.Error(ex.Message);
    }

    // string? choice;
    // do
    // {
    //     // display choices to user
    //     Console.WriteLine("1) Add Character");
    //     Console.WriteLine("2) Display All Characters");
    //     Console.WriteLine("Enter to quit");
    //     // input selection
    //     choice = Console.ReadLine();
    //     logger.Info("User choice: {Choice}", choice);
    //     if (choice == "1")
    //     {
    //         // Add Character
    //         Console.WriteLine("Enter new character name: ");
    //         string? Name = Console.ReadLine();

    //         if (!string.IsNullOrEmpty(Name))
    //         {
    //             // check for duplicate name
    //             List<string> LowerCaseNames = Names.ConvertAll(n => n.ToLower());
    //             if (LowerCaseNames.Contains(Name.ToLower()))
    //             {
    //                 logger.Info($"Duplicate name {Name}");
    //             }
    //             else
    //             {
    //                 // generate id - use max value in Ids + 1
    //                 UInt64 Id = Ids.Max() + 1;
    //                 // input character description
    //                 Console.WriteLine("Enter description:"); //description
    //                 string? Description = Console.ReadLine();

    //                 Console.WriteLine("Enter Species:"); //species
    //                 string? CharacterSpecies = Console.ReadLine();

    //                 Console.WriteLine("Enter First Appearance:"); //appearance
    //                 string? CharacterFirstAppearance = Console.ReadLine();

    //                 Console.WriteLine("Enter Year Created:"); //year
    //                 try // check if input is a number
    //                 {
    //                     int? CharacterYearCreated = Convert.ToInt32(Console.ReadLine());
    //                     // create file from data
    //                     StreamWriter sw = new(file, true);
    //                     sw.WriteLine($"{Id}, {Name}, {Description}, {CharacterSpecies}, {CharacterFirstAppearance}, {CharacterYearCreated}");
    //                     sw.Close();
    //                     // add new character details to Lists
    //                     Ids.Add(Id);
    //                     Names.Add(Name);
    //                     Descriptions.Add(Description);
    //                     Species.Add(CharacterSpecies);
    //                     FirstAppearance.Add(CharacterFirstAppearance);
    //                     YearCreated.Add(CharacterYearCreated);
    //                     // log transaction
    //                     logger.Info($"Character id {Id} added");
    //                 }
    //                 catch (FormatException)
    //                 {
    //                     logger.Error("Year must be a number");
    //                 }
    //             }
    //         }
    //         else
    //         {
    //             logger.Error("You must enter a name");
    //         }
        // }
        // else if (choice == "2")
        // {
        //     // Display All Characters
        //     // loop thru Lists
        //     for (int i = 0; i < Ids.Count; i++)
        //     {
        //         // display character details
        //         Console.WriteLine($"Id: {Ids[i]}");
        //         Console.WriteLine($"Name: {Names[i]}");
        //         Console.WriteLine($"Description: {Descriptions[i]}");
        //         Console.WriteLine($"Species: {Species[i]}");
        //         Console.WriteLine($"First Appearance: {FirstAppearance[i]}");
        //         Console.WriteLine($"Year Created: {YearCreated[i]}");
        //         Console.WriteLine();
        //     }
        // }
//     } while (choice == "1" || choice == "2");
 }
logger.Info("Program ended");