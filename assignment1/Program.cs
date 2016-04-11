//Author: Audre Staffen
//CIS 237
//Assignment 5
/*
 * The Menu Choices Displayed By The UI
 * 1. Print The Entire List Of Items
 * 2. Search For An Item
 * 3. Add New Item To The List
 * 4. Update Existing Item
 * 5. Delete Existing Item
 * 6. Exit Program
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the beverage database
            BeverageAStaffenEntities2 beverageEntities = new BeverageAStaffenEntities2();

            //Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();

            //Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            //Display the Menu and get the response. Store the response in the choice integer
            //This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            while (choice != 6)
            {
                switch (choice)
                {
                    case 1:
                        //Print Entire List Of Items
                        userInterface.DisplayAllItems(beverageEntities);

                        break;

                    case 2:
                        //Search For An Item
                        string searchQuery = userInterface.GetSearchQuery();

                        Beverage beverageToFind = beverageEntities.Beverages.Find(searchQuery);
                        
                        // If there is an item, display item information
                        if (beverageToFind != null)
                        {
                            userInterface.DisplayItemFound(beverageToFind);
                        }

                        // If there is not an item, display error message
                        else
                        {
                            userInterface.DisplayItemFoundError();
                        }

                        break;

                    case 3:
                        //Add A New Item To The List
                        // Get the new information about the item from the user
                        Beverage newItemInformation = userInterface.GetNewItemInformation();


                        try
                        {
                            // Add the new information
                            beverageEntities.Beverages.Add(newItemInformation);
                            // Save changes
                            beverageEntities.SaveChanges();
                            // Display that adding was successful
                            userInterface.DisplayAddWineItemSuccess();
                        }

                        catch
                        {
                            // Remove the new information added because that item is already in the database.
                            beverageEntities.Beverages.Remove(newItemInformation);
                            // Display that the item already exists
                            userInterface.DisplayItemAlreadyExistsError();
                        }

                        break;

                    case 4:
                        // Update An Existing Item
                        // Get ID from user to search
                        searchQuery = userInterface.GetUpdateQuery();

                        try
                        {
                            // Find if ID exists
                            beverageToFind = beverageEntities.Beverages.Find(searchQuery);
                            // If the ID exists, display menu and get user choice on what to update
                            int updateChoice = userInterface.DisplayUpdateMenuAndGetResponse();
                            while (updateChoice != 5)
                            {
                                // Depending on user's choice, allows user to update fields repeatedly until user chooses 5 to exit the update menu
                                userInterface.UpdateOptions(updateChoice, beverageToFind);
                                updateChoice = userInterface.DisplayUpdateMenuAndGetResponse();
                            }
                            // Save update
                            beverageEntities.SaveChanges();
                        }

                        catch
                        {
                            // If item already exists, displays error.
                            userInterface.DisplayItemFoundError();
                        }

                        break;

                    case 5:
                        // Delete an Existing Item
                        // Prompts user for ID of item to delete
                        string deleteQuery = userInterface.GetDeleteQuery();
                        

                        try
                        {
                            // Finds if ID is already in database.
                            Beverage beverageToDelete = beverageEntities.Beverages.Find(deleteQuery);
                            // Removes item
                            beverageEntities.Beverages.Remove(beverageToDelete);
                            // Saves remove
                            beverageEntities.SaveChanges();
                            // Displays that delete was successful
                            userInterface.DisplayDeleteSuccess();
                        }

                        catch
                        {
                            // If the itme is not in the database, displays error
                            userInterface.DisplayItemFoundError();
                        }

                        break;
                }

                //Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }

        }
    }
}
