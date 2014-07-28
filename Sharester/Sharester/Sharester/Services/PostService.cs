using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Data.SqlClient;
using System.Xml.Linq;
using Sharester.Models;
using Sharester.Constants;
using Newtonsoft.Json;

namespace Sharester.Services
{
    public class PostService
    {
        public static Post GetPost(Guid postId)
        {
            postId = Guid.NewGuid();
            Post post = new Post();
            try
            {
                using (
                    SqlConnection conn =
                        new SqlConnection(
                            ConfigurationManager.ConnectionStrings[Constants.Constants.ConnectionString]
                                .ConnectionString))
                {
                    var queryString = @"select Post.id, post.userid, 
                                    post.name, post.description, 
                                    post.alive, post.itemscount, post.itemsSold,
                                    item.id, item.name, 
                                    item.description, item.reference, 
                                    item.images, item.cost, 
                                    item.availability, item.negotiable, 
                                    item.category 
                            from Post left join Item on Item.postId = Post.id Where Post.Id = @postId";

                    SqlCommand cmd = new SqlCommand(queryString, conn);
                    cmd.Parameters.AddWithValue("@postId", postId);

                    List<Item> items = new List<Item>();

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    bool isPostSet = false;

                    while (reader.Read())
                    {
                        if (!isPostSet)
                        {
                            post.Id = (Guid) reader[0];
                            post.Name = reader[2].ToString();
                            post.Description = reader[3].ToString();
                            post.UserId = (Guid) reader[1];
                            post.NoOfItems = (int) reader[5];
                            post.NoOfSoldItems = (int) reader[6];
                            isPostSet = true;
                        }
                        items.Add(new Item
                        {
                            Id = (Guid) reader[7],
                            Name = reader[8].ToString(),
                            Description = reader[9].ToString(),
                            Reference = reader[10].ToString(),
                            Images = reader[11].ToString().Split(';').ToList(),
                            Cost = (double) reader[12],
                            Availability =
                                (ItemAvailability) Enum.Parse(typeof (ItemAvailability), reader[13].ToString()),
                            CategoryType = reader[15].ToString()
                        });
                    }

                    post.Items = items;
                    reader.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //Define database logic here.

            return post;
        }

        public static Post UpdatePost(Guid postId, string requestBody, Guid userId)
        {
            //update the post.
            return new Post();
        }

        public static Post CreatePost(string requestBody, Guid userId)
        {
            Guid guid = Guid.NewGuid();
            Post post = Post.Parser(requestBody);
            post.Id = guid;
            post.UserId = userId;

            if (CreatePost(post))
            {
                ItemService.CreateItems(post.Items, guid);
            }

            return post;
        }



        private static bool CreatePost(Post post)
        {
            post.NoOfItems = post.Items.Count;
            post.CreateOn = DateTime.Now;
            post.UpdatedOn = DateTime.Now;

            try
            {
                using (
                    SqlConnection conn =
                        new SqlConnection(ConfigurationManager.ConnectionStrings[Constants.Constants.ConnectionString]
                            .ConnectionString))
                {
                    var queryString =
                        @"insert into Post(Id, UserId, Name, Description, ItemsCount, CreatedOn, UpdatedOn) values(@id, @userId, @name, @description, @itemscount, @createdOn, @updatedOn)";

                    SqlCommand cmd = new SqlCommand(queryString, conn);
                    cmd.Parameters.AddWithValue("@id", post.Id);
                    cmd.Parameters.AddWithValue("@userId", post.UserId);
                    cmd.Parameters.AddWithValue("@name", post.Name ?? "Post");
                    cmd.Parameters.AddWithValue("@description", post.Description?? "Description");
                    cmd.Parameters.AddWithValue("@itemscount", post.NoOfItems);
                    cmd.Parameters.AddWithValue("@createdon", post.CreateOn);
                    cmd.Parameters.AddWithValue("@updatedon", post.UpdatedOn);

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
    }
}