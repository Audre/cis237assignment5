//Author: David Barnes
//CIS 237
//Assignment 1
/*
 * The Menu Choices Displayed By The UI
 * 1. Load Wine List From CSV
 * 2. Print The Entire List Of Items
 * 3. Search For An Item
 * 4. Add New Item To The List
 * 5. Exit Program
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

                        if (beverageToFind != null)
                        {
                            userInterface.DisplayItemFound(beverageToFind);
                        }

                        else
                        {
                            userInterface.DisplayItemFoundError();
                        }

                        break;

                    case 3:
                        //Add A New Item To The List
                        Beverage newItemInformation = userInterface.GetNewItemInformation();

                        try
                        {
                            beverageEntities.Beverages.Add(newItemInformation);

                            beverageEntities.SaveChanges();

                            userInterface.DisplayAddWineItemSuccess();
                        }

                        catch
                        {
                            beverageEntities.Beverages.Remove(newItemInformation);

                            Console.WriteLine("That beverage is already in the database.");
                        }

                        break;

                    case 4:
                        // Update An Existing Item
                        searchQuery = userInterface.GetUpdateQuery();

                        try
                        {
                            beverageToFind = beverageEntities.Beverages.Find(searchQuery);
                            int updateChoice = userInterface.DisplayUpdateMenuAndGetResponse();
                            while (updateChoice != 5)
                            {
                                userInterface.UpdateOptions(updateChoice, beverageToFind);
                                updateChoice = userInterface.DisplayUpdateMenuAndGetResponse();
                            }

                            beverageEntities.SaveChanges();
                        }

                        catch
                        {
                            userInterface.DisplayItemFoundError();
                        }

                        //if (beverageToFind != null)
                        //{
                        //    int updateChoice = userInterface.DisplayUpdateMenuAndGetResponse();
                        //    while (updateChoice != 5)
                        //    {
                        //        userInterface.UpdateOptions(updateChoice, beverageToFind);
                        //        updateChoice = userInterface.DisplayUpdateMenuAndGetResponse();
                        //    }

                        //    beverageEntities.SaveChanges();
                        //}

                        //else
                        //{
                        //    userInterface.DisplayItemFoundError();
                        //}

                        break;

                    case 5:
                        // Delete an Existing Item

                        string deleteQuery = userInterface.GetDeleteQuery();

                        Beverage beverageToDelete = beverageEntities.Beverages.Find(deleteQuery);

                        try
                        {
                            beverageEntities.Beverages.Remove(beverageToDelete);
                            beverageEntities.SaveChanges();
                            userInterface.DisplayDeleteSuccess();
                        }

                        catch
                        {
                            userInterface.DisplayItemFoundError();
                        }

                        //if (beverageToDelete != null)
                        //{
                        //    beverageEntities.Beverages.Remove(beverageToDelete);
                        //    beverageEntities.SaveChanges();
                        //    userInterface.DisplayDeleteSuccess();
                        //}

                        //else
                        //{
                        //    userInterface.DisplayItemFoundError();
                        //}

                        break;
                }

                //Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }

        }
    }
}
