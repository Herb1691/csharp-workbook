using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint2_ToDoApp
{
    class ItemRepository
    {
        public ItemContext listContext = new ItemContext();
        
        public ItemRepository()
        {
            listContext.Database.EnsureCreated();
        }

        /// <summary>
        /// Adds an record to the database.
        /// </summary>
        /// <param name="description"></param>
        public void AddToDB(string description)
        {
            ToDoItem newItem = new ToDoItem(description);
            listContext.Add(newItem);
            listContext.SaveChanges();
        }

        /// <summary>
        /// Returns a list of all records in the database.
        /// </summary>
        /// <returns></returns>
        public List<ToDoItem> PrintList()
        {
            List<ToDoItem> itemList = new List<ToDoItem>();

            foreach (ToDoItem item in listContext.Items)
            {
                itemList.Add(item);
            }
            return itemList;
        }

        /// <summary>
        /// Returns a list of all records matching the status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<ToDoItem> PrintStatus(Flag status)
        {
            List<ToDoItem> statusList = new List<ToDoItem>();
            string currentStatus = string.Empty;

            switch(status)
            {
                case Flag.Done:
                    currentStatus = "Done";
                    break;
                case Flag.Pending:
                    currentStatus = "Pending";
                    break;
            }

            // Queries the DB, finding all items that match the currentStatus and copies
            // it to the statusList.  If no records match the currentStatus then null is returned.
            {
                statusList = listContext.Items
                    .Where(item => item.Status == currentStatus)
                    .ToList();                
            }

            return statusList;
        }

        /// <summary>
        /// Based on the ID passed to it, this function determines if the record is in the database.
        /// If found, returns the record.  If not, returns null.
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public ToDoItem FindItem(int itemID)
        {
            ToDoItem result;

            // -1 means that the user didn't provide a valid input.
            if (itemID > 0)
            {
                //using (listContext)
                {
                    // Checks the DB to find a record that matches the itemID.
                    // If no match is found, null is returned.
                    result = listContext.Items.SingleOrDefault(item => item.Id == itemID);
                }
            }
            else
                result = null;

            return result;
        }

        /// <summary>
        /// Takes a ToDoItem object that contains the record being updated.
        /// Determines if the user wants to update the description or the
        /// status based on the value in update and updates the record
        /// accordingly
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        public bool ItemUpdate(ToDoItem choice, string update)
        {
            bool success = false;
            String[] updating = update.Split();
            string desc = string.Empty;
            int id = 0;
            ToDoItem updatedItem = new ToDoItem(update, choice.Id);

            // If choice is null, then the Find method was unable to
            // locate the requested record.
            if (choice != null)
            {
                // If length is 1 then we need to check if the value is a number.
                if (updating.Length == 1)
                {
                    bool isNumber = false;
                    isNumber = Int32.TryParse(updating[0], out id);

                    // If it is a number then check to see if the value is 2
                    // Which means the user wants to update the status.
                    if (isNumber)
                    {
                        // If it's 2 then we update the status of our record
                        // to the opposite of what it currently is.
                        if (id == 2)
                        {
                            switch (choice.Status)
                            {
                                case "Pending":
                                    choice.Status = "Done";
                                    listContext.SaveChanges();
                                    success = true;
                                    break;
                                case "Done":
                                    choice.Status = "Pending";
                                    listContext.SaveChanges();
                                    success = true;
                                    break;
                            }
                        }
                        // If the length is one and the value is a number but
                        // it does not equal 2, then we have an invalid input.
                        else
                        {
                            success = false;
                        }
                    }
                    // If the length is one, but it's not a number then we assume
                    // that the user intended to add a single character to the
                    // description and save the value there.
                    else
                    {
                        choice.Description = updating[0];
                        listContext.SaveChanges();
                        success = true;
                    }
                }
                // If the length is larger than 1, then the user wants to update the
                // description, so we update the description of the provided record
                // with the value in update.
                else if (updating.Length > 1)
                {
                    {
                        var results = listContext.Items.SingleOrDefault(item => item.Id == choice.Id);
                        if (results != null)
                        {
                            results.Description = update;
                            listContext.Items.Update(results);
                            listContext.SaveChangesAsync();
                            success = true;
                        }
                    }
                }
                else
                    success = false;
            }
            else
                success = false;

            return success;
        }

        /// <summary>
        /// Removes the record passed into it.
        /// </summary>
        /// <param name="toRemove"></param>
        public void RemoveItem( ToDoItem toRemove )
        {
            listContext.Remove(toRemove);
            listContext.SaveChanges();
        }

    }
}
