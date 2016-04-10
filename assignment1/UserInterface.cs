﻿//Author: David Barnes
//CIS 237
//Assignment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class UserInterface
    {
        const int maxMenuChoice = 6;
        //---------------------------------------------------
        //Public Methods
        //---------------------------------------------------

        //Display Welcome Greeting
        public void DisplayWelcomeGreeting()
        {
            Console.WriteLine("Welcome to the wine program");
        }

        //Display Menu And Get Response
        public int DisplayMenuAndGetResponse()
        {
            int maxMenuChoice = 6;
            //declare variable to hold the selection
            string selection;

            //Display menu, and prompt
            this.displayMenu();
            this.displayPrompt();

            //Get the selection they enter
            selection = this.getSelection();

            //While the response is not valid
            while (!this.verifySelectionIsValid(selection, maxMenuChoice))
            {
                //display error message
                this.displayErrorMessage();

                //display the prompt again
                this.displayPrompt();

                //get the selection again
                selection = this.getSelection();
            }
            //Return the selection casted to an integer
            return Int32.Parse(selection);
        }

        //Get the search query from the user
        public string GetSearchQuery()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to search for?");
            Console.Write("> ");
            return Console.ReadLine();
        }

        public string GetUpdateQuery()
        {
            Console.WriteLine();
            Console.WriteLine("What woud you like to search for?");
            Console.Write("> ");
            return Console.ReadLine();
        }

        //Get New Item Information From The User.
        public Beverage GetNewItemInformation()
        {
            decimal tempDec;
            string tempString;
            Beverage newBeverageToAdd = new Beverage();

            Console.WriteLine();
            Console.WriteLine("What is the ID?");
            newBeverageToAdd.id = Console.ReadLine();
            Console.WriteLine("What is the name?");
            newBeverageToAdd.name = Console.ReadLine();
            Console.WriteLine("What is the pack?");
            newBeverageToAdd.pack = Console.ReadLine();
            Console.WriteLine("What is the price?");
            while (!decimal.TryParse(Console.ReadLine(), out tempDec))
            {
                Console.WriteLine("Please enter a number for the price.");
            }
            newBeverageToAdd.price = tempDec;

            Console.WriteLine("Is the item active?");
            tempString = Console.ReadLine();

            while (tempString.ToLower() != "f" || tempString.ToLower() != "f")
            {
                Console.WriteLine("Please enter either true or false.");
            }

            if (tempString == "f")
            {
                newBeverageToAdd.active = false;
            }
            
            else
            {
                newBeverageToAdd.active = true;
            }

            Console.WriteLine(newBeverageToAdd.id.Trim() + " " + newBeverageToAdd.name.Trim() + " " + newBeverageToAdd.pack.Trim() + " " + newBeverageToAdd.price.ToString("C") + " " + newBeverageToAdd.active);

            return newBeverageToAdd;            
        }

        //Display Import Success
        public void DisplayImportSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("Wine List Has Been Imported Successfully");
        }

        //Display Import Error
        public void DisplayImportError()
        {
            Console.WriteLine();
            Console.WriteLine("There was an error importing the CSV");
        }

        //Display All Items
        public void DisplayAllItems(BeverageAStaffenEntities2 beverageOutput)
        {
            Console.WriteLine();
            foreach (Beverage beverage in beverageOutput.Beverages)
            {
                Console.WriteLine(beverage.id.Trim() + " " + beverage.name.Trim() + " " + beverage.pack.Trim() + " "
                    + beverage.price.ToString("c") + " " + beverage.active);
            }
        }

        //Display All Items Error
        public void DisplayAllItemsError()
        {
            Console.WriteLine();
            Console.WriteLine("There are no items in the list to print");
        }

        //Display Item Found Success
        public void DisplayItemFound(Beverage beverageToFind)
        {
            Console.WriteLine();
            Console.WriteLine("Item Found!");
            Console.WriteLine(beverageToFind.id.Trim() + " " + beverageToFind.name.Trim() + " " + beverageToFind.pack.Trim() + " " + beverageToFind.price.ToString("C") + " " + beverageToFind.active);
        }

        //Display Item Found Error
        public void DisplayItemFoundError()
        {
            Console.WriteLine();
            Console.WriteLine("A Match was not found");
        }

        //Display Add Wine Item Success
        public void DisplayAddWineItemSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("The Item was successfully added");
        }

        //Display Item Already Exists Error
        public void DisplayItemAlreadyExistsError()
        {
            Console.WriteLine();
            Console.WriteLine("An Item With That Id Already Exists");
        }

        public Int32 DisplayUpdateMenuAndGetResponse()
        {
            string selection;
            int maxMenuChoice = 5;

            //Display menu and prompt
            this.DisplayUpdateMenu();
            this.displayPrompt();

            //Get the selection they enter
            selection = this.getSelection();

            //While the response is not valid
            while (!this.verifySelectionIsValid(selection, maxMenuChoice))
            {
                //display error message
                this.displayErrorMessage();

                //display the prompt again
                this.displayPrompt();

                //get the selection again
                selection = this.getSelection();
            }

            //Return the selection casted to an integer
            return Int32.Parse(selection);
        }

        public void UpdateOptions(int choice, Beverage beverageToUpdate)
        {

            decimal tempDec;
            string tempString;

            switch (choice)

            {
                case 1:
                    Console.WriteLine("Please Enter The New Name");
                    Console.Write("> ");
                    beverageToUpdate.name = Console.ReadLine();
                    break;

                case 2:
                    Console.WriteLine("Please Enter The New Pack");
                    Console.Write("> ");
                    beverageToUpdate.pack = Console.ReadLine();
                    break;

                case 3:
                    Console.WriteLine("Please Enter The New Price");
                    Console.Write("> ");
                    while (!decimal.TryParse(Console.ReadLine(), out tempDec))
                    {
                        Console.WriteLine("Please enter a number for the price");
                        Console.Write("> ");
                    }
                    beverageToUpdate.price = tempDec;
                    break;

                case 4:
                    Console.WriteLine("Is the item active?");
                    Console.Write("> ");
                    tempString = Console.ReadLine();

                    while (tempString.ToLower() != "f" || tempString.ToLower() != "f")
                    {
                        Console.WriteLine("Please enter either true or false.");
                        Console.Write("> ");
                    }

                    if (tempString == "f")
                    {
                        beverageToUpdate.active = false;
                    }

                    else
                    {
                        beverageToUpdate.active = true;
                    }

                    break;
            }
        }


        //---------------------------------------------------
        //Private Methods
        //---------------------------------------------------

        //Display the Menu
        private void displayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1. Print The Entire List Of Items");
            Console.WriteLine("2. Search For An Item");
            Console.WriteLine("3. Add New Item To The List");
            Console.WriteLine("4. Update An Existing Item");
            Console.WriteLine("5. Delete An Existing Item");
            Console.WriteLine("6. Exit Program");
        }

        //Display the Prompt
        private void displayPrompt()
        {
            Console.WriteLine();
            Console.Write("Enter Your Choice: ");
        }

        //Display the Error Message
        private void displayErrorMessage()
        {
            Console.WriteLine();
            Console.WriteLine("That is not a valid option. Please make a valid choice");
        }

        //Get the selection from the user
        private string getSelection()
        {
            return Console.ReadLine();
        }

        //Verify that a selection from the main menu is valid
        private bool verifySelectionIsValid(string selection, int maxMenuChoice)
        {
            //Declare a returnValue and set it to false
            bool returnValue = false;

            try
            {
                //Parse the selection into a choice variable
                int choice = Int32.Parse(selection);

                //If the choice is between 0 and the maxMenuChoice
                if (choice > 0 && choice <= maxMenuChoice)
                {
                    //set the return value to true
                    returnValue = true;
                }
            }
            //If the selection is not a valid number, this exception will be thrown
            catch (Exception e)
            {
                //set return value to false even though it should already be false
                returnValue = false;
            }

            //Return the reutrnValue
            return returnValue;
        }

        private void DisplayUpdateMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What Would You Like To Update?");
            Console.WriteLine();
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Pack");
            Console.WriteLine("3. Price");
            Console.WriteLine("4. Active");
            Console.WriteLine("5. Exit");
        }
    }
}
