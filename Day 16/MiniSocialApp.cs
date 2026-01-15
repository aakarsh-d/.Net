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





using System;
using System.Text;
using System.Text.RegularExpressions;

namespace MiniSocialMedia
{
    class SocialException : Exception
    {
        public SocialException(string msg) : base(msg) {}
        public SocialException(string msg, Exception inner) : base(msg, inner) {}
    }

    interface IPostable
    {
        public void AddPost(string content);
        public IReadOnlyList<Post> GetPosts();
    }

    public class Post
    {
        public User Author{get; init;}
        public string Content{get; init;}
        public DateTime CreatedAt{get; set;} = DateTime.UtcNow;

        public Post(User author, string content)
        {
            if(author == null)
                throw new ArgumentException("Argument exception", nameof(author));
            Author = author;
            Content = content;
        }

        public override string ToString()
        {
            string pattern = @"#\p{L}+";
            var res = Regex.Matches(Content!, pattern);
            StringBuilder sb = new StringBuilder();
            
            sb.Append($"@{Author} . {CreatedAt}");
            sb.Append(Content);

            if(res.Count > 0)
                sb.AppendJoin(", ", res.Cast<Match>().Select(m => m.Value));
            
            return sb.ToString();
        }
    }

    public partial class User : IPostable, IComparable<User>
    {
        public string Username{get; init;}
        public string Email{get; init;}
        private List<Post> _post = new List<Post>();
        private HashSet<string> _following = new (StringComparer.OrdinalIgnoreCase);
        public event Action<Post>? OnNewPost;

        public User(string username, string email)
        {
            if(string.IsNullOrWhiteSpace(username))
                throw new ArgumentException(nameof(username));
            
            string pattern = @"\b[\w.-]+@[\w]+\.\w{2,}\b";
            bool flag = Regex.IsMatch(email, pattern);

            if(!flag)
                throw new SocialException($"invalid email format");
            
            username = username.Trim();
            Username = username;
            email = email.Trim().ToLower();
            Email = email;
        }
        
        public void Follow(string userToFollow)
        {
            if (userToFollow == null)
                throw new SocialException("User to follow can't be null");

            if (string.Equals(userToFollow, Username, StringComparison.OrdinalIgnoreCase))
                throw new SocialException("Can't follow yourself");

            _following.Add(userToFollow.Trim());
        }

        public bool IsFollowing(string username) => _following.Contains(username);

        public void AddPost(string content)
        {
            if(string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Post content can't be empty");
            
            if(content.Length > 280)
                throw new SocialException("Post too long (max 280 characters)");
            
            content = content.Trim();
            Post p = new Post(this, content);
            _post.Add(p);
            OnNewPost?.Invoke(p);
        }

        public IReadOnlyList<Post> GetPosts()
        {
            return _post.AsReadOnly();
        }

        public int CompareTo(User? other)
        {
            if(other == null)
                return 1;
            return string.Compare(Username, other.Username, StringComparison.OrdinalIgnoreCase);
        }

        public string GetDisplayName()
        {
            return $"User: {Username} <{Email}>";
        }

        public override string ToString()
        {
            return $"@{Username}";
        }



    }

    partial class User
    {
        public string GetDisplayName()
        {
            return $"User: {Username} <{Email}>";
        }
    }
    public class Repository<T> where T : class
    {
        private readonly List<T> _items=[]; // new() // new List<T>();
        
        public void Add(T item) => _items.Add(item);
        public IReadOnlyList<T> GetAll() => _items.AsReadOnly;
        public T? Find(Predicate<T> match)
        {
            return _items.Find(match);
        }
    }

    static class SocialUtils
    {
        public static string FormatTimeAgo(this DateTime time)
        {
            TimeSpan diff=DateTime.UtcNow-time;
            if (diff.TotalSeconds<60)
            {
                return "just now";
            }
            else if(diff.TotalMinutes < 60) return "min ago";
            else if(diff.TotalHours < 24) return " h ago";
            // else if(diff.TotalHours >=24) return "";

            return time.ToString("MMM dd");

        }
    }

    class Program
    {
        private static readonly Repository<User> _users=[];
        private 

    }

    

}