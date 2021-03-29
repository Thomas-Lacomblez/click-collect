using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace E_Marche.Models
{
    public partial class Net5EcommerceDbContext : DbContext
    {
        public Net5EcommerceDbContext()
        {
        }

        public Net5EcommerceDbContext(DbContextOptions<Net5EcommerceDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<CategorieCommercant> CategorieCommercants { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Commande> Commandes { get; set; }
        public virtual DbSet<Commercant> Commercants { get; set; }
        public virtual DbSet<LieuLivraison> LieuLivraisons { get; set; }
        public virtual DbSet<Panier> Paniers { get; set; }
        public virtual DbSet<Paymment> Paymments { get; set; }
        public virtual DbSet<Photo> Photoes { get; set; }
        public virtual DbSet<Sms> Sms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Net5EcommerceDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("Article");

                entity.Property(e => e.ArticleId).HasColumnName("articleId");

                entity.Property(e => e.ArticleDescreption)
                    .HasColumnName("articleDescreption")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cantite).HasColumnName("cantite");

                entity.Property(e => e.CategorieId).HasColumnName("categorieId");

                entity.Property(e => e.Clientid).HasColumnName("clientid");

                entity.Property(e => e.Commercantid).HasColumnName("commercantid");

                entity.Property(e => e.Etat)
                    .HasColumnName("etat")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Libelle)
                    .HasColumnName("libelle")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Categorie)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.CategorieId)
                    .HasConstraintName("Categorie_Articl_FK");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.Clientid)
                    .HasConstraintName("Client_Articl_FK");

                entity.HasOne(d => d.Commercant)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.Commercantid)
                    .HasConstraintName("Commercant_Articl_FK");
            });

            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.ToTable("Categorie");

                entity.Property(e => e.CategorieId).HasColumnName("categorieId");

                entity.Property(e => e.ClientId).HasColumnName("clientId");

                entity.Property(e => e.Discription)
                    .HasColumnName("discription")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Libelle)
                    .HasColumnName("libelle")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("Client_Categorie_FK");
            });

            modelBuilder.Entity<CategorieCommercant>(entity =>
            {
                entity.HasKey(e => new { e.CommercantId, e.CategorieId })
                    .HasName("Commercant_Categorie_pk");

                entity.ToTable("CategorieCommercant");

                entity.Property(e => e.CommercantId).HasColumnName("commercantId");

                entity.Property(e => e.CategorieId).HasColumnName("categorieId");

                entity.Property(e => e.CategorieCommercantId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Categorie)
                    .WithMany(p => p.CategorieCommercants)
                    .HasForeignKey(d => d.CategorieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Categorie");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.ClientId).HasColumnName("clientId");

                entity.Property(e => e.Adresse)
                    .HasColumnName("adresse")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Arrondissement)
                    .HasColumnName("arrondissement")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CategorieId).HasColumnName("categorieId");

                entity.Property(e => e.DescriptionUser)
                    .HasColumnName("descriptionUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoginUser)
                    .HasColumnName("loginUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MdpUser)
                    .HasColumnName("mdpUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .HasColumnName("nom")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasColumnName("prenom")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Smsid).HasColumnName("smsid");

                entity.Property(e => e.Tel)
                    .HasColumnName("tel")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Typeprivilege).HasColumnName("typeprivilege");

                entity.Property(e => e.UserRole).HasColumnName("userRole");

                entity.Property(e => e.Ville)
                    .HasColumnName("ville")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Categorie)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.CategorieId)
                    .HasConstraintName("Categorie_Client_FK");

                entity.HasOne(d => d.Sms)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.Smsid)
                    .HasConstraintName("Sms_Utilisateur_FK");
            });

            modelBuilder.Entity<Commande>(entity =>
            {
                entity.ToTable("Commande");

                entity.Property(e => e.CommandeId).HasColumnName("commandeId");

                entity.Property(e => e.CategorieId).HasColumnName("categorieId");

                entity.Property(e => e.ClientId).HasColumnName("clientId");

                entity.Property(e => e.CommercantId).HasColumnName("commercantId");

                entity.Property(e => e.DateCommande)
                    .HasColumnName("dateCommande")
                    .HasColumnType("date");

                entity.Property(e => e.DateLaivraison)
                    .HasColumnName("dateLaivraison")
                    .HasColumnType("datetime");

                entity.Property(e => e.LieuLaivraison)
                    .HasColumnName("lieuLaivraison")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LieuLivraisonId).HasColumnName("lieuLivraisonId");

                entity.Property(e => e.SommeT).HasColumnName("sommeT");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Commandes)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("Client_Commande_FK");

                entity.HasOne(d => d.Commercant)
                    .WithMany(p => p.Commandes)
                    .HasForeignKey(d => d.CommercantId)
                    .HasConstraintName("Commercant_Commande_FK");

                entity.HasOne(d => d.LieuLivraison)
                    .WithMany(p => p.Commandes)
                    .HasForeignKey(d => d.LieuLivraisonId)
                    .HasConstraintName("LieuLivraisonId_Commande_FK");
            });

            modelBuilder.Entity<Commercant>(entity =>
            {
                entity.ToTable("Commercant");

                entity.Property(e => e.CommercantId).HasColumnName("commercantId");

                entity.Property(e => e.Adresse)
                    .HasColumnName("adresse")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Arrondissement)
                    .HasColumnName("arrondissement")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DescriptionUser)
                    .HasColumnName("descriptionUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoginUser)
                    .HasColumnName("loginUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MdpUser)
                    .HasColumnName("mdpUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .HasColumnName("nom")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasColumnName("prenom")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Siren)
                    .HasColumnName("siren")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Smsid).HasColumnName("smsid");

                entity.Property(e => e.Tel)
                    .HasColumnName("tel")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Typeprivilege).HasColumnName("typeprivilege");

                entity.Property(e => e.UserRole).HasColumnName("userRole");

                entity.Property(e => e.Ville)
                    .HasColumnName("ville")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Sms)
                    .WithMany(p => p.Commercant)
                    .HasForeignKey(d => d.Smsid)
                    .HasConstraintName("Sms_Commercant_FK");
            });

            modelBuilder.Entity<LieuLivraison>(entity =>
            {
                entity.ToTable("LieuLivraison");

                entity.Property(e => e.LieuLivraisonId).HasColumnName("lieuLivraisonId");

                entity.Property(e => e.Ad)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Arrondissement)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Pointderegroupement)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ville)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Panier>(entity =>
            {
                entity.ToTable("Panier");

                entity.Property(e => e.PanierId).HasColumnName("panierId");

                entity.Property(e => e.ArticleId).HasColumnName("articleId");

                entity.Property(e => e.Cantite).HasColumnName("cantite");

                entity.Property(e => e.ClientId).HasColumnName("clientId");

                entity.Property(e => e.CommandeId).HasColumnName("commandeId");

                entity.Property(e => e.Nom)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PrixArticle).HasColumnName("prixArticle");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.Paniers)
                    .HasForeignKey(d => d.ArticleId)
                    .HasConstraintName("Article_Panier_FK");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Paniers)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("Client_Panier_FK");

                entity.HasOne(d => d.Commande)
                    .WithMany(p => p.Paniers)
                    .HasForeignKey(d => d.CommandeId)
                    .HasConstraintName("Commande_Panier_FK");
            });

            modelBuilder.Entity<Paymment>(entity =>
            {
                entity.ToTable("Paymment");

                entity.Property(e => e.PaymmentId).HasColumnName("paymmentId");

                entity.Property(e => e.ClientId).HasColumnName("clientId");

                entity.Property(e => e.CommandeId).HasColumnName("commandeId");

                entity.Property(e => e.CommercantId).HasColumnName("commercantId");

                entity.Property(e => e.DatePaymment)
                    .HasColumnName("datePaymment")
                    .HasColumnType("date");

                entity.Property(e => e.NumCompte)
                    .HasColumnName("numCompte")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelAcommercant)
                    .HasColumnName("telACommercant")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TelUtilisateur)
                    .HasColumnName("telUtilisateur")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Paymments)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("Utilisateur_Paymment_FK");

                entity.HasOne(d => d.Commande)
                    .WithMany(p => p.Paymments)
                    .HasForeignKey(d => d.CommandeId)
                    .HasConstraintName("Commande_Paymment_FK");

                entity.HasOne(d => d.Commercant)
                    .WithMany(p => p.Paymments)
                    .HasForeignKey(d => d.CommercantId)
                    .HasConstraintName("Commercant_Paymment_FK");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.ToTable("Photo");

                entity.Property(e => e.PhotoId).HasColumnName("photoId");

                entity.Property(e => e.ArticleId).HasColumnName("articleId");

                entity.Property(e => e.Chemin)
                    .HasColumnName("chemin")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.Photoes)
                    .HasForeignKey(d => d.ArticleId)
                    .HasConstraintName("Articl_Photo_FK");
            });

            modelBuilder.Entity<Sms>(entity =>
            {
                entity.HasKey(e => e.Smsid)
                    .HasName("PK__Sms__0D796F7DD1F673B7");

                entity.Property(e => e.Smsid).HasColumnName("smsid");

                entity.Property(e => e.Cantite).HasColumnName("cantite");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
