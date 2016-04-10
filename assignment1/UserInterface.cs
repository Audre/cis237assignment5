//Author: David Barnes
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
            Console.WriteLine("Welcome to the wine program.");
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
            Console.WriteLine("What item would you like to update?");
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
            Console.Write("> ");
            newBeverageToAdd.id = Console.ReadLine();
            Console.WriteLine("What is the name?");
            Console.Write("> ");
            newBeverageToAdd.name = Console.ReadLine();
            Console.WriteLine("What is the pack?");
            Console.Write("> ");
            newBeverageToAdd.pack = Console.ReadLine();
            Console.WriteLine("What is the price?");
            Console.Write("> ");
            while (!decimal.TryParse(Console.ReadLine(), out tempDec))
            {
                Console.WriteLine("Please enter a number for the price.");
                Console.Write("> ");
            }
            newBeverageToAdd.price = tempDec;

            Console.WriteLine("Is the item active?");
            Console.Write("> ");
            tempString = Console.ReadLine();

            while (tempString.ToLower() != "f" && tempString.ToLower() != "t" && tempString.ToLower() != "false" && tempString.ToLower() != "true")
            {
                Console.WriteLine("Please enter either true or false.");
                Console.Write("> ");
                tempString = Console.ReadLine();
            }

            if (tempString == "f" || tempString == "false")
            {
                newBeverageToAdd.active = false;
            }
            
            else
            {
                newBeverageToAdd.active = true;
            }

            //Console.WriteLine(newBeverageToAdd.id.Trim() + " " + newBeverageToAdd.name.Trim() + " " + newBeverageToAdd.pack.Trim() + " " + newBeverageToAdd.price.ToString("C") + " " + newBeverageToAdd.active);

            return newBeverageToAdd;            
        }

        //Display Import Success
        public void DisplayImportSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("Wine list has been imported successfully.");
        }

        //Display Import Error
        public void DisplayImportError()
        {
            Console.WriteLine();
            Console.WriteLine("There was an error importing the CSV.");
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
            Console.WriteLine("There are no items in the list to print.");
        }

        //Display Item Found Success
        public void DisplayItemFound(Beverage beverageToFind)
        {
            Console.WriteLine();
            Console.WriteLine("Item found!");
            Console.WriteLine(beverageToFind.id.Trim() + " " + beverageToFind.name.Trim() + " " + beverageToFind.pack.Trim() + " " + beverageToFind.price.ToString("C") + " " + beverageToFind.active);
        }

        //Display Item Found Error
        public void DisplayItemFoundError()
        {
            Console.WriteLine();
            Console.WriteLine("A match was not found.");
        }

        //Display Add Wine Item Success
        public void DisplayAddWineItemSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("The item was successfully added.");
        }

        //Display Item Already Exists Error
        public void DisplayItemAlreadyExistsError()
        {
            Console.WriteLine();
            Console.WriteLine("An item with that ID already exists.");
        }

        // Display deletion success
        public void DisplayDeleteSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("The item was successfully deleted.");
        }

        // Display update success
        public void DisplayUpdateSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("Item successfully updated.");
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
                    Console.WriteLine("Please enter the new name.");
                    Console.Write("> ");
                    beverageToUpdate.name = Console.ReadLine();
                    this.DisplayUpdateSuccess();
                    break;

                case 2:
                    Console.WriteLine("Please enter the new pack.");
                    Console.Write("> ");
                    beverageToUpdate.pack = Console.ReadLine();
                    this.DisplayUpdateSuccess();
                    break;

                case 3:
                    Console.WriteLine("Please enter the new price.");
                    Console.Write("> ");
                    while (!decimal.TryParse(Console.ReadLine(), out tempDec))
                    {
                        Console.WriteLine("Please enter a number for the price.");
                        Console.Write("> ");
                    }
                    beverageToUpdate.price = tempDec;
                    this.DisplayUpdateSuccess();
                    break;

                case 4:
                    Console.WriteLine("Is the item active?");
                    Console.Write("> ");
                    tempString = Console.ReadLine();

                    while (tempString.ToLower() != "f" && tempString.ToLower() != "t" && tempString.ToLower() != "false" && tempString.ToLower() != "true")
                    {
                        Console.WriteLine("Please enter either true or false.");
                        Console.Write("> ");
                        tempString = Console.ReadLine();
                    }

                    if (tempString == "f" || tempString == "false")
                    {
                        beverageToUpdate.active = false;
                        this.DisplayUpdateSuccess();
                    }

                    else
                    {
                        beverageToUpdate.active = true;
                        this.DisplayUpdateSuccess();
                    }

                    break;
            }
        }

        public string GetDeleteQuery()
        {
            Console.WriteLine("Enter the item to delete.");
            Console.Write("> ");
            return Console.ReadLine();
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
            Console.WriteLine("1. Print the entire list Of items.");
            Console.WriteLine("2. Search for an item.");
            Console.WriteLine("3. Add new item to the list.");
            Console.WriteLine("4. Update an existing item.");
            Console.WriteLine("5. Delete an existing item.");
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
            Console.WriteLine("That is not a valid option. Please make a valid choice.");
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
            Console.WriteLine("What would you like to update?");
            Console.WriteLine();
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Pack");
            Console.WriteLine("3. Price");
            Console.WriteLine("4. Active");
            Console.WriteLine("5. Exit");
        }
    }
}
