using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace MiniSocialMedia
{
    // =========================================================
    // Task 1: Custom Exception
    // =========================================================
    public class SocialException : Exception
    {
        public SocialException(string message) : base(message) { }

        public SocialException(string message, Exception inner)
            : base(message, inner) { }
    }

    // =========================================================
    // Task 2: Posting Interface
    // =========================================================
    public interface IPostable
    {
        void AddPost(string content);
        IReadOnlyList<Post> GetPosts();
    }

    // =========================================================
    // Post Class
    // =========================================================
    public class Post
    {
        public User Author { get; }
        public string Content { get; }
        public DateTime CreatedAt { get; }

        public Post(User author, string content)
        {
            if (author == null)
                throw new ArgumentNullException(nameof(author));

            Author = author;
            Content = content;
            CreatedAt = DateTime.UtcNow;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{Author} • {CreatedAt:MMM dd HH:mm}");
            sb.AppendLine(Content);

            var hashtags = Regex.Matches(Content, @"#[A-Za-z]+");
            if (hashtags.Count > 0)
            {
                sb.Append("Tags: ");
                sb.AppendJoin(", ", hashtags.Cast<Match>().Select(m => m.Value));
            }

            return sb.ToString().TrimEnd();
        }
    }

    // =========================================================
    // User (Partial – Core)
    // =========================================================
    public partial class User : IPostable, IComparable<User>
    {
        public string Username { get; init; }
        public string Email { get; init; }

        private readonly List<Post> _posts = new();
        private readonly HashSet<string> _following =
            new(StringComparer.OrdinalIgnoreCase);

        public event Action<Post>? OnNewPost;

        public User(string username, string email)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Invalid username", nameof(username));

            if (!Regex.IsMatch(email, @"^\S+@\S+\.\S+$"))
                throw new SocialException("Invalid email format");

            Username = username.Trim();
            Email = email.Trim().ToLower();
        }

        public void Follow(string username)
        {
            if (string.Equals(username, Username, StringComparison.OrdinalIgnoreCase))
                throw new SocialException("Cannot follow yourself");

            _following.Add(username);
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

            return string.Compare(
                Username,
                other.Username,
                StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString() => $"@{Username}";
    }

    // =========================================================
    // User (Partial – Display Extension)
    // =========================================================
    public partial class User
    {
        public string GetDisplayName()
        {
            return $"User: {Username} <{Email}>";
        }
    }

    // =========================================================
    // Generic Repository
    // =========================================================
    public class Repository<T> where T : class
    {
        private readonly List<T> _items = new();

        public void Add(T item) => _items.Add(item);

        public IReadOnlyList<T> GetAll() => _items.AsReadOnly();

        public T? Find(Predicate<T> match) => _items.Find(match);
    }

    // =========================================================
    // Time Utility (Extension Method)
    // =========================================================
    public static class SocialUtils
    {
        public static string FormatTimeAgo(this DateTime time)
        {
            var diff = DateTime.UtcNow - time;

            if (diff.TotalSeconds < 60)
                return "just now";

            if (diff.TotalMinutes < 60)
                return $"{(int)diff.TotalMinutes} min ago";

            if (diff.TotalHours < 24)
                return $"{(int)diff.TotalHours} h ago";

            return time.ToString("MMM dd");
        }
    }

    // =========================================================
    // User Helper Extensions
    // =========================================================
    public static class UserExtensions
    {
        public static IEnumerable<string> GetFollowingNames(this User user)
        {
            var field = typeof(User).GetField(
                "_following",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance);

            return field?.GetValue(user) as IEnumerable<string>
                   ?? Enumerable.Empty<string>();
        }
    }

    // =========================================================
    // Program Controller
    // =========================================================
    public class Program
    {
        private static readonly Repository<User> _users = new();
        private static User? _currentUser;
        private static readonly string _dataFile = "social-data.json";
        private static readonly string _logFile = "error.log";

        public static void Main()
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
                    if (ex.InnerException != null)
                        Console.WriteLine($"→ {ex.InnerException.Message}");
                }
                catch (Exception ex)
                {
                    ConsoleColorWrite(ConsoleColor.Red, "Unexpected Error!!");
                    Console.WriteLine(ex);
                    LogError(ex);
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey(true);
                Console.Clear();
            }
        }

        // ---------------- LOGIN MENU ----------------
        static void ShowLoginMenu()
        {
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("0. Exit");

            switch (Console.ReadLine())
            {
                case "1": Register(); break;
                case "2": Login(); break;
                case "0":
                    SaveData();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

        static void Register()
        {
            Console.Write("Username: ");
            var username = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(email))
                throw new SocialException("Username and email required");

            if (_users.Find(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)) != null)
                throw new SocialException("Username already exists");

            _users.Add(new User(username, email));
            Console.WriteLine($"Welcome {username}!");
        }

        static void Login()
        {
            Console.Write("Username: ");
            var username = Console.ReadLine();

            var user = _users.Find(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            if (user == null)
                throw new SocialException("User not found");

            _currentUser = user;

            _currentUser.OnNewPost += post =>
            {
                if (_currentUser.IsFollowing(post.Author.Username))
                {
                    var preview = post.Content.Length > 40
                        ? post.Content.Substring(0, 40) + "..."
                        : post.Content;

                    ConsoleColorWrite(
                        ConsoleColor.Cyan,
                        $"New post from {post.Author}: {preview}");
                }
            };

            Console.WriteLine($"Logged in as {_currentUser}");
        }

        // ---------------- MAIN MENU ----------------
        static void ShowMainMenu()
        {
            Console.WriteLine(_currentUser!.GetDisplayName());
            Console.WriteLine("1. Post message");
            Console.WriteLine("2. View my posts");
            Console.WriteLine("3. View timeline");
            Console.WriteLine("4. Follow user");
            Console.WriteLine("5. List users");
            Console.WriteLine("6. Logout");
            Console.WriteLine("0. Exit and save");

            switch (Console.ReadLine())
            {
                case "1": PostMessage(); break;
                case "2": ShowPosts(_currentUser.GetPosts()); break;
                case "3": ShowTimeline(); break;
                case "4": FollowUser(); break;
                case "5": ListUsers(); break;
                case "6": _currentUser = null; break;
                case "0":
                    SaveData();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

        static void PostMessage()
        {
            Console.WriteLine("Max 280 characters. Empty input cancels.");
            Console.Write("Post: ");
            var content = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(content))
            {
                Console.WriteLine("Post cancelled.");
                return;
            }

            _currentUser!.AddPost(content);
            Console.WriteLine("Post created successfully.");
        }

        static void ShowTimeline()
        {
            var timeline = new List<Post>();

            timeline.AddRange(_currentUser!.GetPosts());

            foreach (var name in _currentUser.GetFollowingNames())
            {
                var user = _users.Find(u =>
                    u.Username.Equals(name, StringComparison.OrdinalIgnoreCase));

                if (user != null)
                    timeline.AddRange(user.GetPosts());
            }

            Console.WriteLine("=== Your Timeline ===");

            ShowPosts(
                timeline.OrderByDescending(p => p.CreatedAt));
        }

        static void ShowPosts(IEnumerable<Post> posts)
        {
            int count = 0;

            foreach (var post in posts.Take(20))
            {
                Console.WriteLine(post);
                Console.WriteLine(post.CreatedAt.FormatTimeAgo());
                Console.WriteLine(new string('-', 40));
                count++;
            }

            if (count == 0)
                Console.WriteLine("No posts yet.");
        }

        static void FollowUser()
        {
            Console.Write("Username to follow: ");
            var target = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(target))
            {
                Console.WriteLine("Cancelled.");
                return;
            }

            if (string.Equals(target, _currentUser!.Username,
                StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("You cannot follow yourself.");
                return;
            }

            if (_users.Find(u =>
                u.Username.Equals(target, StringComparison.OrdinalIgnoreCase)) == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            _currentUser.Follow(target);
            Console.WriteLine($"Now following @{target}");
        }

        static void ListUsers()
        {
            Console.WriteLine("Registered users:");

            foreach (var user in _users.GetAll().OrderBy(u => u))
            {
                Console.WriteLine($"{user,-15} {user.Email}");
            }
        }

        // ---------------- DATA & LOGGING ----------------
        static void SaveData()
        {
            try
            {
                var data = _users.GetAll().Select(u => new
                {
                    u.Username,
                    u.Email,
                    Following = u.GetFollowingNames(),
                    Posts = u.GetPosts().Select(p => new
                    {
                        p.Content,
                        p.CreatedAt
                    })
                });

                var json = JsonSerializer.Serialize(
                    data,
                    new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText(_dataFile, json);
                Console.WriteLine("Data saved.");
            }
            catch (Exception ex)
            {
                LogError(ex);
                Console.WriteLine("Failed to save data.");
            }
        }

        static void LoadData()
        {
            try
            {
                if (!File.Exists(_dataFile))
                    return;

                File.ReadAllText(_dataFile);
                Console.WriteLine("Data loaded (simulation).");
            }
            catch (Exception ex)
            {
                LogError(ex);
                Console.WriteLine("Failed to load data.");
            }
        }

        static void LogError(Exception ex)
        {
            try
            {
                File.AppendAllText(
                    _logFile,
                    $"{DateTime.Now}\n{ex.Message}\n{ex.StackTrace}\n\n");
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
