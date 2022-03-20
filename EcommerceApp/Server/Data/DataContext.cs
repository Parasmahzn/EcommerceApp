namespace EcommerceApp.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category()
                    {
                        Id = 1,
                        Name = "Books",
                        Url = "books"
                    },
                    new Category()
                    {
                        Id = 3,
                        Name = "Movies",
                        Url = "movies"
                    },
                    new Category()
                    {
                        Id = 5,
                        Name = "Video Games",
                        Url = "video-games"
                    }
                );

            modelBuilder.Entity<Product>().HasData(

              new Product()
              {
                  Id = 1,
                  Title = "Nineteen Eighty-Four",
                  Description = "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance and repressive regimentation of people and behaviours within society.[2][3] Orwell, a democratic socialist, modelled the totalitarian government in the novel after Stalinist Russia and Nazi Germany.[2][3][4] More broadly, the novel examines the role of truth and facts within politics and the ways in which they are manipulated.",
                  ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/c/c3/1984first.jpg",
                  Price = 78.8m,
                  CategoryId = 1,
              },
              new Product()
              {
                  Id = 3,
                  Title = "The Lord of the Rings",
                  Description = "The Lord of the Rings is an epic[1] high-fantasy novel[a] by English author and scholar J. R. R. Tolkien. Set in Middle-earth, intended to be Earth at some distant time in the past, the story began as a sequel to Tolkien's 1937 children's book The Hobbit, but eventually developed into a much larger work. Written in stages between 1937 and 1949, The Lord of the Rings is one of the best-selling books ever written, with over 150 million copies sold.[2]",
                  ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/e9/First_Single_Volume_Edition_of_The_Lord_of_the_Rings.gif",
                  Price = 50.8m,
                  CategoryId = 1,
              },
              new Product()
              {
                  Id = 5,
                  Title = "The Lion, the Witch and the Wardrobe",
                  Description = "The Lion, the Witch and the Wardrobe is a fantasy novel for children by C. S. Lewis, published by Geoffrey Bles in 1950. It is the first published and best known of seven novels in The Chronicles of Narnia (1950–1956). Among all the author's books, it is also the most widely held in libraries.[2] Although it was originally the first of The Chronicles of Narnia, it is volume two in recent editions that are sequenced by the stories' chronology. Like the other Chronicles, it was illustrated by Pauline Baynes, and her work has been retained in many later editions",
                  ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/86/TheLionWitchWardrobe%281stEd%29.jpg",
                  Price = 22.8m,
                  CategoryId = 1
              }

          );

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
