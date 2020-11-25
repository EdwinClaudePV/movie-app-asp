using MovieApp.Models;
using System;
using System.Linq;

namespace MovieApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(MovieContext context)
        {
            context.Database.EnsureCreated();

            if (context.Movies.Any())
            {
                return;   // DB has been seeded
            }

            var movies = new Movie[]
            {
            new Movie{Name="12 Angry Men", Summary="In the overheated jury room of the New York County Courthouse, " +
            "a jury prepares to deliberate the case of an 18-year-old impoverished youth accused of stabbing his father" +
            " to death. The judge instructs them that if there is any reasonable doubt, the jurors are to return a verdict " +
            "of not guilty; if found guilty, the defendant will receive a death sentence. The verdict must be unanimous.", 
                ReleaseDate = new DateTime(1957, 4, 10)},
            new Movie{Name="Balde Runner", Summary="In 2019 Los Angeles, former policeman Rick Deckard is detained by " +
            "Officer Gaff, and brought to his former supervisor, Bryant. Deckard, whose job as a \"blade runner\" was to " +
            "track down bioengineered humanoids known as replicants and terminally \"retire\" them, is informed that four " +
            "replicants are on Earth illegally. Deckard begins to leave, but Bryant ambiguously threatens him and Deckard stays",
                ReleaseDate = new DateTime(1982, 6, 25)}
            };
            foreach (Movie m in movies)
            {
                context.Movies.Add(m);
            }
            context.SaveChanges();
        }
    }
}
