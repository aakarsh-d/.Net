// namespace MiniSocialMedia
// {
//     class SocialException:Exception
//     {
//         public SocialException(string message):base(message){}
//         public SocialException(string message,Exception inner):base(message,inner){}
//     }

//     interface IPostable
//     {
//         public void AddPost(string content);
//         public IReadOnlyList GetPosts();
//     }
//     partial class User:IPostable
//     {
//         public string Username{init;}
//         public string Email{init;}
//         private List<int> _posts;
//         private HashSet<string> _following;
//         public Action? OnNewPost;

//         public User(string username, string email)
//         {
//             if(username==null || string.IsNullOrEmpty(username))
//                 throw new SocialException($"Error in {username}");

//             string pattern=@"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            
//             bool flag = Regex.IsMatch(email, pattern);

//             if(!flag)
//                 throw new SocialException($"invalid email format");
            
//             username = username.Trim();
//             Username = username;
//             email = email.Trim().ToLower();
//             Email = email;
//         }
        
//         public void Follow(string userToFollow)
//         {
//             if (userToFollow == null)
//                 throw new SocialException("User to follow can't be null");

//             if (string.Equals(userToFollow, Username, StringComparison.OrdinalIgnoreCase))
//                 throw new SocialException("Can't follow yourself");

//             _following.Add(userToFollow.Trim());
//         }

//         public bool IsFollowing(string username) => _following.Contains(username);

//         public void AddPost(string content)
//         {
//             if(string.IsNullOrWhiteSpace(content))
//                 throw new ArgumentException("Post content can't be empty");
            
//             if(content.Length > 280)
//                 throw new SocialException("Post too long (max 280 characters)");
            
//             content = content.Trim();
//             Post p = new Post(this, content);
//             _post.Add(p);
//             OnNewPost?.Invoke(p);
//         }

//         public IReadOnlyList<Post> GetPosts()
//         {
//             return _post.AsReadOnly();
//         }

//         public int CompareTo(User? other)
//         {
//             if(other == null)
//                 return 1;
//             return string.Compare(Username, other.Username, StringComparison.OrdinalIgnoreCase);
//         }

//         public string GetDisplayName()
//         {
//             return $"User: {Username} <{Email}>";
//         }
//     }

    

// }





// using System;
// using System.Data.Common;
// using System.Linq.Expressions;
// using System.Runtime;
// using System.Text;
// using System.Text.Json;
// using System.Text.RegularExpressions;

// namespace MiniSocialMedia
// {
//     class SocialException : Exception
//     {
//         public SocialException(string msg) : base(msg) {}
//         public SocialException(string msg, Exception inner) : base(msg, inner) {}
//     }

//     interface IPostable
//     {
//         public void AddPost(string content);
//         public IReadOnlyList<Post> GetPosts();
//     }

//     public class Post
//     {
//         public User Author{get; init;}
//         public string Content{get; init;}
//         public DateTime CreatedAt{get; set;} = DateTime.UtcNow;

//         public Post(User author, string content)
//         {
//             if(author == null)
//                 throw new ArgumentException("Argument exception", nameof(author));
//             Author = author;
//             Content = content;
//         }

//         public override string ToString()
//         {
//             string pattern = @"#\p{L}+";
//             var res = Regex.Matches(Content!, pattern);
//             StringBuilder sb = new StringBuilder();
            
//             sb.Append($"@{Author} . {CreatedAt}");
//             sb.Append(Content);

//             if(res.Count > 0)
//                 sb.AppendJoin(", ", res.Cast<Match>().Select(m => m.Value));
            
//             return sb.ToString();
//         }
//     }

//     public partial class User : IPostable, IComparable<User>
//     {
//         public string Username{get; init;}
//         public string Email{get; init;}
//         private List<Post> _post = new List<Post>();
//         private HashSet<string> _following = new (StringComparer.OrdinalIgnoreCase);
//         public event Action<Post>? OnNewPost;

//         public User(string username, string email)
//         {
//             if(string.IsNullOrWhiteSpace(username))
//                 throw new ArgumentException(nameof(username));
            
//             string pattern = @"\b[\w.-]+@[\w]+\.\w{2,}\b";
//             bool flag = Regex.IsMatch(email, pattern);

//             if(!flag)
//                 throw new SocialException($"invalid email format");
            
//             username = username.Trim();
//             Username = username;
//             email = email.Trim().ToLower();
//             Email = email;
//         }
        
//         public void Follow(string userToFollow)
//         {
//             if (userToFollow == null)
//                 throw new SocialException("User to follow can't be null");

//             if (string.Equals(userToFollow, Username, StringComparison.OrdinalIgnoreCase))
//                 throw new SocialException("Can't follow yourself");

//             _following.Add(userToFollow.Trim());
//         }

//         public bool IsFollowing(string username) => _following.Contains(username);

//         public void AddPost(string content)
//         {
//             if(string.IsNullOrWhiteSpace(content))
//                 throw new ArgumentException("Post content can't be empty");
            
//             if(content.Length > 280)
//                 throw new SocialException("Post too long (max 280 characters)");
            
//             content = content.Trim();
//             Post p = new Post(this, content);
//             _post.Add(p);
//             OnNewPost?.Invoke(p);
//         }

//         public IReadOnlyList<Post> GetPosts()
//         {
//             return _post.AsReadOnly();
//         }

//         public int CompareTo(User? other)
//         {
//             if(other == null)
//                 return 1;
//             return string.Compare(Username, other.Username, StringComparison.OrdinalIgnoreCase);
//         }

//         public string GetDisplayName()
//         {
//             return $"User: {Username} <{Email}>";
//         }

//         public override string ToString()
//         {
//             return $"@{Username}";
//         }



//     }

//     partial class User
//     {
//         public string GetDisplayName()
//         {
//             return $"User: {Username} <{Email}>";
//         }
//     }
//     public class Repository<T> where T : class
//     {
//         private readonly List<T> _items=[]; // new() // new List<T>();
        
//         public void Add(T item) => _items.Add(item);
//         public IReadOnlyList<T> GetAll() => _items.AsReadOnly;
//         public T? Find(Predicate<T> match)
//         {
//             return _items.Find(match);
//         }
//     }

//     static class SocialUtils
//     {
//         public static string FormatTimeAgo(this DateTime time)
//         {
//             TimeSpan diff=DateTime.UtcNow-time;
//             if (diff.TotalSeconds<60)
//             {
//                 return "just now";
//             }
//             else if(diff.TotalMinutes < 60) return "min ago";
//             else if(diff.TotalHours < 24) return " h ago";
//             // else if(diff.TotalHours >=24) return "";

//             return time.ToString("MMM dd");

//         }
//     }

//     class Program
//     {
//         private static readonly Repository<User> _users=[];
//         private static User? _currentUser;
//         private static readonly string _dataFile="social-data.json";
//         static void Main()
//         {
//             Console.WriteLine("MiniSocial - Console Edition");
//             Console.WriteLine("===MiniSocial===");
//             while (true)
//             {
//                 try{
//                     if(_currentUser==null)
//                         ShowLoginMenu();
//                     else 
//                         ShowMainMenu();
//                 }

//                 catch (SocialException)
//                 {
//                     Console.ForegroundColor=ConsoleColor.Red;
//                     Console.WriteLine($"Error: {ex.Message}");

//                     if(ex.InnerException!=null)
//                         Console.WriteLine($"-> {ex.InnerException.Message}");
//                     Console.ResetColor();
                
//                 }
//                 catch(Exception ex)
//                 {
//                     Console.WriteLine("Unexpected error occured.");
//                     Console.WriteLine(ex);
//                 }

//                 Console.WriteLine("\nPress any key...");
//                 Console.ReadKey();
//                 Console.Clear();
//             }

//         }
//         static void ShowLoginMenu()
//         {
//             Console.WriteLine("1. Register\n2. Login\n3. Exit");
//             var Choice=Console.ReadLine();
//             if(choice=="1") Register();
//             else if(choice=="2") Login();
//             else if(choice=="3") Environment.Exit();

            
//         }
//         static void Register()
//         {
//             Console.Write("UserName: ");
//             var u=Console.ReadLine()!;
//             Console.Write("Email: ");
//             var e=Console.ReadLine()!;

//             if(_users.Find(x=>x.Username.Equals(u,StringComparison.OrdinalIgnoreCase))!=null);
//                 throw new SocialException("Username Alreadyy Exists");
            
//             _users.Add(new User(u,e));
//             Console.ReadLine("User Registered Successfully");
//         }
//         static void Login()
//         {
//             Console.WriteLine("Username: ");
//             var u=Console.ReadLine()!;
//             var user=_users.Find(x=>x.Username.Equals(u,StringComparison.OrdinalIgnoreCase));

//             if(user==null)
//                 throw new SocialException("User not found");

//             _currentUser=user;
//             Console.WriteLine($"Welcome {_currentUser}");
//         }

//         static void ShowMainMenu()
//         {
//             Console.WriteLine($"Logged in as {_currentUser}");
//             Console.WriteLine("1. Post message\n2. View own posts\n3. View timeline\n4. Follow user\n5. List users\n6. List users\n7.Logout\n8.Exit and save");
//             Console.WriteLine("Enter your choice: ");
//             var choice=ReadLine();
//             switch (choice)
//             {
//                 case "1":
//                     PostMessage();
//                     break;
//                 case "2":
//                     ShowPosts();
//                     break;
//                 case "3":
//                     ShowTimeLine();
//                     break;
//                 case "4":
//                     FollowUser();
//                     break;
//                 case "5":
//                     ListUsers();
//                     break;
//                 case "6":
//                     LogOut();
//                     break;
//                 case "7":
//                     break;
//                 default:
//                     Console.WriteLine("Wrong Choice...");
//             }

//         }
//         static void PostMessage()
//         {
//             if(_currentUser==null) return;
//             Console.Write("Post Content: ");
//             string content= Console.ReadLine();
//             if(string.IsNullOrWhiteSpace(content)) return;

//             _currentUser!.AddPost(content);
//             Console.WriteLine("Post created successfully");
//         }
//         static void ShowTimeLine()
//         {
//             var timeline=new List<Posts>();
//             timeline.AddRange(_currentUser!.GetPosts());

//             foreach(var usr in _users.GetAll)
//             {
//                 if (_currentUser.IsFollowing(usr))
//                 {
//                     timeline.AddRange(usr.GetPosts());
//                 }
//                 ShowPosts(timeline.OrderByDescending(p=>p.CreatedAt).ToList());
//             }
//         }
//         static void ShowPosts(IEnumerable<Post> posts)
//         {
//             if (!posts.Any())
//             {
//                 Console.WriteLine("No posts available");
//                 return;
//             }
//             foreach(var post in posts.Take(10))
//             {
//                 Console.WriteLine(post);
//                 Console.WriteLine(post.CreatedAt.FormatTimeAgo());
//                 Console.WriteLine(new string('-',40));

//             }
//         }
//         static void ShowMessage()
//         {
            
//         }
//         static void FollowUser()
//         {
//             if(_currentUser==null) return;
//             Console.WriteLine("UserName to follow:");
//             var usrname=Console.ReadLine();                                         
//             if(string.IsNullOrWhiteSpace(usrname)) return;

//             if(_users.Find(u=>u.Username.Equals(target, StringComparison.OrdinalIgnoreCase))==null)
//                throw new SocialException("User does not exist");

//                _currentUser!.FollowUser(usrname);

//         }
//         static void ListUsers()
//         {
//             Console.WriteLine("Registered users: ");
//             foreach(var user in _users.GetAll().OrderBy(e=>e))
//             {
//                 Console.WriteLine(user.GetDisplayName());
//             }
//         }
//         static void SaveData()
//         {
//             try
//             {
//                 var data = _users.GetAll().Select(u => new
//                 {
//                     u.Username,
//                     u.Email,
//                     Following=u.GetFollowingN
//                 })
//             }
//         }
//         static void LoadData()
//         {
            
//         }
//         static LogError()
//         {
            
//         }

//     }

    

// }



using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace MiniSocialMedia
{
    public class SocialException : Exception
    {
        public SocialException(string message) : base(message) { }
        public SocialException(string message, Exception inner) : base(message, inner) { }
    }

    public interface IPostable
    {
        void AddPost(string content);
        IReadOnlyList<Post> GetPosts();
    }

    public class Post
    {
        public User Author { get; init; }
        public string Content { get; init; }
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

        public Post(User author, string content)
        {
            if (author == null)
                throw new ArgumentException("Author cannot be null", nameof(author));

            Author = author;
            Content = content;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Author} • {CreatedAt:MMM dd HH:mm}");
            sb.AppendLine(Content);

            var tags = Regex.Matches(Content, @"#\p{L}+");
            if (tags.Count > 0)
            {
                sb.Append("Tags: ");
                sb.AppendJoin(", ", tags.Cast<Match>().Select(m => m.Value));
            }

            return sb.ToString().TrimEnd();
        }
    }

    public partial class User : IPostable, IComparable<User>
    {
        public string Username { get; init; }
        public string Email { get; init; }

        private readonly List<Post> _posts = new();
        private readonly HashSet<string> _following = new(StringComparer.OrdinalIgnoreCase);

        public event Action<Post>? OnNewPost;

        public User(string username, string email)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Invalid username", nameof(username));

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.\w+$"))
                throw new SocialException("Invalid email format");

            Username = username.Trim();
            Email = email.Trim().ToLower();
        }

        public void Follow(string username)
        {
            if (string.Equals(username, Username, StringComparison.OrdinalIgnoreCase))
                throw new SocialException("Cannot follow yourself");

            _following.Add(username.Trim());
        }

        public bool IsFollowing(string username) =>
            _following.Contains(username);

        public void AddPost(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Post content cannot be empty");

            if (content.Length > 280)
                throw new SocialException("Post too long (max 280 characters)");

            var post = new Post(this, content.Trim());
            _posts.Add(post);
            OnNewPost?.Invoke(post);
        }

        public IReadOnlyList<Post> GetPosts() =>
            _posts.AsReadOnly();

        public int CompareTo(User? other)
        {
            if (other == null) return 1;
            return string.Compare(Username, other.Username, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString() => $"@{Username}";
    }

    public partial class User
    {
        public string GetDisplayName() =>
            $"User: {Username} <{Email}>";

        public IEnumerable<string> GetFollowingNames() =>
            _following;
    }

    public class Repository<T> where T : class
    {
        private readonly List<T> _items = new();

        public void Add(T item) => _items.Add(item);
        public IReadOnlyList<T> GetAll() => _items.AsReadOnly();
        public T? Find(Predicate<T> match) => _items.Find(match);
    }

    public static class SocialUtils
    {
        public static string FormatTimeAgo(this DateTime time)
        {
            var diff = DateTime.UtcNow - time;

            if (diff.TotalSeconds < 60) return "just now";
            if (diff.TotalMinutes < 60) return $"{(int)diff.TotalMinutes} min ago";
            if (diff.TotalHours < 24) return $"{(int)diff.TotalHours} h ago";
            return time.ToString("MMM dd");
        }
    }

    public class Program
    {
        private static readonly Repository<User> _users = new();
        private static User? _currentUser;
        private static readonly string _dataFile = "social-data.json";
        private static readonly string _logFile = "error.log";

        static void Main()
        {
            Console.Title = "MiniSocial - Console Edition";
            Console.WriteLine("=== MiniSocial ===");

            LoadData();

            while (true)
            {
                try
                {
                    if (_currentUser == null)
                        ShowLoginMenu();
                    else
                        ShowMainMenu();
                }
                catch (SocialException ex)
                {
                    ConsoleColorWrite(ConsoleColor.Red, $"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected Error!!");
                    LogError(ex);
                }

                Console.WriteLine("\nPress any key...");
                Console.ReadKey(true);
                Console.Clear();
            }
        }

        private static void ShowLoginMenu()
        {
            Console.WriteLine("1. Register\n2. Login\n0. Exit");
            var choice = Console.ReadLine();

            if (choice == "1") Register();
            else if (choice == "2") Login();
            else if (choice == "0")
            {
                SaveData();
                Environment.Exit(0);
            }
        }

        private static void Register()
        {
            Console.Write("Username: ");
            var u = Console.ReadLine()!;
            Console.Write("Email: ");
            var e = Console.ReadLine()!;

            if (_users.Find(x => x.Username.Equals(u, StringComparison.OrdinalIgnoreCase)) != null)
                throw new SocialException("Username already exists");

            _users.Add(new User(u, e));
            Console.WriteLine("User registered successfully");
        }

        private static void Login()
        {
            Console.Write("Username: ");
            var u = Console.ReadLine()!;
            var user = _users.Find(x => x.Username.Equals(u, StringComparison.OrdinalIgnoreCase));

            if (user == null)
                throw new SocialException("User not found");

            _currentUser = user;
            _currentUser.OnNewPost += p =>
            {
                var preview = p.Content.Length > 40
                    ? p.Content[..40] + "..."
                    : p.Content;

                ConsoleColorWrite(ConsoleColor.Cyan,
                    $"[New Post] {p.Author}: {preview}");
            };

            Console.WriteLine($"Logged in as {_currentUser}");
        }

        private static void ShowMainMenu()
        {
            Console.WriteLine($"Logged in as {_currentUser}");
            Console.WriteLine("1.Post\n2.My Posts\n3.Timeline\n4.Follow\n5.Users\n6.Logout\n0.Exit");

            var choice = Console.ReadLine();
            if (choice == "1") PostMessage();
            else if (choice == "2") ShowPosts(_currentUser!.GetPosts());
            else if (choice == "3") ShowTimeline();
            else if (choice == "4") FollowUser();
            else if (choice == "5") ListUsers();
            else if (choice == "6") _currentUser = null;
            else if (choice == "0")
            {
                SaveData();
                Environment.Exit(0);
            }
        }

        private static void PostMessage()
        {
            Console.WriteLine("Write post (max 280 chars):");
            var content = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(content))
            {
                Console.WriteLine("Post cancelled");
                return;
            }

            _currentUser!.AddPost(content);
            Console.WriteLine("Post created");
        }

        private static void ShowTimeline()
        {
            var timeline = new List<Post>();
            timeline.AddRange(_currentUser!.GetPosts());

            foreach (var name in _currentUser.GetFollowingNames())
            {
                var u = _users.Find(x => x.Username.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (u != null)
                    timeline.AddRange(u.GetPosts());
            }

            Console.WriteLine("=== Your Timeline ===");
            ShowPosts(timeline.OrderByDescending(p => p.CreatedAt));
        }

        private static void ShowPosts(IEnumerable<Post> posts)
        {
            var shown = posts.Take(20).ToList();
            if (!shown.Any())
            {
                Console.WriteLine("No posts yet.");
                return;
            }

            foreach (var p in shown)
            {
                Console.WriteLine(p);
                Console.WriteLine(p.CreatedAt.FormatTimeAgo());
                Console.WriteLine(new string('-', 40));
            }
        }

        private static void FollowUser()
        {
            Console.Write("Username to follow: ");
            var name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Cancelled.");
                return;
            }

            if (_users.Find(x => x.Username.Equals(name, StringComparison.OrdinalIgnoreCase)) == null)
                throw new SocialException("User not found");

            _currentUser!.Follow(name);
            Console.WriteLine($"Now following @{name}");
        }

        private static void ListUsers()
        {
            Console.WriteLine("Registered users:");
            foreach (var u in _users.GetAll().OrderBy(u => u))
                Console.WriteLine($"{u,-15} {u.Email}");
        }

        private static void SaveData()
        {
            try
            {
                var data = _users.GetAll().Select(u => new
                {
                    u.Username,
                    u.Email,
                    Following = u.GetFollowingNames(),
                    Posts = u.GetPosts().Select(p => new { p.Content, p.CreatedAt })
                });

                File.WriteAllText(_dataFile,
                    JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch (Exception ex)
            {
                LogError(ex);
                Console.WriteLine("Failed to save data.");
            }
        }

        private static void LoadData()
        {
            if (!File.Exists(_dataFile)) return;

            try
            {
                File.ReadAllText(_dataFile);
                Console.WriteLine("Data loaded (simulation).");
            }
            catch (Exception ex)
            {
                LogError(ex);
                Console.WriteLine("Failed to load data.");
            }
        }

        private static void LogError(Exception ex)
        {
            try
            {
                File.AppendAllText(_logFile,
                    $"\n[{DateTime.Now}]\n{ex.Message}\n{ex.StackTrace}\n");
            }
            catch { }
        }

        private static void ConsoleColorWrite(ConsoleColor color, string text)
        {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = old;
        }
    }
}
