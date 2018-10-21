using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Student_Drive
{
    public class Datahandler
    {        
        SQLiteConnection Connection;
        string personalFolder;
        public Datahandler()
        {
            personalFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var DbName = Path.Combine(personalFolder, "databases");
            Connection = new SQLiteConnection(DbName);
            CreateTables();
        }
        public void CreateTables()
        {
            Connection.CreateTable<LogIn>();
            Connection.CreateTable<User>();
            Connection.CreateTable<Vehicle>();
            Connection.CreateTable<Comments>();
            Connection.CreateTable<Picture>();
        }
        public void AddUser(User user)
        {
            Connection.Insert(user);
        }
        public void AddLogIn(LogIn logIn)
        {
            Connection.Insert(logIn);
        }
        public void AddVehicle(Vehicle vehicle)
        {
            Connection.Insert(vehicle);
        }
        public void AddComment(Comments comments)
        {
            Connection.Insert(comments);
        }
        public void AddPicture(Picture picture)
        {
            Connection.Insert(picture);
        }

        public List<LogIn> ReturnLogins()
        {
            List<LogIn> logList = Connection.Table<LogIn>().ToList();
            return logList;
        }
        public List<User> ReturnUsers()
        {
            List<User> userList = Connection.Table<User>().ToList();
            return userList;
        }
        public List<Comments> ReturnComments()
        {
            List<Comments> commentsList = Connection.Table<Comments>().ToList();
            return commentsList;
        }
        public List<Vehicle> ReturnVehicles()
        {
            List<Vehicle> vehicleList = Connection.Table<Vehicle>().ToList();
            return vehicleList;
        }
        public List<Picture> ReturnPictures()
        {
            List<Picture> pictureList = Connection.Table<Picture>().ToList();
            return pictureList;
        }


    }
    #region LogIn
    [Table("LogIn")]
    public class LogIn
    {
        [Column("ID"), PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Column("Username")]
        public string Username { get; set; }
        [Column("Password")]
        public string Password { get; set; }
        [Column("UserID")]
        public int UserID { get; set; }

        public LogIn()
        {

        }
    }
    #endregion
    #region User
    [Table("User")]
    public class User
    {
        [Column("ID"), PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Surname")]
        public string Surname { get; set; }
        [Column("Age")]
        public int Age { get; set; }
        [Column("IdentificationNumber")]
        public string IdentificationNumber { get; set; }

        public User()
        {

        }
    }
    #endregion
    #region Vehicle
    [Table("Vehicle")]
    public class Vehicle
    {
        [Column("ID"), PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Column("Make")]
        public string Make { get; set; }
        [Column("Model")]
        public string Model { get; set; }
        [Column("Color")]
        public string Color { get; set; }
        [Column("UserID")]
        public int UserID { get; set; }

        public Vehicle()
        {

        }
    }
    #endregion
    #region Comments
    [Table("Comments")]
    public class Comments
    {
        [Column("ID"), PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Column("Comment")]
        public string Comment { get; set; }
        [Column("Rating")]
        public string Rating { get; set; }
        [Column("UserID")]
        public int UserID { get; set; }

        public Comments()
        {

        }
    }
    #endregion
    #region Picture
    [Table("Picture")]
    public class Picture
    {
        [Column("ID")]
        public int ID { get; set; }
        [Column("Source")]
        public string Source { get; set; }
        [Column("UserID")]
        public int UserID { get; set; }

        public Picture()
        {

        }
    }
    #endregion
}