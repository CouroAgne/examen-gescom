namespace Gestion_Commercial_CouroAgne_Liage3.entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelGestioncommercial : DbContext
    {
        public ModelGestioncommercial()
            : base("name=ModelGestioncommercial")
        {
        }

        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Commande> Commande { get; set; }
        public virtual DbSet<Utilisateur> Utilisateur { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.Telephone)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Commande)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.Id_Client)
                .WillCascadeOnDelete(false);
        }
    }
}
