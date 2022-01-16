using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pazarama_Books.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pazarama_Books.Data
{
    public static class DummyData
    {
        public static void Dummy(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<BooksDbContext>();
            context.Database.Migrate();

            var genres = new List<Genre>()
                        {
                            new Genre {Name="Bilim Kurgu", Books=
                                new List<Book>(){
                                    new Book {
                                        Title="Dune",
                                        Description="Frank Herbert Yüzüklerin Efendisi dışında bu kitapla kıyaslanacak başka bir kitap yok. -Arthur C.Clarke-  Güçlü, inandırıcı ve usta işi." +
                                        "-Robert A. Heinlein-  İthaki Yayınları ",
                                        ImageUrl="1.jpg"
                                    },
                                    new Book {
                                        Title="Fahrenheit 451",
                                        Description="Ray Bradbury  Amerikan edebiyatının öne çıkan yazarlarından Ray Bradbury’nin 1953 yılında yayımlanan eseri " +
                                        "Fahrenheit 451, on yıllar öncesinden bugünün ve uzak geleceğin dünyasına sert eleştiriler savuruyor. " +
                                        "Distopik bir kurgusal düzlemde ilerleyen eser, teknolojinin gelişmesiyle birlikte toplumun gerileyen sanat ve düşünce dünyasını ele alıyor.  İthaki Yayınları",
                                        ImageUrl="2.jpg"
                                    },

                                }
                            },
                            new Genre {Name="Bilim"},
                            new Genre {Name="Mühendislik"},
                            new Genre {Name="Roman"},
                            
                        };
            var movies = new List<Book>()
                        {
                            new Book {
                                Title="Kan Ter ve Pikseller",
                                Description="Jason Schreier    Kan Ter ve Pikseller: Video Oyun Yapımcılığının Arkasındaki Çalkantılı ve Zafer Dolu Hikayeler    İthaki Yayınları  ",
                                ImageUrl="3.jpg",
                                Genres = new List<Genre>() {genres[1], genres[2] }
                            },
                            new Book {
                                Title="Kozmos",
                                Description="Carl Sagan  “Carl Sagan zamanımızın en parlak bilim adamlarından biridir... İçinde varlığımızı sürdürdüğümüz " +
                                "akıllara durgunluk veren Kozmos’un sonsuzluğunu dile getirirken bilimin geçmişine, şimdiki zamanına ve geleceğine ilişkin muhteşem bir eser yaratmış.” Associated Press",
                                ImageUrl="4.jpg",
                                Genres = new List<Genre>() {genres[1] }
                            },
                            new Book {
                                Title="Ben Kirke",
                                Description="NPR, Washington Post, Buzzfeed, People, Time, Amazon, Entertainment Weekly, Bustle ve Newsweek’e göre Yılın En İyi Kitabı Goodreads okurlarına göre 2018’in En İyi Fantastik Kitabı",
                                ImageUrl="5.jpg",
                                Genres = new List<Genre>() { genres[3] }
                            },
                                new Book {
                                Title="Zamanın Kısa Tarihi",
                                Description="Stephen Hawking  “Canlı ve kışkırtıcı.. Hawking doğal bir öğretmen yeteneğine sahip: kolay anlaşılır yazıyor, mizah katıyor ve günlük yaşamdan örnekler veriyor.”– The New York Times",
                                ImageUrl="6.jpg",
                                Genres = new List<Genre>() { genres[1] }
                            }
                           
                        };

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Genres.Count() == 0)
                {
                    context.Genres.AddRange(genres);
                }

                if (context.Books.Count() == 0)
                {
                    context.Books.AddRange(movies);
                }

                context.SaveChanges();
            }

        }
    }
}
