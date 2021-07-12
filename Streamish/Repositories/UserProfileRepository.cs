using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Streamish.Models;
using Streamish.Models.ViewModels;
using Streamish.Utils;

namespace Streamish.Repositories
{
    public class UserProfileRepository : BaseRepository, IUserProfileRepository
    {
        public UserProfileRepository(IConfiguration configuration) : base(configuration) { }

        public List<UserProfile> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                var users = new List<UserProfile>();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                SELECT up.Id,up.Name, up.Email, up.DateCreated,
                       up.ImageUrl
                    FROM  UserProfile up 
                    ORDER BY  up.Name
            ";
                    UserProfile user = null;
                    var reader = cmd.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        user = new UserProfile()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Email = DbUtils.GetString(reader, "Email"),
                            DateCreated = DbUtils.GetDateTime(reader, "DateCreated"),
                            ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                        };
                        users.Add(user);
                    }
                    reader.Close();
                    return users;
                }
            }            
        }

        public UserProfileVideo GetByIdWithVideosAndComments(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                var user = new UserProfileVideo();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        Select up.Id,up.Name, up.Email, up.DateCreated,
                        up.ImageUrl,
                        v.Id as VideoId,v.Title,v.Description,v.Url,
                        v.DateCreated as VideoDateCreated,
                        c.Id as CommentId,c.Message,c.VideoId as CommentVideoId,
                        c.UserProfileId as UserComment
                        FROM  UserProfile up 
                        Left Join Video v
                            on up.Id = v.UserProfileId
                        Left Join Comment c 
                            on v.Id = c.VideoId
                        WHERE up.Id = @id
            ";
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (user.User == null)
                        {
                            user.User = new UserProfile()
                            {
                                Id = id,
                                Name = DbUtils.GetString(reader, "Name"),
                                Email = DbUtils.GetString(reader, "Email"),
                                DateCreated = DbUtils.GetDateTime(reader, "DateCreated"),
                                ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                            };
                            user.UserVideos = new List<Video>();
                        }
                            if (DbUtils.IsNotDbNull(reader, "VideoId"))
                            {
                                List<Video> videos = user.UserVideos;
                                Video existingVideo = null ;
                                if (user.UserVideos != null)
                                {
                                    existingVideo = videos.FirstOrDefault(p => p.Id == DbUtils.GetInt(reader, "VideoId"));
                                }
                                
                                if (existingVideo == null)
                                {
                                    existingVideo = new Video()
                                    {
                                        Id = DbUtils.GetInt(reader, "VideoId"),
                                        Title = DbUtils.GetString(reader, "Title"),
                                        Description = DbUtils.GetString(reader, "Description"),
                                        DateCreated = DbUtils.GetDateTime(reader, "VideoDateCreated"),
                                        Url = DbUtils.GetString(reader, "Url"),
                                        UserProfileId = id,
                                        Comments = new List<Comment>()
                                    };
                                    user.UserVideos.Add(existingVideo);
                                }
                            if (DbUtils.IsNotDbNull(reader, "CommentId"))
                            {
                                existingVideo.Comments.Add(new Comment()
                                {
                                    Id = DbUtils.GetInt(reader, "CommentId"),
                                    Message = DbUtils.GetString(reader, "Message"),
                                    VideoId = DbUtils.GetInt(reader, "VideoId"),
                                    UserProfileId = DbUtils.GetInt(reader, "UserComment"),
                                });
                            }
                        }
                    }
                    reader.Close();
                }

                return user;
            }
        }
        public UserProfile GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                var user = new UserProfile();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT up.Id,up.Name, up.Email, up.DateCreated,
                        up.ImageUrl
                        FROM  UserProfile up 
                        WHERE up.Id = @id
            ";
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        user = new UserProfile()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Email = DbUtils.GetString(reader, "Email"),
                            DateCreated = DbUtils.GetDateTime(reader, "DateCreated"),
                            ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                        };
                    }
                    reader.Close();
                    return user;
                }
            }
        }

        public void Delete(int id)
        {
            using(var conn = Connection)
            {
                conn.Open();
                using(var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    DELETE FROM UserProfile WHERE Id = @id;
                    ";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Add(UserProfile user)
        {
            using(var conn = Connection)
            {
                conn.Open();
                using(var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        Insert Into UserProfile(Name,Email,DateCreated,ImageUrl)
                        Values(@name, @email,@dateCreated,@ImageUrl)
                    ";
                    cmd.Parameters.AddWithValue("@name", user.Name);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@dateCreated",DateTime.Now);
                    cmd.Parameters.AddWithValue("@ImageUrl", user.ImageUrl);
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public UserProfile Edit(UserProfile user)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        Update UserProfile
                        set Name = @name,
                            Email = @email,
                            ImageUrl = @ImageUrl
                    ";
                    cmd.Parameters.AddWithValue("@name", user.Name);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@ImageUrl", user.ImageUrl);
                    cmd.ExecuteNonQuery();
                }
                return user;
            }
        }
    }
}
