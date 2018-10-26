﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTime2.Models;
using System.Data;
using System.IO;

namespace MovieTime2.DAL
{
    public class CustomerDAL : DAL.ICustomerDAL
    {
        public List<ListCustomer> getAllCustomers()
        {
            DatabaseContext db = new DatabaseContext();
            try
            {
                List<ListCustomer> allCustomers = db.DBCustomer.Select(k => new ListCustomer()
                {
                    Id = k.Id,
                    FirstName = k.FirstName,
                    LastName = k.LastName,
                    Address = k.Address,
                    Location = k.PostalCode.Location,
                    ZipCode = k.ZipCode,
                    PhoneNumber = k.PhoneNumber,
                    Email = k.Email,
                    Username = k.Username

                }).ToList();
                return allCustomers;
            }
            catch(Exception ex)
            {
                LogError(ex);
                return null;
            }
        }


        public bool removeCustomer(int id)
        {
            var orderdal = new OrderDAL();

            DatabaseContext db = new DatabaseContext();
            try
            {
                DBCustomer remove = db.DBCustomer.Find(id);
                var removedCustomer = remove.Username;
                db.DBCustomer.Remove(remove);
                db.SaveChanges();
                LogCustomerDB(id, "removeCustomer", "Remove", removedCustomer, "-- Removed User --");
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("In removecustomer " + ex);
                return false;
            }
        }

        public bool editFirstName(int id, string newDetail)
        {
            DatabaseContext db = new DatabaseContext();
            DBCustomer changedCustomer = db.DBCustomer.Find(id);
            string firstName = changedCustomer.FirstName;
            try
            {
                  changedCustomer.FirstName = newDetail;
                  db.SaveChanges();
                  LogCustomerDB(id, "editFirstName", "FirstName", firstName, newDetail);

                  return true;

                
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool editLastName(int id, string newDetail)
        {
            DatabaseContext db = new DatabaseContext();
            DBCustomer changedCustomer = db.DBCustomer.Find(id);
            string lastName = changedCustomer.LastName;


            try
            {
                changedCustomer.LastName = newDetail;
                db.SaveChanges();
                LogCustomerDB(id, "editLasttName", "LastName", lastName, newDetail);

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return false;
            }
        }

        public bool editUsername(int id, string newDetail)
        {
            DatabaseContext db = new DatabaseContext();
            DBCustomer changedCustomer = db.DBCustomer.Find(id);
            string username = changedCustomer.Username;


            try
            {
                changedCustomer.Username = newDetail;
                db.SaveChanges();
                LogCustomerDB(id, "editUsername", "Username", username, newDetail);

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return false;
            }
        }

        public bool editAddress(int id, string newDetail)
        {
            DatabaseContext db = new DatabaseContext();
            DBCustomer changedCustomer = db.DBCustomer.Find(id);
            string address = changedCustomer.Address;

            try
            {
                changedCustomer.Address = newDetail;
                db.SaveChanges();
                LogCustomerDB(id, "editAddress", "Address", address, newDetail);

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return false;
            }
        }

        public bool editPhoneNumber(int id, string newDetail)
        {
            DatabaseContext db = new DatabaseContext();
            DBCustomer changedCustomer = db.DBCustomer.Find(id);
            string phonenumber = changedCustomer.PhoneNumber;

            try
            {
                changedCustomer.PhoneNumber = newDetail;
                db.SaveChanges();
                LogCustomerDB(id, "editPhoneNumber", "PhoneNumber", phonenumber, newDetail);
           
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return false;
            }
        }

        public bool editEmail(int id, string newDetail)
        {
            DatabaseContext db = new DatabaseContext();
            DBCustomer changedCustomer = db.DBCustomer.Find(id);
            string email = changedCustomer.Email;

            try
            {
                changedCustomer.Email = newDetail;
                db.SaveChanges();
                LogCustomerDB(id, "editEmail", "Email", email, newDetail);

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return false;
            }
        }
        public bool editZipCodeAndLocation(int id, string newZip, string Location)
        {
            DatabaseContext db = new DatabaseContext();
            DBCustomer changedCustomer = db.DBCustomer.Find(id);

            PostalCode foundPost = db.PostalCodes.Find(newZip);
            if (foundPost == null)
            {
                // Create PostLocation
                var newPost = new PostalCode
                {
                    ZipCode = newZip,
                    Location = Location
                };
                changedCustomer.PostalCode = newPost;
            }
            else
            {
                changedCustomer.PostalCode = foundPost;
            }

            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return false;
            }
        }
        public List<ListCustomer> searchCustomer(string username)
        {
            DatabaseContext db = new DatabaseContext();
            DBCustomer foundCustomer = db.DBCustomer.Where(k => k.Username == username).FirstOrDefault();
            List<ListCustomer> foundCustomers = new List<ListCustomer>();

            try
            {
                if (foundCustomer != null)
                {
                    ListCustomer returnCustomer = new ListCustomer()
                    {
                        Id = foundCustomer.Id,
                        FirstName = foundCustomer.FirstName,
                        LastName = foundCustomer.LastName,
                        Address = foundCustomer.Address,
                        PhoneNumber = foundCustomer.PhoneNumber,
                        Email = foundCustomer.Email,
                        Username = foundCustomer.Username,
                        Location = foundCustomer.PostalCode.Location,
                        ZipCode = foundCustomer.ZipCode,
                    };
                    foundCustomers.Add(returnCustomer);
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return foundCustomers;

        }

        public void LogCustomerDB(int customerid, string method, string property, string original, string changes)
        {
            DatabaseContext db = new DatabaseContext();
            string currentDate = DateTime.Today.ToShortDateString();
            string currentTime = DateTime.Now.ToShortTimeString();
            CustomerLog log = new CustomerLog()
            {
                Date = currentDate,
                Time = currentTime,
                DAL = "CustomerDAL",
                CustomerId = customerid,
                Method = method,
                PropertyName = property,
                OldValue = original,
                NewValue = changes
            };
            db.CustomerLog.Add(log);
            db.SaveChanges();
        }
        public void LogError(Exception ex)
        {
            //TODO all try/catches must be redirected to logError

            //Logfiles created under C:\Users\localuser\AppData\Local\Temp\CinemaCityLogs
            string temp = Path.Combine(Path.GetTempPath(), "CinemaCityLogs");
            string path = Path.Combine(temp, "logfile.txt");
            Directory.CreateDirectory(temp);
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine("Date: " + DateTime.Now.ToString() + Environment.NewLine + ex.ToString());
                writer.WriteLine(Environment.NewLine + "____________________________________________________________________" + Environment.NewLine);
            }
        }

    }
}
