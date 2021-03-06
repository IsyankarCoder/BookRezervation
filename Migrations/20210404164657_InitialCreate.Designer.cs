// <auto-generated />
using BookRezervation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookRezervation.Migrations
{
    [DbContext(typeof(BookRezervationContext))]
    [Migration("20210404164657_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookRezervation.Domain.Country", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("BookRezervation.Domain.Penalty", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amout")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)");

                    b.Property<short>("CountryId")
                        .HasColumnType("smallint");

                    b.Property<string>("CurrencyCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Penalty");
                });

            modelBuilder.Entity("BookRezervation.Domain.Penalty", b =>
                {
                    b.HasOne("BookRezervation.Domain.Country", "Country")
                        .WithMany("Penalties")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("BookRezervation.Domain.Country", b =>
                {
                    b.Navigation("Penalties");
                });
#pragma warning restore 612, 618
        }
    }
}
