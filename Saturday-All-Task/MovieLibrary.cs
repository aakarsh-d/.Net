
public interface IFilm
{
    string Title {get;set;}
    string Director {get;set;}
    int Year{get;set;}
}
public interface IFilmLibrary
{
    void AddFilm(IFilm film);
    void RemoveFilm(string title);
    List<IFilm> GetFilms();
    List<IFilm> SearchFilms(string query);
    int GetTotalFilmCount();
}
class Film:IFilm
{
    public string Title{ get; set;}
    public string Director{get;set;}
    public int Year {get;set;}
    public Film(string title, string director,int year)
    {
        Title=title;
        Director=director;
        Year=year;
    }
}

class FilmLibrary:IFilmLibrary
{
    private List<IFilm> _films=new();
    public void AddFilm(IFilm film)
    {
        if(film==null) return;
        _films.Add(film);
    }
    public void RemoveFilm(string title)
    {
        var film=_films.FirstOrDefault(f=>f.Title==title);
        if(film!=null)
        _films.Remove(film);
    }
    public List<IFilm> GetFilms()
    {
        return _films;
        // return _films.Where(f => f).ToList();
    }
    public List<IFilm> SearchFilms(String query)
    {
        if (string.IsNullOrEmpty(query))
        {
            return new List<IFilm>();
        }

        return _films.Where(f=>f.Title.Contains(query) || f.Director.Contains(query)).ToList();
    }

    public int GetTotalFilmCount()
    {
        return _films.Count;
    }
}

class Program
{
    static void Main()
    {
        IFilmLibrary library=new FilmLibrary();
        library.AddFilm(new Film("Inception","Christopher Nolan", 2014));
        library.AddFilm(new Film("Interstellar","Christopher Nolan",2010));
        library.AddFilm(new Film("Matrix","Director",2010));
        Console.WriteLine("\nTotal Films: "+library.GetTotalFilmCount());


        Console.WriteLine("\nAll Films");
        foreach(IFilm film in library.GetFilms())
        {
            Console.WriteLine($"{film.Title} | {film.Director} | {film.Year}");

        }

        Console.WriteLine("\nEnter name to search");
        var input=Console.ReadLine();
        var res=library.SearchFilms(input);
        foreach(var film in res)
        {
            Console.WriteLine($"{film.Title}:({film.Year})");
        }
        Console.WriteLine("\nEnter movie to remove: ");
        var input1 = Console.ReadLine();
        library.RemoveFilm(input1);
        Console.WriteLine("\nAfter Removing Movie Film Count");
        Console.WriteLine("Total Films: "+library.GetTotalFilmCount());
    
    }
}