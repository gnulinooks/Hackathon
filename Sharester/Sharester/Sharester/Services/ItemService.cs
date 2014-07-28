using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using Sharester.Constants;
using Sharester.Models;

namespace Sharester.Services
{
    public class ItemService
    {

        public static bool CreateItems(List<Item> items, Guid postId)
        {
            items.ForEach((e) =>
            {
                e.Id = Guid.NewGuid();
                e.PostId = postId;
                e.CreatedOn = DateTime.Now;
                e.UpdatedOn = DateTime.Now;
                e.Availability = ItemAvailability.Available;
            });

            var queryString =
                @"insert into Item (Id, Name, Description, Reference, Images, Cost, Availability, Category, PostId, CreatedOn, UpdatedOn) Values";

            foreach (var item in items)
            {
                var images = item.Images ?? new List<string>();
                queryString += String.Format("('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}'),", item.Id,
                    item.Name.ToLowerInvariant(), item.Description, item.Reference, string.Join(";", images), item.Cost, item.Availability,
                    item.Category, item.PostId, item.CreatedOn, item.UpdatedOn);
            }

            queryString = queryString.Substring(0, queryString.Length - 1);

            try
            {
                using (
                    SqlConnection conn =
                        new SqlConnection(
                            ConfigurationManager.ConnectionStrings[Constants.Constants.ConnectionString]
                                .ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(queryString, conn);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return true;
        }

        public static List<Item> GetItems(string query, string category)
        {
            List<Item> items = new List<Item>();

            try
            {
                using (
                    SqlConnection conn =
                        new SqlConnection(
                            ConfigurationManager.ConnectionStrings[Constants.Constants.ConnectionString]
                                .ConnectionString))
                {
                    var queryString = string.Format("select * from Item where Name like '%{0}%' ",
                        query == "All"? string.Empty : query.ToLowerInvariant());

                    if (category != "All")
                    {
                        queryString += " and category = '" + category + "'";
                    }

                    SqlCommand cmd = new SqlCommand(queryString, conn);

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        items.Add(new Item
                        {
                            Id = (Guid) reader[0],
                            Name = reader[1].ToString(),
                            Description = reader[2].ToString(),
                            Reference = reader[3].ToString(),
                            Images = reader[4].ToString().Split(';').ToList(),
                            Cost = (double) reader[5],
                            Category = reader[9].ToString()
                        });
                    }
                    conn.Close();
                }

            }
            catch (Exception)
            {
                throw;
            }
            return items;
        }

        public static List<Item> GetUserPostedItems(Guid userId)
        {
            List<Item> items = new List<Item>();
            try
            {
                using (
                    SqlConnection conn =
                        new SqlConnection(
                            ConfigurationManager.ConnectionStrings[Constants.Constants.ConnectionString]
                                .ConnectionString))
                {
                    var queryString =
                        string.Format(
                            "select Item.* from Post inner join Item on Post.Id = Item.PostId and Post.UserId = '{0}'",
                            userId.ToString());

                    SqlCommand cmd = new SqlCommand(queryString, conn);

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        items.Add(new Item
                        {
                            Id = (Guid)reader[0],
                            Name = reader[1].ToString(),
                            Description = reader[2].ToString(),
                            Reference = reader[3].ToString(),
                            Images = GetImageUrl(reader[4].ToString().Split(';').ToList(), reader[9].ToString()),
                            Cost = (double)reader[5],
                            Category = reader[9].ToString()
                        });
                    }
                    conn.Close();
                }

            }
            catch (Exception)
            {
                throw;
            }
            return items;
        }

        public static List<string> GetImageUrl(List<string> images, string category)
        {
            if (!String.IsNullOrWhiteSpace(images[0]))
            {
                return images;
            }

            images.Clear();

            switch (category)
            {
                case "Furniture":
                    images.Add("Content/images/furniture.jpg");
                    break;
                case "Decoration":
                     images.Add("Content/images/decoration.jpg");
                    break;
                case "Electronics":
                     images.Add("Content/images/electronics.png");
                    break;
                case "Sports":
                    images.Add("Content/images/sports.jpg");
                    break;
                default:
                    images.Add("Content/images/others.jpg");
                    break;
            }

            return images;
        }
    }
}