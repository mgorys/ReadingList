// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReadingList.Persistence;

#nullable disable

namespace ReadingList.Persistence.Migrations
{
    [DbContext(typeof(ReadingListDbContext))]
    [Migration("20221207122231_seeds")]
    partial class seeds
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReadingList.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Finished")
                        .HasColumnType("bit");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrioNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Finished = false,
                            ImgUrl = "https://bookishloom.files.wordpress.com/2020/04/513wb5gwt9l.jpg?w=256",
                            Name = "The Da Vinci Code",
                            PrioNumber = 4
                        },
                        new
                        {
                            Id = 2,
                            Finished = false,
                            ImgUrl = "https://m.media-amazon.com/images/I/51jyI6lYi1L._AC_SY780_.jpg",
                            Name = "Harry Potter And the Deathly Hallows",
                            PrioNumber = 2
                        },
                        new
                        {
                            Id = 3,
                            Finished = false,
                            ImgUrl = "http://bookcoverarchive.com/wp-content/uploads/amazon/the_girl_with_the_dragon_tattoo.jpg",
                            Name = "The Girl with the Dragon Tattoo",
                            PrioNumber = 1
                        },
                        new
                        {
                            Id = 4,
                            Finished = false,
                            ImgUrl = "https://ecsmedia.pl/c/a-short-history-of-nearly-everything-w-iext121467176.jpg",
                            Name = "A Short History of Nearly Everything",
                            PrioNumber = 3
                        },
                        new
                        {
                            Id = 5,
                            Finished = false,
                            Name = "The Girl Who Kicked the Hornets' Nest",
                            PrioNumber = 5
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
